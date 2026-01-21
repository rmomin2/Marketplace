namespace Marketplace.Api.Modules.ItemListings.Endpoints;

public static class ItemListingsEndpoints
{
    public static void MapItemListingsEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("item-listings")
            .WithTags("ItemListings");
        
        endpoints.MapItemsV1();
    }
}
