using Soenneker.Slack.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Slack.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SlackOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ISlackOpenApiHttpClient _httpclient;

    public SlackOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ISlackOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
