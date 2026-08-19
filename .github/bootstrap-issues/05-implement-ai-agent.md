# Implement the AI parking agent

Extend Smart Parking Navigator with a single Microsoft Agent Framework agent that recommends parking for a destination selected in WebApp. The agent interprets supported natural-language preferences, calls typed ApiApp tools, and explains recommendations from the current parking snapshot. It must not forecast future availability or introduce a multi-agent workflow.

## Scenario

The user selects a Singapore destination in the existing WebApp, then asks for an immediate recommendation such as:

```text
Find parking near this destination now. I drive a van, want available lots
within 300 metres, and prefer night parking.
```

Supported preferences must stay aligned with the implemented application contract, including vehicle type, available-only, maximum distance up to 500 metres, night parking, and car park type. The agent must identify unsupported requests rather than infer attributes such as accessibility, shelter, reservations, or future availability.

## Architecture

Keep the standard parking experience and AI assistant as separate request paths:

```text
Standard WebApp UI ───────────────> ApiApp ──> data.gov.sg
WebApp AI assistant ──AG-UI──> AgentApp ─────> ApiApp
```

- WebApp owns destination search and supplies the selected destination name and coordinates as structured context.
- AgentApp hosts one agent, validates model-produced tool arguments, and calls ApiApp through typed tools.
- ApiApp remains authoritative for availability, distance, filtering, occupancy inputs, ranking inputs, and freshness.
- ApiApp remains the only component that calls data.gov.sg or holds its API key.
- An MCP server is not required for this workflow. Do not add one that bypasses or duplicates ApiApp.
- The step 04 canvas remains independent and is not a runtime dependency of AgentApp.

## Agent workflow

1. WebApp sends the selected destination context and the user's editable prompt to AgentApp through AG-UI.
2. The agent interprets only supported preferences and asks a concise clarification when required input is ambiguous.
3. AgentApp validates the interpreted constraints before invoking any tool.
4. A typed tool calls ApiApp for nearby search, details, or data status.
5. ApiApp performs deterministic filtering and calculations and returns the current snapshot with freshness metadata.
6. The agent returns a small ranked set and explains trade-offs using only fields returned by ApiApp.
7. If no result matches, the agent asks permission to relax one constraint and runs another search only after approval.
8. AgentApp streams visible progress and a structured final response to WebApp without exposing hidden reasoning.

Future-time requests must explain that forecasting is unsupported and may offer a recommendation from the current snapshot instead. Stale, partial, or unavailable data must remain visibly qualified, and availability must never be presented as a reservation or guarantee.

## Implementation guidance

- Read the current Microsoft Agent Framework and AG-UI documentation before selecting packages or APIs.
- Add one AgentApp to the Aspire solution and configure its supported model provider through secrets or environment variables.
- Use typed request, tool, and response models; never pass unchecked free-form model output to ApiApp.
- Treat destination labels, addresses, and upstream text as untrusted data, not agent instructions.
- DevUI may be used for local inspection but must not be exposed as a production surface.
- Preserve cancellation and surface invalid, empty, stale, unavailable, partial, and failed states explicitly.

## Acceptance criteria

- [ ] A single AgentApp is added to the Aspire solution and its model provider is configured without committing credentials.
- [ ] The standard WebApp continues to call ApiApp directly, while only the AI assistant communicates with AgentApp through AG-UI.
- [ ] WebApp sends a validated destination name and coordinates as structured context with the user's prompt.
- [ ] Typed AgentApp tools call only ApiApp for searches, details, and data status; AgentApp never calls data.gov.sg directly.
- [ ] ApiApp remains authoritative for availability, distance, filtering, occupancy inputs, and freshness.
- [ ] Recommendations include interpreted constraints, ranked candidates, factual supporting fields, source update time, and freshness.
- [ ] Unsupported preferences are identified, future availability is not predicted, and no-result searches require approval before relaxing a constraint.
- [ ] Stale, unavailable, partial, invalid, cancelled, and failed requests are represented explicitly.
- [ ] Streaming progress does not expose hidden reasoning, and recommendations are not presented as reservations or guarantees.
- [ ] Automated tests cover constraint interpretation, tool validation, grounding boundaries, AG-UI integration, approval before relaxation, and prompt-injection-like data.
- [ ] AgentApp and the complete application start through Aspire.
