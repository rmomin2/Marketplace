using AutoMapper;
using Marketplace.Modules.ItemListings.Application.UseCases.Models;
using Marketplace.SharedKernel.Application.Pagination;
using Marketplace.SharedKernel.Application.Queries;

namespace Marketplace.Modules.ItemListings.Application.UseCases.Items.Queries.GetItemsWithPagination;

internal class GetItemsWithPaginationQueryHandler(
    IMapper mapper) : IQueryHandler<GetItemsWithPaginationQuery, PaginatedList<ItemDto>>
{
    public Task<PaginatedList<ItemDto>> Handle(GetItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var list = new List<ItemDto>
        {
            new ItemDto
            {
                Id = Guid.NewGuid(),
                Title = "Sample Item 1",
                Price = 19.99m,
                ListedAt = DateTime.UtcNow.AddDays(-2)
            },
            new ItemDto
            {
                Id = Guid.NewGuid(),
                Title = "Sample Item 2",
                Price = 29.99m,
                ListedAt = DateTime.UtcNow.AddDays(-1)
            }
        };
        return Task.FromResult(new PaginatedList<ItemDto>(list, 2, 0, 0));
    }
}
