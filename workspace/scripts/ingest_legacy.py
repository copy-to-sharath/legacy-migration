import argparse
import hashlib
import json
import logging
import os
import re
import time
import uuid
import urllib.request
from typing import Dict, List, Tuple, Optional, Iterable, Set
import multiprocessing as mp

import numpy as np
from sentence_transformers import SentenceTransformer

import pyarrow as pa
import pyarrow.parquet as pq


SUPPORTED_EXTS = {
    ".sln",
    ".csproj",
    ".vbproj",
    ".cs",
    ".vb",
    ".aspx",
    ".ascx",
    ".asmx",
    ".ashx",
    ".asax",
    ".cshtml",
    ".svc",
    ".wsdl",
    ".xsd",
    ".config",
    ".xml",
    ".resx",
    ".json",
    ".yml",
    ".yaml",
    ".ini",
    ".toml",
    ".env",
    ".props",
    ".settings",
    ".sql",
}


CS_TYPE_RE = re.compile(r"^\s*(public|private|protected|internal|static|partial|\s)+\s*(class|interface|struct|enum)\s+(\w+)", re.IGNORECASE)
CS_METHOD_RE = re.compile(r"^\s*(public|private|protected|internal|static|virtual|override|sealed|async|new|abstract|partial|\s)+\s*([\w<>\[\],\s]+)\s+(\w+)\s*\(", re.IGNORECASE)

VB_TYPE_RE = re.compile(r"^\s*(public|private|protected|friend|shared|partial|\s)*\s*(class|interface|structure|enum)\s+(\w+)", re.IGNORECASE)
VB_METHOD_RE = re.compile(r"^\s*(public|private|protected|friend|shared|overridable|overrides|async|\s)*\s*(function|sub)\s+(\w+)\s*\(", re.IGNORECASE)

ASPX_PAGE_RE = re.compile(r"<%@\s*Page[^>]*%>", re.IGNORECASE)
ASPX_INHERITS_RE = re.compile(r"Inherits\\s*=\\s*\"([^\"]+)\"", re.IGNORECASE)
ASMX_WEBSERVICE_RE = re.compile(r"\[\s*WebService\s*\]", re.IGNORECASE)
ASMX_WEBMETHOD_RE = re.compile(r"\[\s*WebMethod\s*\]", re.IGNORECASE)
WCF_SERVICE_CONTRACT_RE = re.compile(r"\[\s*ServiceContract\s*\]", re.IGNORECASE)
WCF_OPERATION_CONTRACT_RE = re.compile(r"\[\s*OperationContract\s*\]", re.IGNORECASE)
VB_WEBSERVICE_RE = re.compile(r"<\s*WebService\s*>", re.IGNORECASE)
VB_WEBMETHOD_RE = re.compile(r"<\s*WebMethod\s*>", re.IGNORECASE)
VB_SERVICE_CONTRACT_RE = re.compile(r"<\s*ServiceContract\s*>", re.IGNORECASE)
VB_OPERATION_CONTRACT_RE = re.compile(r"<\s*OperationContract\s*>", re.IGNORECASE)
SQL_PROC_RE = re.compile(r"\b(?:CREATE|ALTER)\s+PROC(?:EDURE)?\s+([\[\]\w\.]+)", re.IGNORECASE)
SQL_EXEC_RE = re.compile(r"\bEXEC(?:UTE)?\s+([\[\]\w\.]+)", re.IGNORECASE)

_MODEL: Optional[SentenceTransformer] = None
_ROSLYN_INDEX: Optional[Dict[str, Dict[str, List[Dict[str, object]]]]] = None
_ROSLYN_WARNED = False
_ROSLYN_MISSING_LOG: Optional[str] = None
_ROSLYN_MISSING_SEEN: set[str] = set()
_ALL_FILES_SET: Optional[Set[str]] = None
_SUMMARY_MODE: str = "none"
_SUMMARY_ALLOW_FALLBACK: bool = False
_LLM_ENDPOINT: Optional[str] = None
_LLM_API_KEY: Optional[str] = None
_LLM_MODEL: Optional[str] = None
_LLM_PROVIDER: str = "openai"
_SUMMARY_SYSTEM_PROMPT: Optional[str] = None
_SUMMARY_USER_TEMPLATE: Optional[str] = None
_SUMMARY_MAX_CHARS: int = 8000
_SUMMARY_TIMEOUT: int = 30
_STORED_PROC_DIR: Optional[str] = None


def make_id(*parts: str) -> str:
    h = hashlib.sha1()
    for p in parts:
        h.update(p.encode("utf-8", errors="ignore"))
        h.update(b"|")
    return h.hexdigest()


def text_to_vector(text: str, model: SentenceTransformer) -> List[float]:
    embedding = model.encode(text, normalize_embeddings=True, show_progress_bar=False)
    if isinstance(embedding, np.ndarray):
        return embedding.tolist()
    return [float(x) for x in embedding]


def list_files(root: str) -> List[str]:
    files = []
    for dirpath, _, filenames in os.walk(root):
        for name in filenames:
            ext = os.path.splitext(name)[1].lower()
            if ext in SUPPORTED_EXTS:
                files.append(os.path.join(dirpath, name))
    files.sort()
    return files


def get_project(rel_path: str) -> str:
    parts = rel_path.split(os.sep)
    return parts[0] if parts else "root"


def read_lines(path: str, max_bytes: int = 1_500_000) -> List[str]:
    try:
        with open(path, "rb") as f:
            data = f.read(max_bytes)
        text = data.decode("utf-8", errors="ignore")
        return text.splitlines()
    except Exception:
        return []


def write_dataset(rows: List[Dict[str, object]], out_dir: str, partition_cols: List[str], prefix: str) -> None:
    if not rows:
        return
    table = pa.Table.from_pylist(rows)
    basename = f"{prefix}-{uuid.uuid4().hex}-{{i}}.parquet"
    pq.write_to_dataset(table, out_dir, partition_cols=partition_cols, basename_template=basename)


def load_state(state_file: str) -> Dict[str, int]:
    if not os.path.exists(state_file):
        return {"index": 0}
    with open(state_file, "r", encoding="utf-8") as f:
        return json.load(f)


def save_state(
    state_file: str,
    index: int,
    processed: Optional[int] = None,
    total: Optional[int] = None,
    start: Optional[int] = None,
    end: Optional[int] = None,
    status: Optional[str] = None,
) -> None:
    state = {"index": index, "updated": time.strftime("%Y-%m-%dT%H:%M:%SZ", time.gmtime())}
    if processed is not None:
        state["processed"] = processed
    if total is not None:
        state["total"] = total
    if start is not None:
        state["range_start"] = start
    if end is not None:
        state["range_end"] = end
    if status:
        state["status"] = status
    with open(state_file, "w", encoding="utf-8") as f:
        json.dump(state, f, indent=2)


def _init_model(model_name: str) -> None:
    global _MODEL
    _MODEL = SentenceTransformer(model_name)


def _init_worker(model_name: str, roslyn_index: str, roslyn_missing_log: str, all_files: Set[str]) -> None:
    _init_model(model_name)
    _init_roslyn_index(roslyn_index)
    global _ROSLYN_MISSING_LOG
    _ROSLYN_MISSING_LOG = roslyn_missing_log
    global _ALL_FILES_SET
    _ALL_FILES_SET = all_files


