# Generate `AGENTS.md`

**Outcome:** Create repository instructions that give GitHub Copilot accurate context about the prepared solution before application behavior is implemented.

## 1. Review the starter

Inspect:

- `README.md` and `IDEATION.md`
- `CarparkAvailability.slnx`
- the four projects under `src/`
- the prepared files under `data/` and `docs/`
- existing build and CI configuration

`AGENTS.md` must describe what exists. It must not pretend that the parking features, tests, or internal API contract have already been implemented.

## 2. Open the issue

In **My work**, open **Generate repository instructions in `AGENTS.md`** and review its acceptance criteria. Create an isolated project session from the issue.

## 3. Ask Copilot to implement the issue

Use this starting prompt:

```text
Implement this issue. Inspect the repository before writing `AGENTS.md`. Include
only verified project structure, technology choices, commands, and guardrails.
Do not implement application features.
```

Review the generated document. Ask Copilot to correct anything that does not match the repository.

## 4. Required guidance

Ensure `AGENTS.md` covers:

- Responsibilities of ApiApp, WebApp, AppHost, and ServiceDefaults
- .NET 10, Aspire, ASP.NET Core, and Blazor conventions
- Dataset and API-contract locations
- Build, run, and validation commands that actually work
- Separation of Google Maps browser access and data.gov.sg server access
- Secret handling and generated-code rules
- Test expectations without inventing nonexistent test commands
- Documentation, commit, and pull-request expectations

## 5. Validate and merge

Run:

```bash
dotnet build CarparkAvailability.slnx
```

Create a pull request, review the diff, and merge it when the acceptance criteria are satisfied.

## Completion checklist

- [ ] `AGENTS.md` matches the current starter.
- [ ] Commands and paths were verified.
- [ ] Credentials and service boundaries are protected.
- [ ] No application behavior was implemented.

Continue to [Generate `PRD.md` and `TRD.md`](02-generate-prd-trd.md).
