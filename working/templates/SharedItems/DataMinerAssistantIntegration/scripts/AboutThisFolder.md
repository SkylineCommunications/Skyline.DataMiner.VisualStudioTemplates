This folder contains Markdown files that describe Automation script "tools" the DataMiner Assistant can call. Add one file per operation (typically one per CRUD action, e.g. `create<model>.md`, `update<model>.md`, `delete<model>.md`).

Each file starts with front matter followed by a body documenting the JSON payload fields:

```yaml
---
name: create<model>
description: Allows to create new <model>s
scriptName: <YourAIToolsScriptName>
inputArguments:
- name: MessageType
  description: always use create<model> as value
  example: create<model>
- name: MessageContent
  description: Json serialized format of the <model> to create (include all fields)
  example: '{"...": "..."}'
sync: true
requiresUserValidation: false
---
```

The referenced Automation script (`scriptName`) reads the `MessageType` and `MessageContent` script parameters and dispatches to the matching handler for that operation.

Naming rules: lowercase, letters/digits/hyphens only, no leading/trailing hyphens, no `--`. Maximum 8192 characters per file.

For the full UDAPI/AITools script setup (script parameters, entry point, message type mapping), see the [AI Integration Steps](https://internaldocs.skyline.be/Solutions/Guidelines/ai-integration-steps.html) and [Assistant Capabilities](https://internaldocs.skyline.be/DevDocs/Features/Assistant/Assistant_Capabilities.html) (Script Tool) internal documentation.
