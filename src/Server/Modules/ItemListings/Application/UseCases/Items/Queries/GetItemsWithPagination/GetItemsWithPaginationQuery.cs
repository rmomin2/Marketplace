using Marketplace.Modules.ItemListings.Application.UseCases.Models;
using Marketplace.SharedKernel.Application.Pagination;
using Marketplace.SharedKernel.Application.Queries;

namespace Marketplace.Modules.ItemListings.Application.UseCases.Items.Queries.GetItemsWithPagination;

public record GetItemsWithPaginationQuery : IQuery<PaginatedList<ItemDto>>
{
    public int? PageNumber { get; init; } = 1;

    public int? PageSize { get; init; } = 10;

    public string? SearchTerm { get; init; } = "";
}
