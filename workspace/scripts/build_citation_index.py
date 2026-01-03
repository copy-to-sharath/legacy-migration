import argparse
import logging
import os
from typing import List, Dict

from neo4j import GraphDatabase


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("--neo4j-uri", default="bolt://localhost:7687")
    parser.add_argument("--neo4j-user", default="neo4j")
    parser.add_argument("--neo4j-password", default="neo4j12#456")
    parser.add_argument(
        "--output",
        default=r"c:\Users\shara\code\migration\workspace\deliverables\generated\citations\index.md",
    )
    parser.add_argument("--limit", type=int, default=2000)
    parser.add_argument("--file-limit", type=int, default=200)
    parser.add_argument("--rel-limit", type=int, default=200)
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

            counts_by_context = session.run(
                """
                MATCH (n:Node)
                WHERE n.sourceFile IS NOT NULL AND n.sourceLine IS NOT NULL
                RETURN n.context AS context, n.type AS type, COUNT(*) AS count
                ORDER BY context, count DESC
                """
            ).data()

            entrypoint_kinds = session.run(
                """
                MATCH (e:Node {type:'Entrypoint'})
                RETURN e.entryKind AS entryKind, COUNT(*) AS count
                ORDER BY count DESC
                """
            ).data()

            file_exts = session.run(
                """
                MATCH (f:Node {type:'File'})
                RETURN f.ext AS ext, COUNT(*) AS count
                ORDER BY count DESC
                """
            ).data()

            top_files = session.run(
                """
                MATCH (n:Node)
                WHERE n.sourceFile IS NOT NULL AND n.sourceLine IS NOT NULL
                RETURN n.sourceFile AS sourceFile, COUNT(*) AS count
                ORDER BY count DESC
                LIMIT $file_limit
                """,
                file_limit=args.file_limit,
            ).data()

            rows_query = """
                MATCH (n:Node)
                WHERE n.sourceFile IS NOT NULL AND n.sourceLine IS NOT NULL
                RETURN n.type AS type,
                       n.name AS name,
                       n.sourceFile AS sourceFile,
                       n.sourceLine AS sourceLine,
                       n.context AS context,
                       n.project AS project,
                       n.ext AS ext
                ORDER BY n.type, n.sourceFile, n.sourceLine
            """
            rows_params: Dict[str, int] = {}
            if args.limit > 0:
                rows_query += " LIMIT $limit"
                rows_params["limit"] = args.limit
            rows = session.run(rows_query, **rows_params).data()

            rel_query = """
                MATCH (a:Node)-[r:REL]->(b:Node)
                RETURN r.type AS relType,
                       a.type AS fromType,
                       b.type AS toType,
                       a.sourceFile AS fromFile,
                       a.sourceLine AS fromLine,
                       b.sourceFile AS toFile,
                       b.sourceLine AS toLine
                ORDER BY r.type
            """
            rel_params: Dict[str, int] = {}
            if args.rel_limit > 0:
                rel_query += " LIMIT $rel_limit"
                rel_params["rel_limit"] = args.rel_limit
            rel_rows = session.run(rel_query, **rel_params).data()

        lines: List[str] = ["# Citation Index (Graph/Vector-derived)", ""]
        lines.append("## Counts by type")
        lines.append("")
        for row in counts:
            lines.append(f"- {row['type']}: {row['count']}")
        lines.append("")
        if args.limit > 0:
            lines.append(f"## Citations (first {args.limit})")
        else:
            lines.append("## Citations (full)")
        lines.append("")
        for row in rows:
            name = row["name"] or "(unnamed)"
            context = row.get("context") or "(unknown)"
            project = row.get("project") or "(unknown)"
            ext = row.get("ext") or "(unknown)"
            citation = f"{row['sourceFile']}:{row['sourceLine']}"
            lines.append(
                f"- {row['type']} {name} ({context}, {project}, {ext}) -> {citation}"
            )

        lines.append("")
        lines.append("## Counts by context and type")
        lines.append("")
        for row in counts_by_context:
            context = row["context"] or "(unknown)"
            lines.append(f"- {context} | {row['type']}: {row['count']}")

        lines.append("")
        lines.append("## Entrypoints by kind")
        lines.append("")
        for row in entrypoint_kinds:
            kind = row["entryKind"] or "(none)"
            lines.append(f"- {kind}: {row['count']}")

        lines.append("")
        lines.append("## File extensions")
        lines.append("")
        for row in file_exts:
            ext = row["ext"] or "(none)"
            lines.append(f"- {ext}: {row['count']}")

        lines.append("")
        lines.append("## Top files by citation count")
        lines.append("")
        for row in top_files:
            lines.append(f"- {row['sourceFile']}: {row['count']}")

        lines.append("")
        if args.rel_limit > 0:
            lines.append(f"## Relationship samples (first {args.rel_limit})")
        else:
            lines.append("## Relationships (full)")
        lines.append("")
        for row in rel_rows:
            rel_type = row["relType"] or "(unknown)"
            from_ref = row["fromFile"]
            to_ref = row["toFile"]
            from_line = row["fromLine"]
            to_line = row["toLine"]
            if from_ref and from_line:
                from_ref = f"{from_ref}:{from_line}"
            if to_ref and to_line:
                to_ref = f"{to_ref}:{to_line}"
            lines.append(
                f"- {rel_type}: {row['fromType']} ({from_ref}) -> {row['toType']} ({to_ref})"
            )

        out_dir = os.path.dirname(args.output)
        if out_dir:
            os.makedirs(out_dir, exist_ok=True)
        with open(args.output, "w", encoding="utf-8") as f:
            f.write("\n".join(lines))

        logging.info("Citation index written")
    except KeyboardInterrupt:
        logging.error("Citation index build interrupted by user; notify and resume.")
        raise


if __name__ == "__main__":
    main()
