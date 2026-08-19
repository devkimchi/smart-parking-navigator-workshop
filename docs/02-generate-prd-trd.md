# Generate `PRD.md` and `TRD.md`

**Outcome:** Turn the approved idea into a workshop-sized product specification and an implementable technical design.

## 1. Review the inputs

Read:

- [`IDEATION.md`](../IDEATION.md)
- the scaffolded projects under `src/`
- `data/HDBCarparkInformation.csv`
- `data/carpark-availability-sample.json`
- `data/CarparkAvailability.json`
- both API-key setup guides

The architecture is a constraint, not a design exercise: keep the existing Aspire, ApiApp, WebApp, and ServiceDefaults projects.

## 2. Open the issue

Open **Generate `PRD.md` and `TRD.md`** from **My work**, confirm its acceptance criteria, and create an isolated session.

## 3. Generate the documents

Use this starting prompt:

```text
Implement this issue by creating only `PRD.md` and `TRD.md`. Use `IDEATION.md`, the
prepared Singapore datasets, setup guides, and Aspire scaffold as source
material. Keep the scope achievable in a workshop and do not write application
code.
```

## 4. Keep the MVP focused

The PRD should require:

- Destination search restricted to Singapore
- HDB car parks within 500 metres
- Available and total lots by supported vehicle type
- Distance, occupancy, source update time, and freshness
- Available-only, vehicle-type, night-parking, and car-park-type filters
- Details and clear loading, empty, stale, unavailable, and error states

Defer favorites, alerts, forecasting, accounts, databases, traffic, weather, deployment, and MCP. Keep agentic AI out of the core application MVP; it is introduced separately in step 05.

The TRD should explain:

- Static HDB CSV parsing and validation
- Safe matching of `car_park_no` and `carpark_number`
- SVY21-to-WGS84 conversion
- Live availability retrieval and last-known-good behavior
- Frontend/backend API contracts
- Google Maps integration
- Security, accessibility, error handling, and testing

Do not infer undocumented meanings for free-parking or short-term-parking values. Use Singapore Standard Time where time interpretation is required.

## 5. Review and merge

Check that every P0 requirement has testable acceptance criteria and a matching technical design. Remove speculative features or unnecessary infrastructure. Create and merge a pull request containing only the two documents.

## Completion checklist

- [ ] The PRD defines a focused, testable Singapore MVP.
- [ ] The TRD fits the prepared Aspire scaffold.
- [ ] Data quality, coordinate conversion, and freshness are explicit.
- [ ] Deferred scope is unambiguous.
- [ ] No application code was changed.

Continue to [Implement the application](03-implement-app.md).
