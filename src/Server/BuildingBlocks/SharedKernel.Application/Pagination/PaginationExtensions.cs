namespace Marketplace.SharedKernel.Application.Pagination;

public static class PaginationExtensions
{
    public static PaginatedList<TDestination> ToPaginatedList<TDestination>(
        this List<TDestination> source,
        int totalCount,
        int pageNumber,
        int pageSize)
        where TDestination : class => PaginatedList<TDestination>.CreateAsync(source, totalCount, pageNumber, pageSize);
}
