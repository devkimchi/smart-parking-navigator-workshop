# data.gov.sg API Key Setup

Smart Parking Navigator uses the data.gov.sg Car Park Availability API to load
live parking-lot availability.

## Request the Key

1. Follow the official
   [data.gov.sg API key guide](https://guide.data.gov.sg/developer-guide/api-overview/how-to-request-an-api-key).
2. Copy the generated key and store it securely.

The key is confidential. Do not expose it to the browser, include it in logs,
or commit it to the repository.

## Configure Local Development

Store the key in the AppHost user-secrets store:

```powershell
dotnet user-secrets set "DataGovSg:ApiKey" "<your-data-gov-sg-api-key>" `
  --project src\CarparkAvailability.AppHost
```

The AppHost supplies the value only to ApiApp as `DataGovSg__ApiKey`.
