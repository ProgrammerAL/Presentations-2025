using System.Diagnostics;

namespace OTelDemo.InternalApiService;

public static class ActivitySources
{
    public const string ActivitySourcePrefix = "internal-api-source";
    public const string ActivitySourcesNameWildcard = $"internal-api-source.*";
    public static readonly ActivitySource AppActivitySource = new($"internal-api-source.root");
}
