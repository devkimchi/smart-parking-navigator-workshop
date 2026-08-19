# Create a Copilot Canvas

**Outcome:** Build a project-scoped extension that mimics the completed parking experience and renders directly inside the GitHub Copilot app.

The Blazor WebApp remains the production application. The canvas is a compact Copilot-native companion and a learning exercise in extension development.

## 1. Open the issue

Open **Create a Smart Parking Navigator canvas**, review its acceptance criteria, and create an isolated session.

Use this starting prompt:

```text
Implement this issue using the create-canvas skill. Create a project-scoped
canvas extension named smart-parking-canvas. Follow the current bundled Copilot
SDK documentation and scaffold the extension before editing it.

Render a compact, accessible Smart Parking Navigator experience inspired by
the completed WebApp. Use the repository's sample parking data so the canvas
runs without requiring the Aspire backend. Include an agent action that changes
the selected destination or active filter.
```

## 2. Follow the extension workflow

Copilot should:

1. Read the installed extension guide and current canvas SDK types.
2. Scaffold a **project** canvas under `.github/extensions/smart-parking-canvas/`.
3. Keep `extension.mjs` as the entry point and avoid adding a package for `@github/copilot-sdk`.
4. Bind the renderer HTTP server to `127.0.0.1` on an ephemeral port.
5. Implement idempotent open behavior and close server resources in `onClose`.
6. Reload extensions and inspect extension status and logs.

Do not manually recreate SDK boilerplate before using the scaffold command.

## 3. Canvas experience

The canvas should show a small representative result set with:

- A Singapore destination
- Car park address and number
- Available and total lots
- Distance and occupancy
- Freshness and source update time
- Vehicle or availability filters

Use the Copilot canvas semantic theme variables rather than copying the WebApp stylesheet. Ensure controls have labels, visible focus, keyboard support, and information that does not rely on colour alone.

The iframe has no privileged bridge to the host. User controls should call the extension's loopback HTTP endpoints. Agent-facing operations belong in declared canvas actions.

## 4. Validate the extension

Ask Copilot to complete the current canvas validation checklist:

- Confirm extension discovery and healthy load status.
- List the canvas capabilities.
- Open the canvas with a valid instance ID.
- Invoke the destination or filter action.
- Confirm invalid input is rejected by its JSON Schema.
- Confirm the renderer server closes with the canvas.

Open the canvas in the GitHub Copilot app and compare its information hierarchy with the WebApp. It should feel related without attempting to embed or deploy the Blazor application.

## Completion checklist

- [ ] The extension is project-scoped and committed with the repository.
- [ ] It was created through the canvas scaffold workflow.
- [ ] The renderer is loopback-only and cleans up correctly.
- [ ] The canvas uses sample data and runs without Aspire.
- [ ] Discovery, open, input validation, and an action were verified.
- [ ] The UI is theme-aware and keyboard accessible.

Continue to [Implement an AI parking agent](05-implement-ai-agent.md).
