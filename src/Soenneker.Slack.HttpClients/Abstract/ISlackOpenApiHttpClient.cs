using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Slack.HttpClients.Abstract;

/// <summary>
/// Provides authenticated HTTP clients for one or more Slack workspaces.
/// </summary>
public interface ISlackOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>Gets the client configured by <c>Slack:ApiKey</c> and <c>Slack:ClientBaseUrl</c>.</summary>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);

    /// <summary>Gets a client for a specific Slack API token using the configured base URL.</summary>
    ValueTask<HttpClient> Get(string apiKey, CancellationToken cancellationToken = default);

    /// <summary>Gets a client for a specific Slack connection.</summary>
    ValueTask<HttpClient> Get(string apiKey, string baseUrl, CancellationToken cancellationToken = default);

    /// <summary>Removes and disposes every Slack HTTP client owned by this provider.</summary>
    new void Dispose();

    /// <summary>Asynchronously removes and disposes every Slack HTTP client owned by this provider.</summary>
    new ValueTask DisposeAsync();
}
