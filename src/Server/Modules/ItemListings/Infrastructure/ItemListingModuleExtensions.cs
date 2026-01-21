using Marketplace.Modules.ItemListings.Application.Contracts;
using Marketplace.Modules.ItemListings.Application.UseCases.Models;
using Marketplace.SharedKernel.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Marketplace.Modules.ItemListings.Infrastructure;

public static class ItemListingModuleExtensions
{
    public static readonly Assembly Application = typeof(ItemDto).Assembly;

    public static void AddItemListingsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddMediator()
            .AddMappings()
            .AddModule();
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Application);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceCommandBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceQueryBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingCommandBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingQueryBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionCommandBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionQueryBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationCommandBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationQueryBehaviour<,>));

        });

        return services;
    }

    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddMaps(Application));
        return services;
    }

    private static IServiceCollection AddModule(this IServiceCollection services)
    {
        services.AddScoped<IItemListingsModule, ItemListingsModule>();
        return services;
    }
}
