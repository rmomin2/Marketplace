
using Marketplace.Modules.ItemListings.Application.Contracts;
using Marketplace.Modules.ItemListings.Application.UseCases.Items.Queries.GetItemsWithPagination;
using Marketplace.Modules.ItemListings.Application.UseCases.Models;
using Marketplace.SharedKernel.Application.Pagination;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Marketplace.Api.Modules.ItemListings.Endpoints;

public static class Items
{
    public static void MapItemsV1(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("/items")
            .WithApiVersionSet()
            .HasApiVersion(1, 0);

        endpoints.MapGet("/", GetItemsWithPaginationAsync);//.RequireAuthorization();
    }

    private static async Task<Ok<PaginatedList<ItemDto>>> GetItemsWithPaginationAsync(
        IItemListingsModule module,
        [AsParameters] GetItemsWithPaginationQuery query)
    {
        var items = await module.ExecuteQueryAsync(query);
        return TypedResults.Ok(items);
    }
}
