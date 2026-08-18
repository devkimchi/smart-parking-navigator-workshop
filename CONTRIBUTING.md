# Contributing to Smart Parking Navigator Workshop

Thank you for improving the workshop template.

## Code of Conduct

This project follows the [Contributor Covenant Code of Conduct](CODE_OF_CONDUCT.md).
By participating, you agree to uphold it.

## Development Setup

Prerequisites:

- .NET 10 SDK
- Git
- A Chromium-family browser
- GitHub Copilot app and Copilot CLI
- Aspire CLI
- Google Maps and data.gov.sg API keys for end-to-end use
- A container runtime supported by .NET Aspire

Clone the repository and restore dependencies:

```powershell
git clone https://github.com/devkimchi/smart-parking-navigator-workshop.git
cd smart-parking-navigator-workshop
dotnet restore CarparkAvailability.slnx
```

Configure development credentials by following
[Google Maps API Key Setup](docs/google-maps-api-key.md) and
[data.gov.sg API Key Setup](docs/data-gov-sg-api-key.md).

Run the complete application through its Aspire AppHost:

```powershell
aspire run
```

## Making Changes

1. Create a branch using `feat/`, `fix/`, `docs/`, or `chore/`.
2. Keep changes focused and add tests for behavior changes.
3. Run the local checks:

   ```powershell
   dotnet restore CarparkAvailability.slnx
   dotnet build CarparkAvailability.slnx --no-restore --configuration Release
   ```

4. Update documentation when behavior or setup changes.
5. Commit each completed and validated coherent step before starting the next.
6. Open a pull request and link the related issue.

The template's default branch must remain a starter. Do not copy completed
application code from the demo repository. Workshop guides, bootstrap issues,
and acceptance criteria must remain aligned.

Generated repositories may add tests and OpenAPI client generation as part of
the implementation lab. Commit those changes to the participant repository,
not back to this template unless they improve the starter experience.

## Commit Convention

Use [Conventional Commits](https://www.conventionalcommits.org/):

- `feat:` new functionality
- `fix:` bug fixes
- `docs:` documentation-only changes
- `test:` test additions or updates
- `refactor:` behavior-preserving code changes
- `chore:` maintenance and dependency changes

## Reporting Bugs and Requesting Features

Use the structured forms in `.github/ISSUE_TEMPLATE/` and include enough
context to reproduce or evaluate the request.
