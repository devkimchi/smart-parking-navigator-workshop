# Set Up the Workshop

**Outcome:** Create your own repository from the workshop template, configure the required credentials, load it in GitHub Copilot, and run the prepared Aspire application.

## 1. Install the tools

Install or update:

- [GitHub Copilot app](https://gh.io/app)
- [GitHub Copilot CLI](https://gh.io/copilot-cli)
- [GitHub CLI](https://gh.io/cli)
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Aspire CLI](https://aspire.dev/get-started/install-cli/)
- [Docker Desktop](https://docs.docker.com/get-started/) or another OCI-compatible container runtime
- (OPTIONAL) GitHub Mobile app from Google Play Store or Apple App Store

Verify the command-line tools:

```bash
copilot --version
gh --version
dotnet --version
aspire --version
```

## 2. Sign in

Sign in to Copilot CLI and GitHub CLI:

```bash
copilot login
gh auth login
gh auth status
```

Sign in to the GitHub Copilot app with the same GitHub account.

## 3. Obtain API access

Follow both prepared guides:

1. [Configure Google Maps Platform](google-maps-api-key.md).
2. [Request and configure a data.gov.sg API key](data-gov-sg-api-key.md).

Never paste either key into a Copilot prompt, issue, source file, commit, or application log.

## 4. Create your workshop repository

1. Open [`devkimchi/smart-parking-navigator-workshop`](https://github.com/devkimchi/smart-parking-navigator-workshop).
2. Select **Use this template** and **Create a new repository**.
3. Choose your account or organisation and a repository name.
4. Wait for the bootstrap workflow to create the five workshop issues.

Do not fork the template. A repository created from the template has an independent history and receives the prepared issues automatically.

## 5. Load the repository

1. Open the GitHub Copilot app.
2. Add the repository you just created.
3. Open **My work** and confirm that the workshop issues appear.

## 6. Configure local secrets

From the repository root:

```bash
# zsh/bash
dotnet user-secrets set "GoogleMaps:ApiKey" "<your-restricted-google-maps-key>" \
  --project src/CarparkAvailability.AppHost

dotnet user-secrets set "DataGovSg:ApiKey" "<your-data-gov-sg-key>" \
  --project src/CarparkAvailability.AppHost
```

```powershell
# PowerShell
dotnet user-secrets set "GoogleMaps:ApiKey" "<your-restricted-google-maps-key>" `
  --project src/CarparkAvailability.AppHost

dotnet user-secrets set "DataGovSg:ApiKey" "<your-data-gov-sg-key>" `
  --project src/CarparkAvailability.AppHost
```

## 7. Run the starter

```bash
dotnet restore CarparkAvailability.slnx
dotnet build CarparkAvailability.slnx --no-restore
aspire run
```

Open the Aspire dashboard URL printed in the terminal, then open the WebApp resource. Confirm that the workshop starter page loads and that ApiApp is healthy.

## Completion checklist

- [ ] All required tools are installed.
- [ ] GitHub authentication works.
- [ ] Both API keys are stored in AppHost user secrets.
- [ ] Your repository contains five workshop issues.
- [ ] ApiApp and WebApp run through Aspire.

Continue to [Generate `AGENTS.md`](01-generate-agents-md.md).
