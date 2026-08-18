# Generate repository instructions in `AGENTS.md`

Create `AGENTS.md` from the prepared Aspire solution and repository contents.
The document must help coding agents work safely and consistently without
inventing architecture or commands that are not present.

Use [workshop step 01](../blob/main/docs/01-generate-agents-md.md).

## Acceptance criteria

- [ ] `AGENTS.md` describes ApiApp, WebApp, AppHost, ServiceDefaults, data, and docs.
- [ ] It records the actual .NET, Aspire, Blazor, ASP.NET Core, and Fluent UI stack.
- [ ] It includes verified restore, build, run, and validation commands.
- [ ] It prohibits committing credentials and calling data.gov.sg directly from the browser.
- [ ] It requires tests and documentation to follow the eventual PRD and TRD.
- [ ] It includes concise commit and pull-request guidance.
