import re
from dataclasses import dataclass
from pathlib import Path
from typing import Dict, List


ROOT = Path(r"c:\Users\shara\code\migration\workspace")
PROMPTS_DIR = ROOT / "prompts"
AGENTS_PATH = PROMPTS_DIR / "agents.md"
WORKFLOW_TEMPLATE_PATH = PROMPTS_DIR / "workflow-header.md"
BRD_TEMPLATE_PATH = PROMPTS_DIR / "brd-template.md"
API_MAPPING_TEMPLATE_PATH = PROMPTS_DIR / "api-mapping-template.md"
REQNROLL_README_TEMPLATE_PATH = PROMPTS_DIR / "reqnroll-readme-template.md"
CONTEXT_README_TEMPLATE_PATH = PROMPTS_DIR / "context-readme-template.md"
PROJECT_README_TEMPLATE_PATH = PROMPTS_DIR / "project-readme-template.md"


@dataclass(frozen=True)
class AgentRoles:
    generator: str
    judge: str


def _read_prompt(path: Path) -> str:
    if not path.exists():
        raise RuntimeError(f"Prompt file not found: {path}")
    return path.read_text(encoding="ascii").strip()


def load_agent_roles() -> Dict[str, AgentRoles]:
    content = _read_prompt(AGENTS_PATH)
    roles: Dict[str, AgentRoles] = {}
    current_key = ""
    generator = ""
    judge = ""

    for line in content.splitlines():
        line = line.strip()
        if not line:
            continue
        if line.startswith("## "):
            if current_key and generator and judge:
                roles[current_key] = AgentRoles(generator=generator, judge=judge)
            current_key = line.replace("## ", "").strip()
            generator = ""
            judge = ""
            continue
        if line.startswith("Generator:"):
            generator = line.replace("Generator:", "").strip()
        elif line.startswith("Judge:"):
            judge = line.replace("Judge:", "").strip()

    if current_key and generator and judge:
        roles[current_key] = AgentRoles(generator=generator, judge=judge)

    if not roles:
        raise RuntimeError(f"No agent roles found in {AGENTS_PATH}")
    return roles


def workflow_header_lines(role_key: str, comment_prefix: str = "") -> List[str]:
    roles = load_agent_roles()
    if role_key not in roles:
        raise RuntimeError(f"Missing agent role entry: {role_key}")
    template = _read_prompt(WORKFLOW_TEMPLATE_PATH)
    header = template.format(generator=roles[role_key].generator, judge=roles[role_key].judge)
    prefix = comment_prefix.rstrip()
    if prefix:
        prefix = prefix + " "
    return [f"{prefix}{line}" for line in header.splitlines()]


def load_system_prompt(role: str) -> str:
    prompt_map = {
        "Generator": Path(r"c:\Users\shara\code\migration\.github\agents\Prompt-Generator.md"),
        "Judge": Path(r"c:\Users\shara\code\migration\.github\agents\Prompt-Judge.md"),
    }
    path = prompt_map.get(role)
    if not path:
        raise RuntimeError(f"System prompt not found for role: {role}")
    return _read_prompt(path)


def load_brd_template() -> str:
    return _read_prompt(BRD_TEMPLATE_PATH)


def load_api_mapping_template() -> str:
    return _read_prompt(API_MAPPING_TEMPLATE_PATH)


def load_reqnroll_readme_template() -> str:
    return _read_prompt(REQNROLL_README_TEMPLATE_PATH)


def load_context_readme_template() -> str:
    return _read_prompt(CONTEXT_README_TEMPLATE_PATH)


def load_project_readme_template() -> str:
    return _read_prompt(PROJECT_README_TEMPLATE_PATH)
