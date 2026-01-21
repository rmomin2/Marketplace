using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Marketplace.Api.Configuration.Extensions;

public static class HealthCheckExtension
{
    public static IHostApplicationBuilder AddHealthChecks(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);
        return builder;
    }
}