This folder contains Markdown files that describe GQI ad hoc data sources to the DataMiner Assistant. Add one file per data source (e.g. one per model, one per sub-object) so the Assistant can use it as a read-only data tool.

Each file starts with front matter followed by a body explaining what the data source returns, its filterable fields, and example OData filters:

```yaml
---
name: "<SolutionName>.Get <PluralModel>"
description: "<What this data source returns>"
columns:
  - name: "<ColumnName>"
    type: "<String|DateTime|Int|Double|Boolean>"
    description: "<What this column contains>"
inputArguments:
  - name: "FilterRequest"
    type: "String"
    description: "OData filter expression"
    example: ""
---
```

Naming rules: lowercase, letters/digits/hyphens only, no leading/trailing hyphens, no `--`. Maximum 8192 characters per file.

For full guidance and worked examples, see the [AI Integration Steps](https://internaldocs.skyline.be/Solutions/Guidelines/ai-integration-steps.html) and [Assistant Capabilities](https://internaldocs.skyline.be/DevDocs/Features/Assistant/Assistant_Capabilities.html) internal documentation.
