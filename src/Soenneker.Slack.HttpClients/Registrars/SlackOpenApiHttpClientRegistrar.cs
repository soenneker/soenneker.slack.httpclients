using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Slack.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Slack.HttpClients.Registrars;

/// <summary>
/// Registers the authenticated Slack HTTP client provider.
/// </summary>
public static class SlackOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds the Slack HTTP client provider as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddSlackOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<ISlackOpenApiHttpClient, SlackOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds the Slack HTTP client provider as a scoped service. Each scope owns its cached workspace clients. <para/>
    /// </summary>
    public static IServiceCollection AddSlackOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<ISlackOpenApiHttpClient, SlackOpenApiHttpClient>();

        return services;
    }
}
