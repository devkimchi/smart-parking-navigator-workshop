# Google Maps API Key Setup

Smart Parking Navigator uses Google Maps Platform in the browser for map
rendering, destination discovery, and geocoding.

## Create the Key

1. Create or select a project in the
   [Google Cloud console](https://console.cloud.google.com/).
2. Enable billing for the project.
3. Enable these APIs:
   - [Maps JavaScript API](https://console.cloud.google.com/google/maps-apis/api-list)
   - Places API (New)
   - Geocoding API
4. Create an API key from
   [Google Maps Platform credentials](https://console.cloud.google.com/google/maps-apis/credentials).

## Restrict the Key

The browser receives this key, so website and API restrictions are required.

1. Set the application restriction to **Websites**.
2. Add the local and deployed origins that may use the key. For local
   development, allow the HTTPS localhost origin used by the WebApp.
3. Restrict the key to the Maps JavaScript API, Places API (New), and Geocoding
   API.
4. Monitor usage and quotas in the Google Cloud console.

See
[Google Maps Platform API security best practices](https://developers.google.com/maps/api-security-best-practices)
for the current restriction guidance.

## Configure Local Development

Store the key in the AppHost user-secrets store:

```powershell
dotnet user-secrets set "GoogleMaps:ApiKey" "<your-restricted-api-key>" `
  --project src\CarparkAvailability.AppHost
```

The AppHost supplies the value to WebApp as `GoogleMaps__ApiKey`. Do not commit
the key to the repository.