def _init_all_worker(
    model_name: str,
    roslyn_index: str,
    roslyn_missing_log: str,
    all_files: Set[str],
    summary_mode: str,
    llm_endpoint: str,
    llm_api_key: str,
    llm_model: str,
    llm_provider: str,
    summary_max_chars: int,
    summary_timeout: int,
    summary_system_path: str,
    summary_user_path: str,
    stored_proc_dir: str,
) -> None:
    _init_worker(model_name, roslyn_index, roslyn_missing_log, all_files)
    _init_summary(
        summary_mode,
        llm_endpoint,
        llm_api_key,
        llm_model,
        llm_provider,
        summary_max_chars,
        summary_timeout,
        summary_system_path,
        summary_user_path,
    )
    global _STORED_PROC_DIR
    _STORED_PROC_DIR = stored_proc_dir


def _init_summary(
    summary_mode: str,
    llm_endpoint: str,
    llm_api_key: str,
    llm_model: str,
    llm_provider: str,
    summary_max_chars: int,
    summary_timeout: int,
    summary_system_path: str,
    summary_user_path: str,
) -> None:
    global _SUMMARY_MODE, _LLM_ENDPOINT, _LLM_API_KEY, _LLM_MODEL, _LLM_PROVIDER
    global _SUMMARY_SYSTEM_PROMPT, _SUMMARY_USER_TEMPLATE, _SUMMARY_MAX_CHARS, _SUMMARY_TIMEOUT
    _SUMMARY_MODE = summary_mode
    _LLM_ENDPOINT = llm_endpoint
    _LLM_API_KEY = llm_api_key
    _LLM_MODEL = llm_model
    _LLM_PROVIDER = llm_provider
    _SUMMARY_MAX_CHARS = summary_max_chars
    _SUMMARY_TIMEOUT = summary_timeout
    _SUMMARY_SYSTEM_PROMPT = _read_prompt(summary_system_path)
    _SUMMARY_USER_TEMPLATE = _read_prompt(summary_user_path)


def _get_model() -> SentenceTransformer:
    if _MODEL is None:
        raise RuntimeError("Embedding model is not initialized")
    return _MODEL


def _init_roslyn_index(index_path: str) -> None:
    global _ROSLYN_INDEX
    index: Dict[str, Dict[str, List[Dict[str, object]]]] = {}
    if not os.path.exists(index_path):
        _ROSLYN_INDEX = index
        return
    with open(index_path, "r", encoding="utf-8") as f:
        for line in f:
            line = line.strip()
            if not line:
                continue
            try:
                record = json.loads(line)
            except json.JSONDecodeError:
                continue
            record_type = record.get("recordType")
            source_file = record.get("sourceFile")
            if not source_file:
                continue
            entry = index.setdefault(source_file, {"nodes": [], "edges": []})
            if record_type == "node":
                entry["nodes"].append(record)
            elif record_type == "edge":
                entry["edges"].append(record)
    _ROSLYN_INDEX = index


def _read_prompt(path: str) -> str:
    if not os.path.exists(path):
        raise RuntimeError(f"Prompt file not found: {path}")
    with open(path, "r", encoding="ascii") as f:
        return f.read().strip()


def _resolve_llm_endpoint(base: str, provider: str, model: str) -> str:
    if provider == "claude":
        if base.endswith("/v1/messages"):
            return base
        return base.rstrip("/") + "/v1/messages"
    if provider == "gemini":
        if base.endswith(":generateContent"):
            return base
        return base.rstrip("/") + f"/v1beta/models/{model}:generateContent"
    if base.endswith("/v1/chat/completions"):
        return base
    return base.rstrip("/") + "/v1/chat/completions"


def _llm_summary(rel_path: str, ext: str, content: str) -> str:
    if not _LLM_ENDPOINT or not _LLM_API_KEY or not _LLM_MODEL:
        raise RuntimeError("LLM configuration missing (endpoint, api key, model)")
    if not _SUMMARY_SYSTEM_PROMPT or not _SUMMARY_USER_TEMPLATE:
        raise RuntimeError("Summary prompt templates are not loaded")
    endpoint = _resolve_llm_endpoint(_LLM_ENDPOINT, _LLM_PROVIDER, _LLM_MODEL)
    content_snippet = content[:_SUMMARY_MAX_CHARS]
    user_prompt = _SUMMARY_USER_TEMPLATE.format(path=rel_path, ext=ext, content=content_snippet)
    headers = {"Content-Type": "application/json"}
    if _LLM_PROVIDER == "claude":
        headers["x-api-key"] = _LLM_API_KEY
        headers["anthropic-version"] = "2023-06-01"
        payload = {
            "model": _LLM_MODEL,
            "max_tokens": 200,
            "messages": [{"role": "user", "content": f"{_SUMMARY_SYSTEM_PROMPT}\n\n{user_prompt}"}],
        }
    elif _LLM_PROVIDER == "gemini":
        endpoint = f"{endpoint}?key={_LLM_API_KEY}"
        payload = {
            "contents": [
                {
                    "role": "user",
                    "parts": [{"text": f"{_SUMMARY_SYSTEM_PROMPT}\n\n{user_prompt}"}],
                }
            ],
            "generationConfig": {"temperature": 0.2, "maxOutputTokens": 200},
        }
    else:
        headers["Authorization"] = f"Bearer {_LLM_API_KEY}"
        payload = {
            "model": _LLM_MODEL,
            "messages": [
                {"role": "system", "content": _SUMMARY_SYSTEM_PROMPT},
                {"role": "user", "content": user_prompt},
            ],
            "temperature": 0.2,
            "max_tokens": 200,
        }
    data = json.dumps(payload).encode("utf-8")
    request = urllib.request.Request(endpoint, data=data, headers=headers)
    with urllib.request.urlopen(request, timeout=_SUMMARY_TIMEOUT) as response:
        body = response.read().decode("utf-8", errors="ignore")
    result = json.loads(body)

    if _LLM_PROVIDER == "claude":
        content_blocks = result.get("content", [])
        if not content_blocks:
            raise RuntimeError("Claude response missing content")
        return content_blocks[0].get("text", "").strip()
    if _LLM_PROVIDER == "gemini":
        candidates = result.get("candidates", [])
        if not candidates:
            raise RuntimeError("Gemini response missing candidates")
        parts = candidates[0].get("content", {}).get("parts", [])
        if not parts:
            raise RuntimeError("Gemini response missing parts")
        return parts[0].get("text", "").strip()
    choices = result.get("choices", [])
    if not choices:
        raise RuntimeError("LLM response missing choices")
    message = choices[0].get("message") or {}
    content_text = message.get("content")
    if not content_text:
        raise RuntimeError("LLM response missing content")
    return content_text.strip()


def _has_local_service(rel_path: str) -> bool:
    if _ALL_FILES_SET is None:
        return False
    base_dir = os.path.dirname(rel_path)
    base_name = os.path.splitext(os.path.basename(rel_path))[0]
    for ext in (".asmx", ".svc"):
        candidate = os.path.join(base_dir, base_name + ext)
        if candidate.lower() in _ALL_FILES_SET:
            return True
    return False


