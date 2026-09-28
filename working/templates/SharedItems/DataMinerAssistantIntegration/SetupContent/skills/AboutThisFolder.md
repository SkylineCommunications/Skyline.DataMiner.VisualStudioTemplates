This folder contains one subfolder per DataMiner Assistant skill. A skill guides an agent through a specific user flow (e.g. "create a new ticket") by combining tools and step-by-step instructions.

The subfolder name must exactly match the skill's `name` field:

```
skills/<solution>-<flow-slug>/SKILL.md
```

```yaml
---
name: <solution>-<flow-slug>
description: "<1-2 sentence description of what this skill covers>"
---
```

The body typically documents "When To Use", "Steps", "Tools", and "Example Interactions" sections.

Naming rules: lowercase, letters/digits/hyphens only, no leading/trailing hyphens, no `--`. Maximum 64 characters for the skill name, 1024 characters for the description.

For full guidance and worked examples, see the [AI Integration Steps](https://internaldocs.skyline.be/Solutions/Guidelines/ai-integration-steps.html) and [Assistant Capabilities](https://internaldocs.skyline.be/DevDocs/Features/Assistant/Assistant_Capabilities.html) (Skills) internal documentation.
