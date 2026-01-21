using Marketplace.Api.Modules.ItemListings.Endpoints;

namespace Marketplace.Api.Configuration.Extensions;

public static class EndpointsExtensions
{
    public static WebApplication MapEndPoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("api/v{version:apiVersion}");
        endpoints.MapItemListingsEndpoints();
        return app;
    }
}
