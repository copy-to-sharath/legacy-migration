import argparse
import logging
from pathlib import Path

import pyarrow as pa
import pyarrow.parquet as pq


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("--input-md", required=True, help="Path to the UL batch markdown file.")
    parser.add_argument("--batch-id", required=True, help="Batch identifier.")
    parser.add_argument("--section", required=True, help="Top-level section label.")
    parser.add_argument("--subsection", default="", help="Optional subsection label.")
    parser.add_argument("--context", default="ubiquitous-language")
    parser.add_argument("--source-file", default="", help="Optional source file for citations.")
    parser.add_argument("--source-line", type=int, default=0, help="Optional source line for citations.")
    parser.add_argument(
        "--output-dir",
        default=r"c:\Users\shara\code\migration\workspace\deliverables\generated\ul-parquet\ul-sections",
    )
    args = parser.parse_args()

    logging.basicConfig(level=logging.INFO, format="%(asctime)s %(levelname)s %(message)s")

    input_path = Path(args.input_md)
    content = input_path.read_text(encoding="utf-8")
    table = pa.Table.from_pylist(
        [
            {
                "batch_id": args.batch_id,
                "section": args.section,
                "subsection": args.subsection,
                "content": content,
                "context": args.context,
                "sourceFile": args.source_file,
                "sourceLine": args.source_line,
            }
        ]
    )

    output_dir = Path(args.output_dir)
    output_dir.mkdir(parents=True, exist_ok=True)
    output_path = output_dir / f"{args.batch_id}.parquet"
    pq.write_table(table, output_path)
    logging.info("Wrote UL batch parquet to %s", output_path)


if __name__ == "__main__":
    main()
