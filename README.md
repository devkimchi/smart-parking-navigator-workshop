# Smart Parking Navigator Workshop

Build a mobile-first application for finding suitable HDB car parks in Singapore with GitHub Copilot. The workshop starts from a prepared .NET Aspire solution and progresses from repository instructions and requirements to a working frontend, backend, Copilot canvas, and grounded AI parking assistant.

[Start the workshop](docs/00-setup.md) |
[View the completed demo](https://github.com/devkimchi/smart-parking-navigator) |
[Create a repository from this template](https://github.com/new?template_name=smart-parking-navigator-workshop&template_owner=devkimchi)

## What You Will Build

- An ASP.NET Core API that combines HDB car park information with live availability from data.gov.sg
- A Blazor frontend with destination search, Google Maps, filters, availability, and data-freshness states
- A .NET Aspire AppHost that runs the frontend and backend together
- A project-scoped Copilot canvas that presents a compact parking experience directly in the GitHub Copilot app
- A single AI agent that recommends parking from current ApiApp data and explains the trade-offs

The workshop does not cover Azure deployment, databases, MCP servers, future availability forecasting, reservations, or payments.

## Curriculum

| Step | Guide                                                          | Outcome                                             |
| ---: | -------------------------------------------------------------- | --------------------------------------------------- |
| 00   | [Set up the workshop](docs/00-setup.md)                        | Tools, credentials, repository, and running starter |
| 01   | [Generate `AGENTS.md`](docs/01-generate-agents-md.md)          | Repository-aware coding-agent instructions          |
| 02   | [Generate `PRD.md` and `TRD.md`](docs/02-generate-prd-trd.md)  | Reviewed product and technical requirements         |
| 03   | [Implement the application](docs/03-implement-app.md)          | Working frontend and backend                        |
| 04   | [Create a Copilot canvas](docs/04-create-canvas.md)            | Parking UI inside the GitHub Copilot app            |
| 05   | [Implement an AI parking agent](docs/05-implement-ai-agent.md) | Grounded recommendations from current parking data  |

## Prepared Starter

The template includes:

- A buildable .NET 10 Aspire solution with empty ApiApp and WebApp surfaces
- HDB Car Park Information and representative Car Park Availability data
- The published data.gov.sg API contract and sample HTTP request
- API-key setup guides for Google Maps Platform and data.gov.sg
- [`IDEATION.md`](IDEATION.md), the starting product concept
- Bootstrap issues that are created once when a repository is made from this template

Participants create `AGENTS.md`, `PRD.md`, `TRD.md`, application behavior, tests, the canvas extension, and the AI parking agent during the workshop.

## Starter Structure

```text
/
├── .github/
├── data/
├── docs/
├── src/
│   ├── CarparkAvailability.ApiApp/
│   ├── CarparkAvailability.AppHost/
│   ├── CarparkAvailability.ServiceDefaults/
│   └── CarparkAvailability.WebApp/
├── CarparkAvailability.slnx
├── IDEATION.md
└── README.md
```

## Data Acknowledgement

This workshop uses:

- [Car Park Availability](https://data.gov.sg/datasets?formats=API&sort=relevancy&resultId=d_ca933a644e55d34fe21f28b8052fac63)
- [HDB Car Park Information](https://data.gov.sg/datasets/d_23f946fa557947f93a8043bbef41dd09/view)

Contains information from **Car Park Availability** and **HDB Car Park Information**, accessed in August 2026 from [data.gov.sg](https://data.gov.sg/), which is made available under the [Singapore Open Data Licence version 1.0](https://data.gov.sg/open-data-licence). The datasets are provided on an "as is" and "as available" basis. This project is not endorsed by data.gov.sg, HDB, or the Singapore Government.

## Project Information

See [CONTRIBUTING.md](CONTRIBUTING.md), [SUPPORT.md](SUPPORT.md), [SECURITY.md](SECURITY.md), and the [MIT licence](LICENSE).