LINQ_METHODS = {
    "Select",
    "Where",
    "Join",
    "GroupBy",
    "OrderBy",
    "OrderByDescending",
    "ThenBy",
    "ThenByDescending",
    "SelectMany",
    "Any",
    "All",
    "First",
    "FirstOrDefault",
    "Single",
    "SingleOrDefault",
    "Count",
    "Sum",
    "Average",
    "Min",
    "Max",
    "Distinct",
    "Take",
    "Skip",
    "ToList",
}

ORM_METHODS = {
    "ExecuteSqlCommand",
    "ExecuteSqlRaw",
    "ExecuteSqlInterpolated",
    "FromSqlRaw",
    "FromSqlInterpolated",
    "SqlQuery",
    "Query",
    "Execute",
    "ExecuteAsync",
    "SaveChanges",
    "SaveChangesAsync",
}

ORM_IDENTIFIERS = {
    "DbContext",
    "DbSet",
    "EntityFramework",
    "NHibernate",
    "ISession",
    "Dapper",
    "SqlMapper",
    "LinqToSql",
    "DataContext",
}

PLAIN_KV_RE = re.compile(r"^\s*([\w\.\-]+)\s*[:=]\s*(.+?)\s*$")
IDENT_RE = re.compile(r"\b[A-Za-z_][A-Za-z0-9_]{2,}\b")
MAX_COMMENTS_PER_FILE = 200

CONFIG_EXTS = {
    ".config",
    ".xml",
    ".json",
    ".yml",
    ".yaml",
    ".ini",
    ".toml",
    ".env",
    ".props",
    ".settings",
    ".wsdl",
    ".xsd",
}

CS_KEYWORDS = {
    "class",
    "public",
    "private",
    "protected",
    "internal",
    "static",
    "void",
    "string",
    "int",
    "bool",
    "return",
    "if",
    "else",
    "for",
    "foreach",
    "while",
    "switch",
    "case",
    "new",
    "namespace",
    "using",
}

VB_KEYWORDS = {
    "class",
    "public",
    "private",
    "protected",
    "friend",
    "shared",
    "function",
    "sub",
    "end",
    "if",
    "then",
    "else",
    "for",
    "each",
    "while",
    "select",
    "case",
    "new",
    "imports",
}

try:
    from tree_sitter_languages import get_language  # type: ignore
    _TREE_SITTER_AVAILABLE = True
except Exception:
    _TREE_SITTER_AVAILABLE = False


def _iter_json_entries(value: object, prefix: str = "") -> Iterable[Tuple[str, str]]:
    if isinstance(value, dict):
        for key, child in value.items():
            key_name = f"{prefix}.{key}" if prefix else str(key)
            yield from _iter_json_entries(child, key_name)
    elif isinstance(value, list):
        for idx, item in enumerate(value):
            key_name = f"{prefix}[{idx}]"
            yield from _iter_json_entries(item, key_name)
    else:
        yield prefix, str(value)


def _extract_comments(lines: List[str], ext: str) -> List[Tuple[int, str]]:
    comments: List[Tuple[int, str]] = []
    in_block = False
    block_start_line = 0
    block_buffer: List[str] = []

    for line_no, line in enumerate(lines, start=1):
        stripped = line.strip()
        if in_block:
            block_buffer.append(stripped)
            if "*/" in stripped or "-->" in stripped:
                comments.append((block_start_line, " ".join(block_buffer).replace("*/", "").replace("-->", "").strip()))
                in_block = False
                block_buffer.clear()
            continue

        if ext in {".cs", ".aspx", ".ascx", ".asmx", ".ashx", ".asax"}:
            if "/*" in stripped:
                in_block = True
                block_start_line = line_no
                block_buffer.append(stripped.split("/*", 1)[1])
                if "*/" in stripped:
                    in_block = False
                    comments.append((block_start_line, stripped.split("/*", 1)[1].split("*/", 1)[0].strip()))
                    block_buffer.clear()
                continue
            if stripped.startswith("//"):
                comments.append((line_no, stripped.lstrip("/").strip()))
                continue
            if "<!--" in stripped:
                in_block = True
                block_start_line = line_no
                block_buffer.append(stripped.split("<!--", 1)[1])
                if "-->" in stripped:
                    in_block = False
                    comments.append((block_start_line, stripped.split("<!--", 1)[1].split("-->", 1)[0].strip()))
                    block_buffer.clear()
                continue
        if ext in {".vb"}:
            if stripped.startswith("'"):
                comments.append((line_no, stripped.lstrip("'").strip()))
                continue
        if ext in {".yml", ".yaml", ".env", ".ini", ".toml"}:
            if stripped.startswith("#"):
                comments.append((line_no, stripped.lstrip("#").strip()))
                continue
        if ext in {".xml", ".config", ".wsdl", ".xsd"} and "<!--" in stripped:
            in_block = True
            block_start_line = line_no
            block_buffer.append(stripped.split("<!--", 1)[1])
            if "-->" in stripped:
                in_block = False
                comments.append((block_start_line, stripped.split("<!--", 1)[1].split("-->", 1)[0].strip()))
                block_buffer.clear()

    return comments[:MAX_COMMENTS_PER_FILE]


def _extract_identifiers(lines: List[str], ext: str) -> List[str]:
    tokens: Dict[str, int] = {}
    for line in lines:
        for token in IDENT_RE.findall(line):
            key = token.lower()
            if ext == ".cs" and key in CS_KEYWORDS:
                continue
            if ext == ".vb" and key in VB_KEYWORDS:
                continue
            tokens[key] = tokens.get(key, 0) + 1
    ranked = sorted(tokens.items(), key=lambda item: item[1], reverse=True)
    return [item[0] for item in ranked[:5]]


def _build_generated_summary(rel_path: str, ext: str, lines: List[str]) -> str:
    identifiers = _extract_identifiers(lines, ext)
    ident_text = ", ".join(identifiers) if identifiers else "none"
    return f"Auto-summary for {rel_path}: {len(lines)} lines, ext={ext}, identifiers={ident_text}."


def _iter_tree_nodes(node) -> Iterable[object]:
    yield node
    for child in node.children:
        yield from _iter_tree_nodes(child)


