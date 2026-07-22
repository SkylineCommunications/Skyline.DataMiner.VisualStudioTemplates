This folder contains one subfolder per specialized DataMiner Assistant agent, typically one per user role (e.g. Administrator, Read-only). Each subfolder is named with a generated GUID:

```
agents/<guid>/agent.md
```

```yaml
---
name: "<SolutionName> <RoleName>"
description: "<What this agent does, tailored to the role>"
tools:
  - create<model>
  - update<model>
  - delete<model>
  - get<model>s
skills:
  - <skill-name>
---
```

The body describes the agent's personality, capabilities, and role-specific restrictions. Map each role's permissions to the appropriate tools and skills: read-only roles should only list ad hoc data source tools, while full-access roles get all script tools and skills.

Naming rules: agent name maximum 128 characters, description maximum 1024 characters, instructions (body) maximum 32768 characters.

For full guidance and worked examples, see the [AI Integration Steps](https://internaldocs.skyline.be/Solutions/Guidelines/ai-integration-steps.html) and [Assistant Capabilities](https://internaldocs.skyline.be/DevDocs/Features/Assistant/Assistant_Capabilities.html) (Agents) internal documentation.
