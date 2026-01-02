import json
from pathlib import Path
from typing import Dict, List, Optional


ROOT = Path(r"c:\Users\shara\code\migration\workspace")
DEFAULT_KEYWORDS_PATH = ROOT / "state" / "context_keywords.json"


def load_context_keywords(path: Optional[Path] = None) -> Dict[str, List[str]]:
    keywords_path = path or DEFAULT_KEYWORDS_PATH
    if not keywords_path.exists():
        raise RuntimeError(f"Context keywords file not found: {keywords_path}")
    return json.loads(keywords_path.read_text(encoding="ascii"))


def classify_context(text: str, keywords: Dict[str, List[str]]) -> str:
    haystack = text.lower()
    for context, keys in keywords.items():
        for key in keys:
            if key and key in haystack:
                return context
    return "Legacy"
