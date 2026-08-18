# Smart Parking Navigator Idea

## Recommended Concept

Build a **Smart Parking Navigator** that goes beyond simply displaying parking
locations on a map by recommending car parks near a destination based on
real-time data and usage conditions.

When a user searches for a destination, the app compares the current status of
nearby car parks and recommends the most suitable option.

## Core User Value

- Quickly find car parks with actual availability near the destination.
- Review not only the number of available lots, but also parking conditions and
  vehicle restrictions.
- Immediately receive available alternatives instead of fully occupied car
  parks.
- Check data update times to identify stale information.

## MVP Features

### Map and Search

- Display HDB car park locations on Google Maps or a compatible map.
- Search by address or destination.
- Explore car parks near the user's current location.
- Refresh search results as the visible map area changes.

### Real-Time Parking Information

- Display total and available parking lots.
- Calculate the occupancy rate for each car park.
- Distinguish lot types for cars, heavy vehicles, motorcycles, and other
  vehicles.
- Show the latest data update time and warn when data is stale.

### Car Park Details

- Address
- Car park type
- Electronic or coupon-based parking system
- Short-term parking hours
- Free parking conditions
- Night parking availability
- Number of car park decks
- Entrance height restriction
- Whether the car park is underground

### Filters and Recommendations

- Show only car parks with available lots.
- Filter by free parking and night parking.
- Filter by vehicle height and parking lot type.
- Filter by surface, underground, and multi-storey car parks.
- Rank recommendations using distance to the destination, number of available
  lots, and occupancy rate.
- Recommend nearby alternatives when the selected car park is full.

## Expansion Ideas

### Availability Alerts

Send a notification when the number of available lots at a favorite car park
meets or exceeds a user-defined threshold.

### Occupancy Forecasting

Periodically store API data to learn occupancy patterns by day of the week and
time of day, then predict parking availability at the estimated arrival time.

### Free Parking Discovery

Based on the current time, distinguish between car parks where free parking is
currently available and those where free parking will begin soon.

### Vehicle-Specific Search

Save the vehicle type and height in the user's profile, then automatically
exclude incompatible car parks from search results.

### Traffic and Weather Integration

Combine traffic camera and weather APIs to show both traffic conditions along
the route to the destination and expected parking conditions upon arrival.

### Operations Dashboard

Visualize occupancy rates by area, congestion heatmaps, data refresh status,
and statistics by car park type.

## Data Usage

### Carpark Availability API

- Use `carpark_number` as the car park identifier.
- Retrieve total and available lots by lot type from `carpark_info`.
- Use `update_datetime` to determine data freshness.
- Poll the API at the recommended interval of one minute.

### HDB Carpark Information

- Join static information with real-time data using `car_park_no`.
- Provide addresses and car park operating conditions.
- Convert `x_coord` and `y_coord` into coordinates suitable for map display.

Based on the current sample, 2,008 of the 2,016 real-time car parks can be
matched with HDB information.

## Data Processing Considerations

- HDB's `x_coord` and `y_coord` values use the SVY21 coordinate system and must
  be converted to WGS84 latitude and longitude for use on a map.
- Treat the published OpenAPI specification as the primary API contract, and
  validate representative live responses against it with contract tests.
- Accept backward-compatible additions such as unknown optional fields, but
  report missing required fields, incompatible types, and structural changes as
  schema validation errors.
- When the live response differs from the specification, capture a sanitized
  example, document the affected fields, and confirm the behavior before
  updating the parser, tests, and local schema together. Track the discrepancy
  until the upstream specification is corrected.
- Numeric values are provided as strings and must be safely converted to
  numeric types.
- Gracefully handle car parks whose real-time data cannot be matched with
  static information.
- If an API request fails, clearly display the last successfully retrieved data
  and its update time.

## Recommended Priorities

1. Map, destination search, and real-time availability display
2. Car park details and condition-based filters
3. Distance- and occupancy-based recommendations and alternative car parks
4. Favorites and availability alerts
5. Historical data collection and occupancy forecasting
6. Traffic and weather data integration

## Success Criteria

- Users can find an available car park near their destination within seconds.
- Car parks that do not meet height restrictions or operating-hour requirements
  are not recommended.
- The status is clearly displayed when API data is stale or unavailable.
- Users can immediately view nearby alternatives even when they select a full
  car park.