def _try_tree_sitter_entries(text: str, ext: str) -> List[Tuple[str, str]]:
    if not _TREE_SITTER_AVAILABLE:
        return []
    lang_map = {
        ".json": "json",
        ".yml": "yaml",
        ".yaml": "yaml",
        ".xml": "xml",
        ".config": "xml",
        ".wsdl": "xml",
        ".xsd": "xml",
    }
    language_name = lang_map.get(ext)
    if not language_name:
        return []
    try:
        language = get_language(language_name)
    except Exception:
        return []

    from tree_sitter import Parser  # type: ignore

    parser = Parser()
    parser.set_language(language)
    tree = parser.parse(bytes(text, "utf-8"))
    root = tree.root_node
    entries: List[Tuple[str, str]] = []

    if language_name == "json":
        for node in _iter_tree_nodes(root):
            if node.type == "pair":
                key_node = node.child_by_field_name("key")
                value_node = node.child_by_field_name("value")
                if key_node and value_node:
                    key_text = text[key_node.start_byte:key_node.end_byte].strip().strip('"')
                    value_text = text[value_node.start_byte:value_node.end_byte].strip().strip('"')
                    entries.append((key_text, value_text))
    elif language_name == "yaml":
        for node in _iter_tree_nodes(root):
            if node.type == "block_mapping_pair":
                key_node = node.child_by_field_name("key")
                value_node = node.child_by_field_name("value")
                if key_node and value_node:
                    key_text = text[key_node.start_byte:key_node.end_byte].strip()
                    value_text = text[value_node.start_byte:value_node.end_byte].strip()
                    entries.append((key_text, value_text))
    elif language_name == "xml":
        for node in _iter_tree_nodes(root):
            if node.type == "element":
                name_node = node.child_by_field_name("name")
                if name_node:
                    key_text = text[name_node.start_byte:name_node.end_byte].strip()
                    entries.append((key_text, "element"))
    return entries


def _parse_config_entries(lines: List[str], ext: str) -> List[Tuple[str, str]]:
    text = "\n".join(lines)
    entries = _try_tree_sitter_entries(text, ext)
    if entries:
        return entries
    parsed: List[Tuple[str, str]] = []
    if ext == ".json":
        try:
            payload = json.loads(text)
            return list(_iter_json_entries(payload))
        except json.JSONDecodeError:
            return []
    for line in lines:
        kv_match = PLAIN_KV_RE.match(line)
        if kv_match:
            parsed.append((kv_match.group(1), kv_match.group(2)))
    return parsed


def _sanitize_proc_name(name: str) -> str:
    return re.sub(r"[^A-Za-z0-9_.-]+", "_", name.strip()).strip("_")


def _extract_proc_blocks(lines: List[str]) -> List[Tuple[str, int, str]]:
    blocks: List[Tuple[str, int, str]] = []
    idx = 0
    while idx < len(lines):
        line = lines[idx]
        match = SQL_PROC_RE.search(line)
        if match:
            proc_name = match.group(1)
            start = idx
            end = idx
            for j in range(idx + 1, len(lines)):
                if lines[j].strip().upper() == "GO":
                    end = j
                    break
                end = j
            block_text = "\n".join(lines[start : end + 1])
            blocks.append((proc_name, start + 1, block_text))
            idx = end + 1
            continue
        idx += 1
    return blocks


def _write_proc_file(proc_name: str, rel_path: str, text: str) -> None:
    if not _STORED_PROC_DIR:
        return
    os.makedirs(_STORED_PROC_DIR, exist_ok=True)
    safe_name = _sanitize_proc_name(proc_name)
    suffix = make_id(rel_path, proc_name)[:8]
    filename = f"{safe_name}__{suffix}.sql"
    out_path = os.path.join(_STORED_PROC_DIR, filename)
    with open(out_path, "w", encoding="utf-8") as f:
        f.write(text)

