[![](https://img.shields.io/nuget/v/soenneker.slack.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.slack.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.slack.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.slack.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.slack.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.slack.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.slack.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.slack.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Slack.HttpClients

Provides reusable, bearer-authenticated `HttpClient` instances for Slack's Web API, including multi-workspace applications.

## Installation

```bash
dotnet add package Soenneker.Slack.HttpClients
```

## Configuration

```json
{
  "Slack": {
    "ApiKey": "xoxb-your-bot-token"
  }
}
```

`Slack:ClientBaseUrl`, `Slack:AuthHeaderName`, and `Slack:AuthHeaderValueTemplate` can override the defaults.

## Usage

```csharp
using Soenneker.Slack.HttpClients.Abstract;
using Soenneker.Slack.HttpClients.Registrars;

services.AddSlackOpenApiHttpClientAsSingleton();

HttpClient client = await slackHttpClient.Get(cancellationToken);
using var form = new FormUrlEncodedContent([]);
HttpResponseMessage response = await client.PostAsync(
    "api/auth.test",
    form,
    cancellationToken);
```

The parameterless `Get()` uses `Slack:ApiKey` and `Slack:ClientBaseUrl`. Pass connection values explicitly to work with multiple Slack tenants:

```csharp
HttpClient tenantClient = await slackOpenApiHttpClient.Get(tenantApiKey, tenantBaseUrl);
```

Clients are cached per token and base URL within a provider instance. Disposing the provider removes and disposes every client it created; scoped providers do not share ownership with other scopes.
