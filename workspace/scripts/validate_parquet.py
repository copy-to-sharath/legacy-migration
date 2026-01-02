import argparse
import logging

import duckdb


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("--parquet-root", default=r"c:\Users\shara\code\migration\workspace\data\parquet")
    args = parser.parse_args()

    logging.basicConfig(level=logging.INFO, format="%(asctime)s %(levelname)s %(message)s")
    logging.info("Validating parquet_root=%s", args.parquet_root)

    try:
        con = duckdb.connect()
        nodes = f"{args.parquet_root}/nodes/**/*.parquet"
        edges = f"{args.parquet_root}/edges/**/*.parquet"

        total_nodes = con.execute(f"SELECT COUNT(*) FROM read_parquet('{nodes}')").fetchone()[0]
        total_edges = con.execute(f"SELECT COUNT(*) FROM read_parquet('{edges}')").fetchone()[0]

        orphan_edges = con.execute(
            f"""
            SELECT COUNT(*) FROM read_parquet('{edges}') e
            LEFT JOIN read_parquet('{nodes}') n1 ON e.sourceId = n1.id
            LEFT JOIN read_parquet('{nodes}') n2 ON e.targetId = n2.id
            WHERE n1.id IS NULL OR n2.id IS NULL
            """
        ).fetchone()[0]

        logging.info("nodes=%s edges=%s orphan_edges=%s", total_nodes, total_edges, orphan_edges)
    except KeyboardInterrupt:
        logging.error("Parquet validation interrupted by user; notify and resume.")
        raise


if __name__ == "__main__":
    main()