def _process_file(args: Tuple[str, str]) -> Tuple[List[Dict[str, object]], List[Dict[str, object]], List[Dict[str, object]], List[Dict[str, object]]]:
    path, root = args
    rel_path = os.path.relpath(path, root)
    ext = os.path.splitext(path)[1].lower()
    project = get_project(rel_path)
    context = project

    file_id = make_id("file", rel_path)
    files_rows: List[Dict[str, object]] = [
        {
            "id": file_id,
            "path": rel_path,
            "type": "file",
            "ext": ext,
            "project": project,
            "context": context,
            "sourceLine": 0,
        }
    ]

    nodes_rows: List[Dict[str, object]] = [
        {
            "id": file_id,
            "type": "File",
            "name": os.path.basename(path),
            "path": rel_path,
            "ext": ext,
            "project": project,
            "context": context,
            "sourceFile": rel_path,
            "sourceLine": 1,
        }
    ]
    edges_rows: List[Dict[str, object]] = []

    lines = read_lines(path)
    content_for_vector = "\n".join(lines[:200])
    vector_rows: List[Dict[str, object]] = [
        {
            "id": file_id,
            "type": "File",
            "context": context,
            "sourceFile": rel_path,
            "sourceLine": 1,
            "vector": text_to_vector(content_for_vector, _get_model()),
        }
    ]

    proc_blocks = _extract_proc_blocks(lines)
    for proc_name, start_line, block_text in proc_blocks:
        proc_id = make_id("proc", rel_path, proc_name, str(start_line))
        nodes_rows.append(
            {
                "id": proc_id,
                "type": "StoredProcedure",
                "name": proc_name,
                "context": context,
                "sourceFile": rel_path,
                "sourceLine": start_line,
            }
        )
        edges_rows.append(
            {
                "id": make_id("edge", file_id, proc_id),
                "type": "DECLARES_PROC",
                "sourceId": file_id,
                "targetId": proc_id,
                "context": context,
            }
        )
        vector_rows.append(
            {
                "id": proc_id,
                "type": "StoredProcedure",
                "context": context,
                "sourceFile": rel_path,
                "sourceLine": start_line,
                "text": block_text,
                "procName": proc_name,
                "vector": text_to_vector(block_text, _get_model()),
            }
        )
        _write_proc_file(proc_name, rel_path, block_text)

    comments = _extract_comments(lines, ext)
    for line_no, comment in comments:
        if not comment:
            continue
        comment_id = make_id("comment", rel_path, str(line_no), comment)
        vector_rows.append(
            {
                "id": comment_id,
                "type": "Comment",
                "context": context,
                "sourceFile": rel_path,
                "sourceLine": line_no,
                "text": comment,
                "commentKind": "source",
                "vector": text_to_vector(comment, _get_model()),
            }
        )

    generated_summary = ""
    generated_source = "llm"
    if _SUMMARY_MODE == "llm":
        try:
            generated_summary = _llm_summary(rel_path, ext, "\n".join(lines))
        except Exception as exc:
            logging.error("LLM summary failed file=%s error=%s", rel_path, exc)
            raise

    if generated_summary:
        summary_id = make_id("generated-comment", rel_path)
        vector_rows.append(
            {
                "id": summary_id,
                "type": "GeneratedComment",
                "context": context,
                "sourceFile": rel_path,
                "sourceLine": 1,
                "text": generated_summary,
                "commentKind": "generated",
                "generatedSource": generated_source,
                "vector": text_to_vector(generated_summary, _get_model()),
            }
        )

    if ext in {".config", ".xml"}:
        for line_no, line in enumerate(lines, start=1):
            for m in SQL_PROC_RE.finditer(line):
                proc_name = m.group(1)
                proc_id = make_id("proc", rel_path, proc_name, str(line_no))
                nodes_rows.append(
                    {
                        "id": proc_id,
                        "type": "StoredProcedure",
                        "name": proc_name,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, proc_id),
                        "type": "DECLARES_PROC",
                        "sourceId": file_id,
                        "targetId": proc_id,
                        "context": context,
                    }
                )
            for m in SQL_EXEC_RE.finditer(line):
                proc_name = m.group(1)
                proc_id = make_id("proc", rel_path, proc_name, str(line_no))
                nodes_rows.append(
                    {
                        "id": proc_id,
                        "type": "StoredProcedure",
                        "name": proc_name,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, proc_id),
                        "type": "EXECUTES_PROC",
                        "sourceId": file_id,
                        "targetId": proc_id,
                        "context": context,
                    }
                )

    if ext in {".cs", ".vb"} and _ROSLYN_INDEX is not None:
        roslyn_entry = _ROSLYN_INDEX.get(rel_path)
        if roslyn_entry:
            nodes_rows.extend(roslyn_entry.get("nodes", []))
            edges_rows.extend(roslyn_entry.get("edges", []))
            return nodes_rows, edges_rows, files_rows, vector_rows
        global _ROSLYN_WARNED
        if not _ROSLYN_WARNED:
            logging.warning("Roslyn index missing entries for C#/VB files; using regex fallback.")
            _ROSLYN_WARNED = True
        if _ROSLYN_MISSING_LOG and rel_path not in _ROSLYN_MISSING_SEEN:
            _ROSLYN_MISSING_SEEN.add(rel_path)
            try:
                with open(_ROSLYN_MISSING_LOG, "a", encoding="utf-8") as f:
                    f.write(rel_path + "\n")
            except OSError:
                pass

    soap_service_key: Optional[str] = None
    wcf_service_key: Optional[str] = None

    if ext == ".cs":
        seen_linq: set[str] = set()
        seen_orm: set[str] = set()
        seen_proc: set[str] = set()
        pending_soap_service = False
        pending_soap_method = False
        pending_wcf_service = False
        pending_wcf_method = False
        for line_no, line in enumerate(lines, start=1):
            if ASMX_WEBSERVICE_RE.search(line):
                pending_soap_service = True
            if ASMX_WEBMETHOD_RE.search(line):
                pending_soap_method = True
            if WCF_SERVICE_CONTRACT_RE.search(line):
                pending_wcf_service = True
            if WCF_OPERATION_CONTRACT_RE.search(line):
                pending_wcf_method = True
            m_type = CS_TYPE_RE.match(line)
            if m_type:
                type_kind = m_type.group(2)
                type_name = m_type.group(3)
                type_id = make_id("type", rel_path, type_name, str(line_no))
                nodes_rows.append(
                    {
                        "id": type_id,
                        "type": type_kind.capitalize(),
                        "name": type_name,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, type_id),
                        "type": "CONTAINS",
                        "sourceId": file_id,
                        "targetId": type_id,
                        "context": context,
                    }
                )
                if pending_soap_service:
                    soap_service_key = f"{rel_path}:{type_name}"
                    service_id = make_id("soap-service", soap_service_key)
                    nodes_rows.append(
                        {
                            "id": service_id,
                            "type": "SoapEndpoint",
                            "name": type_name,
                            "context": context,
                            "sourceFile": rel_path,
                            "sourceLine": line_no,
                        }
                    )
                    edges_rows.append(
                        {
                            "id": make_id("edge", service_id, type_id),
                            "type": "SOAP_ENDPOINT_HANDLED_BY",
                            "sourceId": service_id,
                            "targetId": type_id,
                            "context": context,
                        }
                    )
                    pending_soap_service = False
                if pending_wcf_service:
                    wcf_service_key = f"{rel_path}:{type_name}"
                    service_id = make_id("wcf-service", wcf_service_key)
                    nodes_rows.append(
                        {
                            "id": service_id,
                            "type": "WcfService",
                            "name": type_name,
                            "context": context,
                            "sourceFile": rel_path,
                            "sourceLine": line_no,
                        }
                    )
                    edges_rows.append(
                        {
                            "id": make_id("edge", service_id, type_id),
                            "type": "WCF_SERVICE_HANDLED_BY",
                            "sourceId": service_id,
                            "targetId": type_id,
                            "context": context,
                        }
                    )
                    pending_wcf_service = False
                continue
            m_method = CS_METHOD_RE.match(line)
            if m_method:
                method_name = m_method.group(3)
                method_id = make_id("method", rel_path, method_name, str(line_no))
                nodes_rows.append(
                    {
                        "id": method_id,
                        "type": "Method",
                        "name": method_name,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, method_id),
                        "type": "CONTAINS",
                        "sourceId": file_id,
                        "targetId": method_id,
                        "context": context,
                    }
                )
                if pending_soap_method:
                    op_id = make_id("soap-method", rel_path, method_name, str(line_no))
                    nodes_rows.append(
                        {
                            "id": op_id,
                            "type": "SoapOperation",
                            "name": method_name,
                            "context": context,
                            "sourceFile": rel_path,
                            "sourceLine": line_no,
                        }
                    )
                    edges_rows.append(
                        {
                            "id": make_id("edge", method_id, op_id),
                            "type": "SOAP_OPERATION",
                            "sourceId": method_id,
                            "targetId": op_id,
                            "context": context,
                        }
                    )
                    pending_soap_method = False
                if pending_wcf_method:
                    op_id = make_id("wcf-method", rel_path, method_name, str(line_no))
                    nodes_rows.append(
                        {
                            "id": op_id,
                            "type": "WcfOperation",
                            "name": method_name,
                            "context": context,
                            "sourceFile": rel_path,
                            "sourceLine": line_no,
                        }
                    )
                    edges_rows.append(
                        {
                            "id": make_id("edge", method_id, op_id),
                            "type": "WCF_OPERATION",
                            "sourceId": method_id,
                            "targetId": op_id,
                            "context": context,
                        }
                    )
                    pending_wcf_method = False
            for method in LINQ_METHODS:
                if f".{method}(" in line or line.strip().startswith("from "):
                    linq_id = make_id("linq", rel_path, method, str(line_no))
                    if linq_id not in seen_linq:
                        seen_linq.add(linq_id)
                        nodes_rows.append(
                            {
                                "id": linq_id,
                                "type": "LinqQuery",
                                "name": method,
                                "context": context,
                                "sourceFile": rel_path,
                                "sourceLine": line_no,
                            }
                        )
                        edges_rows.append(
                            {
                                "id": make_id("edge", file_id, linq_id),
                                "type": "USES_LINQ",
                                "sourceId": file_id,
                                "targetId": linq_id,
                                "context": context,
                            }
                        )
            for method in ORM_METHODS:
                if f".{method}(" in line:
                    orm_id = make_id("orm", rel_path, method, str(line_no))
                    if orm_id not in seen_orm:
                        seen_orm.add(orm_id)
                        nodes_rows.append(
                            {
                                "id": orm_id,
                                "type": "OrmUsage",
                                "name": method,
                                "context": context,
                                "sourceFile": rel_path,
                                "sourceLine": line_no,
                            }
                        )
                        edges_rows.append(
                            {
                                "id": make_id("edge", file_id, orm_id),
                                "type": "USES_ORM",
                                "sourceId": file_id,
                                "targetId": orm_id,
                                "context": context,
                            }
                        )
            for ident in ORM_IDENTIFIERS:
                if ident in line:
                    orm_id = make_id("orm", rel_path, ident, str(line_no))
                    if orm_id not in seen_orm:
                        seen_orm.add(orm_id)
                        nodes_rows.append(
                            {
                                "id": orm_id,
                                "type": "OrmUsage",
                                "name": ident,
                                "context": context,
                                "sourceFile": rel_path,
                                "sourceLine": line_no,
                            }
                        )
                        edges_rows.append(
                            {
                                "id": make_id("edge", file_id, orm_id),
                                "type": "USES_ORM",
                                "sourceId": file_id,
                                "targetId": orm_id,
                                "context": context,
                            }
                        )
            for m in SQL_EXEC_RE.finditer(line):
                proc_name = m.group(1)
                proc_id = make_id("proc", rel_path, proc_name, str(line_no))
                if proc_id in seen_proc:
                    continue
                seen_proc.add(proc_id)
                nodes_rows.append(
                    {
                        "id": proc_id,
                        "type": "StoredProcedure",
                        "name": proc_name,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, proc_id),
                        "type": "EXECUTES_PROC",
                        "sourceId": file_id,
                        "targetId": proc_id,
                        "context": context,
                    }
                )
    elif ext == ".vb":
        # VB parsing remains regex-based if Roslyn index is missing.
        pending_soap_service = False
        pending_soap_method = False
        pending_wcf_service = False
        pending_wcf_method = False
        for line_no, line in enumerate(lines, start=1):
            if VB_WEBSERVICE_RE.search(line):
                pending_soap_service = True
            if VB_WEBMETHOD_RE.search(line):
                pending_soap_method = True
            if VB_SERVICE_CONTRACT_RE.search(line):
                pending_wcf_service = True
            if VB_OPERATION_CONTRACT_RE.search(line):
                pending_wcf_method = True
            m_type = VB_TYPE_RE.match(line)
            if m_type:
                type_kind = m_type.group(2)
                type_name = m_type.group(3)
                type_id = make_id("type", rel_path, type_name, str(line_no))
                nodes_rows.append(
                    {
                        "id": type_id,
                        "type": type_kind.capitalize(),
                        "name": type_name,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, type_id),
                        "type": "CONTAINS",
                        "sourceId": file_id,
                        "targetId": type_id,
                        "context": context,
                    }
                )
                if pending_soap_service:
                    soap_service_key = f"{rel_path}:{type_name}"
                    service_id = make_id("soap-service", soap_service_key)
                    nodes_rows.append(
                        {
                            "id": service_id,
                            "type": "SoapEndpoint",
                            "name": type_name,
                            "context": context,
                            "sourceFile": rel_path,
                            "sourceLine": line_no,
                        }
                    )
                    edges_rows.append(
                        {
                            "id": make_id("edge", service_id, type_id),
                            "type": "SOAP_ENDPOINT_HANDLED_BY",
                            "sourceId": service_id,
                            "targetId": type_id,
                            "context": context,
                        }
                    )
                    pending_soap_service = False
                if pending_wcf_service:
                    wcf_service_key = f"{rel_path}:{type_name}"
                    service_id = make_id("wcf-service", wcf_service_key)
                    nodes_rows.append(
                        {
                            "id": service_id,
                            "type": "WcfService",
                            "name": type_name,
                            "context": context,
                            "sourceFile": rel_path,
                            "sourceLine": line_no,
                        }
                    )
                    edges_rows.append(
                        {
                            "id": make_id("edge", service_id, type_id),
                            "type": "WCF_SERVICE_HANDLED_BY",
                            "sourceId": service_id,
                            "targetId": type_id,
                            "context": context,
                        }
                    )
                    pending_wcf_service = False
                continue
            m_method = VB_METHOD_RE.match(line)
            if m_method:
                method_name = m_method.group(3)
                method_id = make_id("method", rel_path, method_name, str(line_no))
                nodes_rows.append(
                    {
                        "id": method_id,
                        "type": "Method",
                        "name": method_name,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, method_id),
                        "type": "CONTAINS",
                        "sourceId": file_id,
                        "targetId": method_id,
                        "context": context,
                    }
                )
                if pending_soap_method:
                    op_id = make_id("soap-method", rel_path, method_name, str(line_no))
                    nodes_rows.append(
                        {
                            "id": op_id,
                            "type": "SoapOperation",
                            "name": method_name,
                            "context": context,
                            "sourceFile": rel_path,
                            "sourceLine": line_no,
                        }
                    )
                    edges_rows.append(
                        {
                            "id": make_id("edge", method_id, op_id),
                            "type": "SOAP_OPERATION",
                            "sourceId": method_id,
                            "targetId": op_id,
                            "context": context,
                        }
                    )
                    pending_soap_method = False
                if pending_wcf_method:
                    op_id = make_id("wcf-method", rel_path, method_name, str(line_no))
                    nodes_rows.append(
                        {
                            "id": op_id,
                            "type": "WcfOperation",
                            "name": method_name,
                            "context": context,
                            "sourceFile": rel_path,
                            "sourceLine": line_no,
                        }
                    )
                    edges_rows.append(
                        {
                            "id": make_id("edge", method_id, op_id),
                            "type": "WCF_OPERATION",
                            "sourceId": method_id,
                            "targetId": op_id,
                            "context": context,
                        }
                    )
                    pending_wcf_method = False
    elif ext in {".aspx", ".ascx"}:
        entry_id = make_id("entrypoint", rel_path)
        nodes_rows.append(
            {
                "id": entry_id,
                "type": "Entrypoint",
                "name": os.path.basename(path),
                "context": context,
                "sourceFile": rel_path,
                "sourceLine": 1,
                "entryKind": "frontend",
            }
        )
        edges_rows.append(
            {
                "id": make_id("edge", file_id, entry_id),
                "type": "HAS_ENTRYPOINT",
                "sourceId": file_id,
                "targetId": entry_id,
                "context": context,
            }
        )
        for line_no, line in enumerate(lines, start=1):
            if ASPX_PAGE_RE.search(line):
                page_name = os.path.basename(path)
                page_id = make_id("page", rel_path, str(line_no))
                nodes_rows.append(
                    {
                        "id": page_id,
                        "type": "Page",
                        "name": page_name,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, page_id),
                        "type": "CONTAINS",
                        "sourceId": file_id,
                        "targetId": page_id,
                        "context": context,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", entry_id, page_id),
                        "type": "ENTRYPOINT_PAGE",
                        "sourceId": entry_id,
                        "targetId": page_id,
                        "context": context,
                    }
                )
                inherits = ASPX_INHERITS_RE.search(line)
                if inherits:
                    codebehind = inherits.group(1)
                    cb_id = make_id("type", rel_path, codebehind, str(line_no))
                    nodes_rows.append(
                        {
                            "id": cb_id,
                            "type": "Class",
                            "name": codebehind,
                            "context": context,
                            "sourceFile": rel_path,
                            "sourceLine": line_no,
                        }
                    )
                    edges_rows.append(
                        {
                            "id": make_id("edge", page_id, cb_id),
                            "type": "CODEBEHIND",
                            "sourceId": page_id,
                            "targetId": cb_id,
                            "context": context,
                        }
                    )
                    edges_rows.append(
                        {
                            "id": make_id("edge", entry_id, cb_id),
                            "type": "FRONTEND_HANDLED_BY",
                            "sourceId": entry_id,
                            "targetId": cb_id,
                            "context": context,
                        }
                    )
                break
    elif ext in {".cshtml", ".asax"}:
        entry_id = make_id("entrypoint", rel_path)
        nodes_rows.append(
            {
                "id": entry_id,
                "type": "Entrypoint",
                "name": os.path.basename(path),
                "context": context,
                "sourceFile": rel_path,
                "sourceLine": 1,
                "entryKind": "frontend",
            }
        )
        edges_rows.append(
            {
                "id": make_id("edge", file_id, entry_id),
                "type": "HAS_ENTRYPOINT",
                "sourceId": file_id,
                "targetId": entry_id,
                "context": context,
            }
        )
        for line_no, line in enumerate(lines, start=1):
            inherits = ASPX_INHERITS_RE.search(line)
            if inherits:
                codebehind = inherits.group(1)
                cb_id = make_id("type", rel_path, codebehind, str(line_no))
                nodes_rows.append(
                    {
                        "id": cb_id,
                        "type": "Class",
                        "name": codebehind,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", entry_id, cb_id),
                        "type": "FRONTEND_HANDLED_BY",
                        "sourceId": entry_id,
                        "targetId": cb_id,
                        "context": context,
                    }
                )
                break
    elif ext in {".ashx", ".asmx", ".svc"}:
        entry_id = make_id("entrypoint", rel_path)
        entry_kind = "api"
        if ext == ".asmx":
            entry_kind = "soap"
        elif ext == ".svc":
            entry_kind = "wcf"
        nodes_rows.append(
            {
                "id": entry_id,
                "type": "Entrypoint",
                "name": os.path.basename(path),
                "context": context,
                "sourceFile": rel_path,
                "sourceLine": 1,
                "entryKind": entry_kind,
            }
        )
        edges_rows.append(
            {
                "id": make_id("edge", file_id, entry_id),
                "type": "HAS_ENTRYPOINT",
                "sourceId": file_id,
                "targetId": entry_id,
                "context": context,
            }
        )
        if entry_kind == "soap":
            service_key = soap_service_key or f"{rel_path}:service"
            service_id = make_id("soap-service", service_key)
            nodes_rows.append(
                {
                    "id": service_id,
                    "type": "SoapEndpoint",
                    "name": os.path.basename(path),
                    "context": context,
                    "sourceFile": rel_path,
                    "sourceLine": 1,
                    "serviceKey": service_key,
                }
            )
            edges_rows.append(
                {
                    "id": make_id("edge", entry_id, service_id),
                    "type": "ENTRYPOINT_SERVICE",
                    "sourceId": entry_id,
                    "targetId": service_id,
                    "context": context,
                }
            )
        if entry_kind == "wcf":
            service_key = wcf_service_key or f"{rel_path}:service"
            service_id = make_id("wcf-service", service_key)
            nodes_rows.append(
                {
                    "id": service_id,
                    "type": "WcfService",
                    "name": os.path.basename(path),
                    "context": context,
                    "sourceFile": rel_path,
                    "sourceLine": 1,
                    "serviceKey": service_key,
                }
            )
            edges_rows.append(
                {
                    "id": make_id("edge", entry_id, service_id),
                    "type": "ENTRYPOINT_SERVICE",
                    "sourceId": entry_id,
                    "targetId": service_id,
                    "context": context,
                }
            )
    else:
        if ext == ".wsdl":
            if not _has_local_service(rel_path):
                entry_id = make_id("entrypoint", rel_path)
                service_id = make_id("external-service", rel_path)
                nodes_rows.append(
                    {
                        "id": entry_id,
                        "type": "Entrypoint",
                        "name": os.path.basename(path),
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": 1,
                        "entryKind": "external",
                        "attributes": json.dumps({"wsdl": rel_path, "external": True}, ensure_ascii=True),
                    }
                )
                nodes_rows.append(
                    {
                        "id": service_id,
                        "type": "ExternalService",
                        "name": os.path.basename(path),
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": 1,
                        "attributes": json.dumps({"wsdl": rel_path, "external": True}, ensure_ascii=True),
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, entry_id),
                        "type": "HAS_ENTRYPOINT",
                        "sourceId": file_id,
                        "targetId": entry_id,
                        "context": context,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", entry_id, service_id),
                        "type": "ENTRYPOINT_SERVICE",
                        "sourceId": entry_id,
                        "targetId": service_id,
                        "context": context,
                    }
                )
                vector_rows.append(
                    {
                        "id": service_id,
                        "type": "ExternalService",
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": 1,
                        "text": f"External WSDL service: {rel_path}",
                        "vector": text_to_vector(f"External WSDL service {rel_path}", _get_model()),
                    }
                )

        if ext in CONFIG_EXTS:
            entries = _parse_config_entries(lines, ext)
            for key, value in entries:
                if not key:
                    continue
                entry_id = make_id("plain", rel_path, key)
                nodes_rows.append(
                    {
                        "id": entry_id,
                        "type": "ConfigEntry",
                        "name": key,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": 1,
                        "attributes": json.dumps({"value": value}, ensure_ascii=True),
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, entry_id),
                        "type": "DECLARES_ENTRY",
                        "sourceId": file_id,
                        "targetId": entry_id,
                        "context": context,
                    }
                )

        for line_no, line in enumerate(lines, start=1):
            for m in SQL_PROC_RE.finditer(line):
                proc_name = m.group(1)
                proc_id = make_id("proc", rel_path, proc_name, str(line_no))
                nodes_rows.append(
                    {
                        "id": proc_id,
                        "type": "StoredProcedure",
                        "name": proc_name,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, proc_id),
                        "type": "DECLARES_PROC",
                        "sourceId": file_id,
                        "targetId": proc_id,
                        "context": context,
                    }
                )
            for m in SQL_EXEC_RE.finditer(line):
                proc_name = m.group(1)
                proc_id = make_id("proc", rel_path, proc_name, str(line_no))
                nodes_rows.append(
                    {
                        "id": proc_id,
                        "type": "StoredProcedure",
                        "name": proc_name,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, proc_id),
                        "type": "EXECUTES_PROC",
                        "sourceId": file_id,
                        "targetId": proc_id,
                        "context": context,
                    }
                )
            kv_match = PLAIN_KV_RE.match(line)
            if kv_match:
                key = kv_match.group(1)
                value = kv_match.group(2)
                entry_id = make_id("plain", rel_path, key, str(line_no))
                nodes_rows.append(
                    {
                        "id": entry_id,
                        "type": "ConfigEntry",
                        "name": key,
                        "context": context,
                        "sourceFile": rel_path,
                        "sourceLine": line_no,
                        "attributes": json.dumps({"value": value}, ensure_ascii=True),
                    }
                )
                edges_rows.append(
                    {
                        "id": make_id("edge", file_id, entry_id),
                        "type": "DECLARES_ENTRY",
                        "sourceId": file_id,
                        "targetId": entry_id,
                        "context": context,
                    }
                )

    for node in nodes_rows:
        node.setdefault("entryKind", "")
    return nodes_rows, edges_rows, files_rows, vector_rows


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("--root", default=r"D:\code\migration\code")
    parser.add_argument("--out", default=r"c:\Users\shara\code\migration\workspace\data\parquet")
    parser.add_argument("--state-file", default=r"c:\Users\shara\code\migration\workspace\state\ingest_state.json")
    parser.add_argument("--max-files", type=int, default=1000)
    parser.add_argument("--batch-size", type=int, default=200)
    parser.add_argument("--embedding-model", default="sentence-transformers/all-MiniLM-L6-v2")
    parser.add_argument("--workers", type=int, default=max(1, (os.cpu_count() or 2) - 1))
    parser.add_argument("--chunksize", type=int, default=10)
    parser.add_argument("--roslyn-index", default=r"c:\Users\shara\code\migration\workspace\data\roslyn\roslyn.jsonl")
    parser.add_argument("--roslyn-missing-log", default=r"c:\Users\shara\code\migration\workspace\state\roslyn_missing.txt")
    parser.add_argument("--summary-mode", choices=["llm", "none"], default="none")
    parser.add_argument("--llm-provider", choices=["openai", "claude", "gemini"], default=os.environ.get("LLM_PROVIDER", "openai"))
    parser.add_argument("--llm-api-base", default=os.environ.get("LLM_API_BASE", ""))
    parser.add_argument("--llm-api-key", default=os.environ.get("LLM_API_KEY", ""))
    parser.add_argument("--llm-model", default=os.environ.get("LLM_MODEL", ""))
    parser.add_argument("--summary-max-chars", type=int, default=8000)
    parser.add_argument("--summary-timeout", type=int, default=30)
    parser.add_argument("--summary-system-prompt", default=r"c:\Users\shara\code\migration\workspace\prompts\summary-system.md")
    parser.add_argument("--summary-user-prompt", default=r"c:\Users\shara\code\migration\workspace\prompts\summary-user.md")
    parser.add_argument("--stored-proc-dir", default=r"c:\Users\shara\code\migration\workspace\data\stored_procs")
    parser.add_argument("--progress-every", type=int, default=25)
    args = parser.parse_args()

    logging.basicConfig(level=logging.INFO, format="%(asctime)s %(levelname)s %(message)s")
    logging.info(
        "Starting ingestion root=%s out=%s max_files=%s batch_size=%s model=%s workers=%s chunksize=%s",
        args.root,
        args.out,
        args.max_files,
        args.batch_size,
        args.embedding_model,
        args.workers,
        args.chunksize,
    )
    logging.info("Preloading embedding model to avoid concurrent downloads in workers")
    _init_model(args.embedding_model)
    logging.info("Using Roslyn index for C# and VB parsing")
    logging.info("Summary mode=%s", args.summary_mode)
    if args.workers < 1:
        raise ValueError("workers must be >= 1")
    if not os.path.exists(args.roslyn_index) or os.path.getsize(args.roslyn_index) == 0:
        logging.error("Roslyn index is missing or empty: %s", args.roslyn_index)
        raise SystemExit(1)
    if args.summary_mode == "llm":
        if not args.llm_api_base or not args.llm_api_key or not args.llm_model:
            logging.warning("LLM config missing; generated summaries are disabled")
            args.summary_mode = "none"

    try:
        files = list_files(args.root)
        all_files = {os.path.relpath(p, args.root).lower() for p in files}
        state = load_state(args.state_file)
        start = state.get("index", 0)
        end = min(start + args.max_files, len(files))

        logging.info("Discovered %s files, processing range [%s, %s)", len(files), start, end)
        save_state(args.state_file, start, processed=0, total=len(files), start=start, end=end, status="running")

        nodes_rows: List[Dict[str, object]] = []
        edges_rows: List[Dict[str, object]] = []
        files_rows: List[Dict[str, object]] = []
        vector_rows: List[Dict[str, object]] = []
        file_slice = files[start:end]
        processed = 0
        ctx = mp.get_context("spawn")
        with ctx.Pool(
            processes=args.workers,
            initializer=_init_all_worker,
            initargs=(
                args.embedding_model,
                args.roslyn_index,
                args.roslyn_missing_log,
                all_files,
                args.summary_mode,
                args.llm_api_base,
                args.llm_api_key,
                args.llm_model,
                args.llm_provider,
                args.summary_max_chars,
                args.summary_timeout,
                args.summary_system_prompt,
                args.summary_user_prompt,
                args.stored_proc_dir,
            ),
        ) as pool:
            for node_rows, edge_rows, file_rows, vec_rows in pool.imap_unordered(
                _process_file,
                [(path, args.root) for path in file_slice],
                chunksize=args.chunksize,
            ):
                nodes_rows.extend(node_rows)
                edges_rows.extend(edge_rows)
                files_rows.extend(file_rows)
                vector_rows.extend(vec_rows)
                processed += 1

                if args.progress_every > 0 and processed % args.progress_every == 0:
                    save_state(
                        args.state_file,
                        start + processed,
                        processed=processed,
                        total=len(files),
                        start=start,
                        end=end,
                        status="running",
                    )

                if len(nodes_rows) >= args.batch_size:
                    logging.info(
                        "Writing batch processed=%s nodes=%s edges=%s files=%s vectors=%s",
                        processed,
                        len(nodes_rows),
                        len(edges_rows),
                        len(files_rows),
                        len(vector_rows),
                    )
                    write_dataset(nodes_rows, os.path.join(args.out, "nodes"), ["context", "type"], "nodes")
                    write_dataset(edges_rows, os.path.join(args.out, "edges"), ["context", "type"], "edges")
                    write_dataset(files_rows, os.path.join(args.out, "files"), ["context", "ext"], "files")
                    write_dataset(vector_rows, os.path.join(args.out, "vectors"), ["context", "type"], "vectors")
                    nodes_rows.clear()
                    edges_rows.clear()
                    files_rows.clear()
                    vector_rows.clear()
                    save_state(
                        args.state_file,
                        start + processed,
                        processed=processed,
                        total=len(files),
                        start=start,
                        end=end,
                        status="running",
                    )

        if nodes_rows or edges_rows or files_rows or vector_rows:
            logging.info("Writing final batch nodes=%s edges=%s files=%s vectors=%s", len(nodes_rows), len(edges_rows), len(files_rows), len(vector_rows))
            write_dataset(nodes_rows, os.path.join(args.out, "nodes"), ["context", "type"], "nodes")
            write_dataset(edges_rows, os.path.join(args.out, "edges"), ["context", "type"], "edges")
            write_dataset(files_rows, os.path.join(args.out, "files"), ["context", "ext"], "files")
            write_dataset(vector_rows, os.path.join(args.out, "vectors"), ["context", "type"], "vectors")
            save_state(args.state_file, end, processed=processed, total=len(files), start=start, end=end, status="complete")

        logging.info("Ingestion complete index=%s", end)
    except KeyboardInterrupt:
        save_state(args.state_file, start + processed, processed=processed, total=len(files), start=start, end=end, status="interrupted")
        logging.error("Ingestion interrupted by user; notify and resume from state file.")
        raise


if __name__ == "__main__":
    main()
