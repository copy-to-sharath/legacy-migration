import argparse
import logging
from typing import List, Dict

from neo4j import GraphDatabase


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("--neo4j-uri", default="bolt://localhost:7687")
    parser.add_argument("--neo4j-user", default="neo4j")
    parser.add_argument("--neo4j-password", default="neo4j12#456")
    parser.add_argument(
        "--output",
        default=r"c:\Users\shara\code\migration\workspace\deliverables\citations\index.md",
    )
    parser.add_argument("--limit", type=int, default=500)
    args = parser.parse_args()

    logging.basicConfig(level=logging.INFO, format="%(asctime)s %(levelname)s %(message)s")
    logging.info("Building citation index output=%s", args.output)

    try:
        driver = GraphDatabase.driver(args.neo4j_uri, auth=(args.neo4j_user, args.neo4j_password))
        with driver.session() as session:
            counts = session.run(
                """
                MATCH (n:Node)
                WHERE n.sourceFile IS NOT NULL AND n.sourceLine IS NOT NULL
                RETURN n.type AS type, COUNT(*) AS count
                ORDER BY count DESC
                """
            ).data()

            rows = session.run(
                """
                MATCH (n:Node)
                WHERE n.sourceFile IS NOT NULL AND n.sourceLine IS NOT NULL
                RETURN n.type AS type, n.name AS name, n.sourceFile AS sourceFile, n.sourceLine AS sourceLine
                ORDER BY n.type, n.sourceFile, n.sourceLine
                LIMIT $limit
                """,
                limit=args.limit,
            ).data()

        lines: List[str] = ["# Citation Index (Graph/Vector-derived)", ""]
        lines.append("## Counts by type")
        lines.append("")
        for row in counts:
            lines.append(f"- {row['type']}: {row['count']}")
        lines.append("")
        lines.append("## Sample citations")
        lines.append("")
        for row in rows:
            name = row["name"] or "(unnamed)"
            citation = f"{row['sourceFile']}:{row['sourceLine']}"
            lines.append(f"- {row['type']} {name} -> {citation}")

        with open(args.output, "w", encoding="utf-8") as f:
            f.write("\n".join(lines))

        logging.info("Citation index written")
    except KeyboardInterrupt:
        logging.error("Citation index build interrupted by user; notify and resume.")
        raise


if __name__ == "__main__":
    main()
