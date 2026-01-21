using Asp.Versioning;
using Marketplace.Api.Configuration.ExecutionContext;
using Marketplace.Modules.ItemListings.Infrastructure;
using Marketplace.SharedKernel.Application.ExecutionContext;

namespace Marketplace.Api.Configuration.Extensions;

public static class ApplicationServicesExtensions
{
    public static IHostApplicationBuilder AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder
            .ConfigureOpenTelemetry()
            .AddHealthChecks()
            .AddDefaultOpenApi()
            .AddDefaultAuthentication()
            .AddHttpContext()
            .AddModules();
        return builder;
    }

    private static IHostApplicationBuilder AddHttpContext(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();
        return builder;
    }

    internal static IHostApplicationBuilder AddModules(this IHostApplicationBuilder builder)
    {
        builder.Services.AddItemListingsModule(builder.Configuration);
       
        return builder;
    }
}
