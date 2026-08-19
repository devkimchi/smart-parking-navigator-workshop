# Implement the Application

**Outcome:** Build and validate the Smart Parking Navigator frontend and backend from the reviewed PRD and TRD.

## 1. Open the issue

Open **Implement Smart Parking Navigator**, review the acceptance criteria, and create an isolated session.

Use this starting prompt:

```text
Implement this issue according to `PRD.md`, `TRD.md`, and `AGENTS.md`. Preserve the
prepared Aspire project boundaries. Work incrementally, validate each
checkpoint, and do not add deferred features.
```

## 2. Checkpoint A: Backend data pipeline

Implement and validate:

- Typed CSV parsing with required-header and row validation
- SVY21-to-WGS84 conversion with known Singapore reference points
- A typed data.gov.sg client based on the prepared contract
- Safe numeric parsing and lot-type mapping
- Matching static and live records without converting unknown values to zero
- Immutable last-known-good availability with fresh, stale, and unavailable states

Ask Copilot to show the focused tests and validation results before continuing.

## 3. Checkpoint B: Backend API

Implement the API surface defined by the TRD:

- Nearby search using an exact 500-metre geodesic radius
- Vehicle and parking-condition filters
- Details and data status
- Validation errors as Problem Details
- Explicit behavior for upstream failures and partial data

The data.gov.sg key must remain inside ApiApp.

## 4. Checkpoint C: Frontend

Implement:

- Singapore-restricted destination search
- Google Maps and browser geolocation
- Synchronized map and accessible result list
- Availability, distance, occupancy, and freshness
- Required filters and car park details
- Loading, empty, invalid, stale, unavailable, and failure states
- Responsive keyboard-accessible UI

WebApp must call ApiApp for all parking data. It must never call data.gov.sg directly.

## 5. Checkpoint D: Integration and tests

Add the test projects and coverage required by the TRD. At minimum, validate:

- CSV validation and coordinate conversion
- Availability parsing, matching, and freshness
- Search boundaries and filters
- API contract and error responses
- Core frontend rendering and state
- One end-to-end destination-to-car-park journey

Run the commands established by the implementation, including:

```bash
dotnet restore CarparkAvailability.slnx
dotnet build CarparkAvailability.slnx --no-restore
dotnet test CarparkAvailability.slnx --no-build
aspire run
```

## 6. Review against the documents

Use this final review prompt:

```text
Compare the implementation with PRD.md, TRD.md, and AGENTS.md. Identify missing
acceptance criteria, over-engineering, unsafe data assumptions, accessibility
gaps, and untested behavior. Fix confirmed issues without adding deferred scope.
```

Exercise the application with destinations such as Tampines, Toa Payoh, and Bugis. Review the pull request and merge only after the documented behavior is demonstrated.

## Completion checklist

- [ ] Frontend and backend satisfy the P0 requirements.
- [ ] External credentials remain in the correct boundary.
- [ ] Invalid and stale data are not presented as current facts.
- [ ] Automated tests pass.
- [ ] The complete app runs through Aspire.

Continue to [Create a Copilot canvas](04-create-canvas.md).
