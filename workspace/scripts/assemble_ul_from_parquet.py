import argparse
import logging
from pathlib import Path

from collections import OrderedDict

import pyarrow.dataset as ds


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument(
        "--parquet-root",
        default=r"c:\Users\shara\code\migration\workspace\deliverables\generated\ul-parquet\ul-sections",
    )
    parser.add_argument(
        "--output",
        default=r"c:\Users\shara\code\migration\workspace\deliverables\generated\ubiquitous-language.md",
    )
    args = parser.parse_args()

    logging.basicConfig(level=logging.INFO, format="%(asctime)s %(levelname)s %(message)s")
    logging.info("Assembling UL markdown from parquet_root=%s", args.parquet_root)

    parquet_root = Path(args.parquet_root)
    parquet_files = list(parquet_root.rglob("*.parquet"))
    if not parquet_files:
        raise SystemExit(f"No Parquet files found under {parquet_root}")

    dataset = ds.dataset(parquet_files, format="parquet", partitioning="hive")
    required = ["batch_id", "section", "subsection", "content"]
    available = set(dataset.schema.names)
    missing = [name for name in required if name not in available]
    if missing:
        raise SystemExit(
            "UL Parquet schema missing required columns: "
            f"{', '.join(missing)}. Available columns: {', '.join(dataset.schema.names)}"
        )

    table = dataset.to_table(columns=required)
    rows = table.to_pylist()

    rows.sort(key=lambda row: (row.get("section") or "", row.get("batch_id") or ""))

    def _normalize_content(value: str) -> str:
        normalized = "\n".join(line.rstrip() for line in value.strip().splitlines())
        while "\n\n\n" in normalized:
            normalized = normalized.replace("\n\n\n", "\n\n")
        return normalized

    def _shift_headings(value: str, increment: int) -> str:
        shifted: list[str] = []
        for line in value.splitlines():
            if line.startswith("#"):
                count = len(line) - len(line.lstrip("#"))
                rest = line[count:]
                shifted.append("#" * (count + increment) + rest)
            else:
                shifted.append(line)
        return "\n".join(shifted)

    def _parse_sections(content: str) -> tuple[str, OrderedDict[str, list[str]]]:
        lines = content.splitlines()
        module_title = None
        sections: OrderedDict[str, list[str]] = OrderedDict()
        current_section = None
        buffer: list[str] = []
        for line in lines:
            stripped = line.strip()
            if stripped.startswith("# "):
                if module_title is None:
                    module_title = stripped[2:].strip()
                continue
            if stripped.startswith("## "):
                if current_section is not None:
                    sections[current_section] = buffer
                current_section = stripped[3:].strip()
                buffer = []
                continue
            buffer.append(line)
        if current_section is not None:
            sections[current_section] = buffer
        if module_title is None:
            module_title = "Unknown Module"
        if not sections:
            sections["Uncategorized"] = [line for line in lines if line.strip()]
        return module_title, sections

    section_order: list[str] = []
    section_map: dict[str, list[tuple[str, str]]] = {}
    seen_by_section: dict[str, set[tuple[str, str]]] = {}
    for row in rows:
        content = row.get("content") or ""
        if not content:
            continue
        module_title, sections = _parse_sections(content)
        for section_title, section_lines in sections.items():
            raw = _normalize_content("\n".join(section_lines))
            if not raw:
                continue
            shifted = _shift_headings(raw, 1)
            if section_title not in section_map:
                section_map[section_title] = []
                section_order.append(section_title)
                seen_by_section[section_title] = set()
            dedupe_key = (module_title, shifted)
            if dedupe_key in seen_by_section[section_title]:
                continue
            seen_by_section[section_title].add(dedupe_key)
            section_map[section_title].append((module_title, shifted))

    lines: list[str] = ["# Ubiquitous Language"]
    for section_title in section_order:
        lines.append(f"## {section_title}")
        for module_title, body in section_map.get(section_title, []):
            lines.append(f"### {module_title}")
            if body:
                lines.append(body)

    output_path = Path(args.output)
    output_path.parent.mkdir(parents=True, exist_ok=True)
    output_path.write_text("\n\n".join(lines).strip() + "\n", encoding="utf-8")
    logging.info("UL markdown written to %s", output_path)


if __name__ == "__main__":
    main()
