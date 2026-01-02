import argparse
import logging
import os
import uuid
from typing import Iterable, Iterator, List, Dict, Any

import pyarrow.dataset as ds
from neo4j import GraphDatabase
from qdrant_client import QdrantClient
from qdrant_client.http import models as qmodels


def batched(iterable: Iterable[Any], size: int) -> Iterator[List[Any]]:
    batch = []
    for item in iterable:
        batch.append(item)
        if len(batch) >= size:
            yield batch
            batch = []
    if batch:
        yield batch


def scan_batches(dataset: ds.Dataset, batch_size: int) -> Iterator[List[Dict[str, Any]]]:
    scanner = dataset.scanner(batch_size=batch_size)
    for batch in scanner.to_batches():
        yield batch.to_pylist()


def load_nodes(tx, rows: List[Dict[str, Any]]) -> None:
    query = """
    UNWIND $rows AS row
    MERGE (n:Node {id: row.id})
    SET n.type = row.type, n.context = row.context
    SET n += row.props
    """
    tx.run(query, rows=rows)


def load_edges(tx, rows: List[Dict[str, Any]]) -> None:
    query = """
    UNWIND $rows AS row
    MATCH (a:Node {id: row.sourceId})
    MATCH (b:Node {id: row.targetId})
    MERGE (a)-[r:REL {id: row.id}]->(b)
    SET r.type = row.type, r.context = row.context
    SET r += row.props
    """
    tx.run(query, rows=rows)


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("--parquet-root", default=r"c:\Users\shara\code\migration\workspace\data\parquet")
    parser.add_argument("--neo4j-uri", default="bolt://localhost:7687")
    parser.add_argument("--neo4j-user", default="neo4j")
    parser.add_argument("--neo4j-password", default="neo4j12#456")
    parser.add_argument("--qdrant-url", default="http://localhost:6333")
    parser.add_argument("--collection", default="code_vectors")
    parser.add_argument("--batch-size", type=int, default=500)
    parser.add_argument("--skip-neo4j", action="store_true")
    parser.add_argument("--skip-qdrant", action="store_true")
    args = parser.parse_args()

    logging.basicConfig(level=logging.INFO, format="%(asctime)s %(levelname)s %(message)s")
    logging.info("Loading graph/vector parquet_root=%s", args.parquet_root)

    try:
        if not args.skip_neo4j:
            driver = GraphDatabase.driver(args.neo4j_uri, auth=(args.neo4j_user, args.neo4j_password))
            with driver.session() as session:
                session.run("CREATE CONSTRAINT node_id IF NOT EXISTS FOR (n:Node) REQUIRE n.id IS UNIQUE")
                session.run("CREATE CONSTRAINT rel_id IF NOT EXISTS FOR ()-[r:REL]-() REQUIRE r.id IS UNIQUE")
                logging.info("Neo4j constraints ensured")

                node_ds = ds.dataset(os.path.join(args.parquet_root, "nodes"), format="parquet", partitioning="hive")
                edge_ds = ds.dataset(os.path.join(args.parquet_root, "edges"), format="parquet", partitioning="hive")

                for batch in scan_batches(node_ds, args.batch_size):
                    rows = []
                    for row in batch:
                        props = dict(row)
                        props.pop("id", None)
                        props.pop("type", None)
                        props.pop("context", None)
                        rows.append({"id": row["id"], "type": row["type"], "context": row["context"], "props": props})
                    session.execute_write(load_nodes, rows)
                    logging.info("Loaded nodes batch size=%s", len(rows))

                for batch in scan_batches(edge_ds, args.batch_size):
                    rows = []
                    for row in batch:
                        props = dict(row)
                        props.pop("id", None)
                        props.pop("type", None)
                        props.pop("context", None)
                        props.pop("sourceId", None)
                        props.pop("targetId", None)
                        rows.append(
                            {
                                "id": row["id"],
                                "type": row["type"],
                                "context": row["context"],
                                "sourceId": row["sourceId"],
                                "targetId": row["targetId"],
                                "props": props,
                            }
                        )
                    session.execute_write(load_edges, rows)
                    logging.info("Loaded edges batch size=%s", len(rows))

        if not args.skip_qdrant:
            client = QdrantClient(url=args.qdrant_url)
            vectors_ds = ds.dataset(os.path.join(args.parquet_root, "vectors"), format="parquet", partitioning="hive")
            first_batch = next(scan_batches(vectors_ds, 1), [])
            if not first_batch:
                logging.warning("No vectors found; skipping Qdrant load")
                return
            dim = len(first_batch[0]["vector"])
            if client.collection_exists(collection_name=args.collection):
                client.delete_collection(collection_name=args.collection)
            client.create_collection(
                collection_name=args.collection,
                vectors_config=qmodels.VectorParams(size=dim, distance=qmodels.Distance.COSINE),
            )
            logging.info("Qdrant collection ready name=%s dim=%s", args.collection, dim)

            for batch in scan_batches(vectors_ds, args.batch_size):
                points = []
                for row in batch:
                    payload = {
                        "type": row["type"],
                        "context": row["context"],
                        "sourceFile": row["sourceFile"],
                        "sourceLine": row["sourceLine"],
                    }
                    point_id = str(uuid.uuid5(uuid.NAMESPACE_URL, row["id"]))
                    points.append(qmodels.PointStruct(id=point_id, vector=row["vector"], payload=payload))
                client.upsert(collection_name=args.collection, points=points)
                logging.info("Upserted vectors batch size=%s", len(points))

        logging.info("Graph/vector load complete")
    except KeyboardInterrupt:
        logging.error("Graph/vector load interrupted by user; notify and resume.")
        raise


if __name__ == "__main__":
    main()
