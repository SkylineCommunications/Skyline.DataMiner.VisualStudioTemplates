# Keep the template list current

When adding, removing, or changing a template under `working/templates/`, update the root `README.md` in the same change.

- Use `working/templates/*/.template_config/template.json` as the source of truth for the `## Available templates` section. List every template with a config exactly once; do not list `SharedItems` or other supporting directories.
- For each entry, use the config's `name` and `shortName` (not the directory name). Describe what it creates based on the template and its `tags.type` (`solution`, `project`, or `item`); include language when it helps distinguish the template. Do not invent capabilities not supported by the template.
- Add entries for new templates, remove entries for deleted templates, and update entries when their name, short name, or purpose changes. Preserve the README's existing entry style and unrelated sections.
- Before finishing, compare the short names in `## Available templates` against all current template configs to catch missing, stale, or duplicate entries.
