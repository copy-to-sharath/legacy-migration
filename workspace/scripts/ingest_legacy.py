import argparse
import hashlib
import json
import logging
import os
import re
import time
import uuid
from typing import Dict, List, Tuple, Optional, Iterable
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
    ".config",
    ".xml",
    ".resx",
    ".json",
}


CS_TYPE_RE = re.compile(r"^\s*(public|private|protected|internal|static|partial|\s)+\s*(class|interface|struct|enum)\s+(\w+)", re.IGNORECASE)
CS_METHOD_RE = re.compile(r"^\s*(public|private|protected|internal|static|virtual|override|sealed|async|new|abstract|partial|\s)+\s*([\w<>\[\],\s]+)\s+(\w+)\s*\(", re.IGNORECASE)

VB_TYPE_RE = re.compile(r"^\s*(public|private|protected|friend|shared|partial|\s)*\s*(class|interface|structure|enum)\s+(\w+)", re.IGNORECASE)
VB_METHOD_RE = re.compile(r"^\s*(public|private|protected|friend|shared|overridable|overrides|async|\s)*\s*(function|sub)\s+(\w+)\s*\(", re.IGNORECASE)

ASPX_PAGE_RE = re.compile(r"<%@\s*Page[^>]*%>", re.IGNORECASE)
ASPX_INHERITS_RE = re.compile(r"Inherits\\s*=\\s*\"([^\"]+)\"", re.IGNORECASE)
SQL_PROC_RE = re.compile(r"\b(?:CREATE|ALTER)\s+PROC(?:EDURE)?\s+([\[\]\w\.]+)", re.IGNORECASE)
SQL_EXEC_RE = re.compile(r"\bEXEC(?:UTE)?\s+([\[\]\w\.]+)", re.IGNORECASE)

_MODEL: Optional[SentenceTransformer] = None
_ROSLYN_INDEX: Optional[Dict[str, Dict[str, List[Dict[str, object]]]]] = None
_ROSLYN_WARNED = False
_ROSLYN_MISSING_LOG: Optional[str] = None
_ROSLYN_MISSING_SEEN: set[str] = set()


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


def save_state(state_file: str, index: int) -> None:
    state = {"index": index, "updated": time.strftime("%Y-%m-%dT%H:%M:%SZ", time.gmtime())}
    with open(state_file, "w", encoding="utf-8") as f:
        json.dump(state, f, indent=2)


def _init_model(model_name: str) -> None:
    global _MODEL
    _MODEL = SentenceTransformer(model_name)


def _init_worker(model_name: str, roslyn_index: str, roslyn_missing_log: str) -> None:
    _init_model(model_name)
    _init_roslyn_index(roslyn_index)
    global _ROSLYN_MISSING_LOG
    _ROSLYN_MISSING_LOG = roslyn_missing_log


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

    if ext == ".cs":
        seen_linq: set[str] = set()
        seen_orm: set[str] = set()
        seen_proc: set[str] = set()
        for line_no, line in enumerate(lines, start=1):
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
        for line_no, line in enumerate(lines, start=1):
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
    elif ext in {".aspx", ".ascx"}:
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
                break
    else:
        if ext == ".json":
            try:
                payload = json.loads("\n".join(lines))
                for key, value in _iter_json_entries(payload):
                    if not key:
                        continue
                    entry_id = make_id("plain", rel_path, key)
                    nodes_rows.append(
                        {
                            "id": entry_id,
                            "type": "PlainEntry",
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
            except json.JSONDecodeError:
                pass

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
                        "type": "PlainEntry",
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
    logging.info("Using Roslyn index for C# and VB parsing")
    if args.workers < 1:
        raise ValueError("workers must be >= 1")
    if not os.path.exists(args.roslyn_index) or os.path.getsize(args.roslyn_index) == 0:
        logging.error("Roslyn index is missing or empty: %s", args.roslyn_index)
        raise SystemExit(1)

    try:
        files = list_files(args.root)
        state = load_state(args.state_file)
        start = state.get("index", 0)
        end = min(start + args.max_files, len(files))

        logging.info("Discovered %s files, processing range [%s, %s)", len(files), start, end)

        nodes_rows: List[Dict[str, object]] = []
        edges_rows: List[Dict[str, object]] = []
        files_rows: List[Dict[str, object]] = []
        vector_rows: List[Dict[str, object]] = []
        file_slice = files[start:end]
        processed = 0
        ctx = mp.get_context("spawn")
        with ctx.Pool(processes=args.workers, initializer=_init_worker, initargs=(args.embedding_model, args.roslyn_index, args.roslyn_missing_log)) as pool:
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
                    save_state(args.state_file, start + processed)

        if nodes_rows or edges_rows or files_rows or vector_rows:
            logging.info("Writing final batch nodes=%s edges=%s files=%s vectors=%s", len(nodes_rows), len(edges_rows), len(files_rows), len(vector_rows))
            write_dataset(nodes_rows, os.path.join(args.out, "nodes"), ["context", "type"], "nodes")
            write_dataset(edges_rows, os.path.join(args.out, "edges"), ["context", "type"], "edges")
            write_dataset(files_rows, os.path.join(args.out, "files"), ["context", "ext"], "files")
            write_dataset(vector_rows, os.path.join(args.out, "vectors"), ["context", "type"], "vectors")
            save_state(args.state_file, end)

        logging.info("Ingestion complete index=%s", end)
    except KeyboardInterrupt:
        logging.error("Ingestion interrupted by user; notify and resume from state file.")
        raise


if __name__ == "__main__":
    main()
