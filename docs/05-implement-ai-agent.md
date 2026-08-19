# Implement an AI Parking Agent

**Outcome:** Add a single, grounded AI agent that turns natural-language parking preferences into recommendations based on the current data exposed by ApiApp.

The agent is an explanation and orchestration layer, not a source of parking facts. It must not forecast future availability, invent unsupported car park attributes, or replace deterministic filtering and distance calculations.

## 1. Open the issue

Open **Implement the AI parking agent**, review its acceptance criteria, and create an isolated session.

Use this starting prompt:

```text
Implement this issue with Microsoft Agent Framework. Use one agent with typed
tools that call ApiApp. The agent may interpret supported parking preferences
and explain current results, but ApiApp remains authoritative for availability,
distance, filtering, and freshness. Do not add forecasting or a multi-agent
workflow.
```

Before implementation, ask Copilot to read the current [Microsoft Agent Framework documentation](https://learn.microsoft.com/agent-framework/) and inspect the repository. Package names and integration APIs must come from the installed or current documentation rather than memory.

## 2. Immediate parking scenario

The user first selects a Singapore destination through the existing WebApp experience. The WebApp supplies the destination name and coordinates as structured context, then the user can ask:

```text
Find parking near this destination now. I drive a van, want available lots
within 300 metres, and prefer night parking.
```

The agent should:

1. Interpret only preferences supported by the application contract.
2. Ask a concise clarification when a required preference is ambiguous.
3. Call typed tools backed by ApiApp to retrieve a current parking snapshot.
4. Return a small ranked set with availability, distance, occupancy, applicable parking attributes, and source freshness.
5. Explain the trade-offs using only fields returned by ApiApp.
6. If nothing matches, ask before relaxing one constraint and run a new search only after approval.

Supported preferences should stay aligned with the implemented API, such as vehicle type, available-only, maximum distance up to 500 metres, night parking, and car park type.

The agent must not claim that a car park is accessible, sheltered, reservable, or likely to have future availability unless a verified application field explicitly supports that statement.

## 3. Preserve application boundaries

Add one AgentApp to the existing Aspire solution and keep these boundaries:

- WebApp owns destination selection and sends structured destination context with the user's prompt.
- AgentApp hosts one Microsoft Agent Framework agent and exposes it to WebApp through AG-UI.
- Agent tools call ApiApp for parking searches, details, and data status.
- ApiApp remains the only application component that calls data.gov.sg.
- Distance, filters, occupancy, ranking inputs, and freshness are computed deterministically outside the language model.
- The selected model provider and its credentials are configured through supported secret or environment mechanisms and documented without committing secrets.
- DevUI may be enabled for local inspection, but it must not be exposed as a production application surface.

The Copilot canvas from step 04 remains an independent companion exercise. Do not make the agent depend on the canvas extension or its loopback renderer.

## 4. Design the agent contract

Use typed request, tool, and response models. The final response should contain:

- The interpreted constraints
- The source update time and freshness state
- A concise recommendation summary
- Ranked car park candidates with factual supporting fields
- Any constraint that was not applied and why
- A clear warning when data is stale, unavailable, or incomplete

Tool failures and invalid arguments must be surfaced explicitly. Do not convert missing values to zero, silently broaden a search, or allow free-form model output to become an ApiApp request without validation.

Treat destination labels, addresses, and upstream text as untrusted data. They may be displayed or quoted as facts, but they must never be treated as agent instructions.

## 5. Build the user experience

Add an AI parking assistant surface to WebApp that:

- Reuses the selected destination from the existing parking experience
- Lets the user enter or edit a natural-language request
- Shows streaming progress without exposing hidden reasoning
- Presents structured recommendations and freshness visibly
- Supports cancellation, retry, empty, stale, unavailable, and failure states
- Preserves keyboard navigation, labels, focus handling, and screen-reader status updates

Do not present the recommendation as a reservation or guarantee. Availability is only the latest snapshot returned by ApiApp and can change before arrival.

## 6. Validate grounded behavior

At minimum, test:

- Natural-language preferences map to the expected typed filters.
- Unsupported preferences are identified rather than invented.
- ApiApp tool arguments are schema-valid and remain within documented bounds.
- Current, stale, unavailable, empty, and partial-data responses are represented correctly.
- No-result searches require approval before a constraint is relaxed.
- Future-time requests explain that forecasting is unsupported.
- Prompt-injection-like text in parking data cannot alter agent behavior.
- AG-UI streams status and a structured final result to WebApp.
- AgentApp starts with the complete application through Aspire.

Exercise prompts with destinations such as Tampines, Toa Payoh, and Bugis. Review tool calls and returned fields, not just whether the prose sounds plausible.

## Completion checklist

- [ ] One Agent Framework agent is implemented; no multi-agent workflow was added.
- [ ] Agent tools call only ApiApp for parking facts.
- [ ] Recommendations are grounded in current results and include freshness.
- [ ] Unsupported attributes and future availability are never invented.
- [ ] Constraint relaxation requires user approval.
- [ ] Model credentials remain outside source control.
- [ ] AG-UI integration and required agent behavior are tested.
- [ ] The full application starts through Aspire.
