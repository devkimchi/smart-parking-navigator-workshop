# Implement Smart Parking Navigator

Implement the frontend and backend described by the reviewed `PRD.md` and `TRD.md`. Preserve the prepared Aspire project boundaries and use the bundled datasets and API contract. Create a PR first, then commit changes to the PR while implementing app. If possible, take a screenshot how the UI looks like.

## Acceptance criteria

- [ ] ApiApp loads and validates the HDB CSV and retrieves live availability from data.gov.sg.
- [ ] Static and live records are joined safely and SVY21 coordinates are converted for map use.
- [ ] ApiApp exposes the search, detail, and data-status behavior defined by the TRD.
- [ ] WebApp supports Singapore destination search, synchronized map/list results, filters, details, and required empty/error/freshness states.
- [ ] WebApp calls only ApiApp for parking data; the data.gov.sg key is never sent to the browser.
- [ ] Unit, integration, component, and end-to-end tests required by the TRD pass.
- [ ] The complete application starts through the Aspire AppHost.
