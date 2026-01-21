namespace Marketplace.SharedKernel.Application.Pagination;

public class PaginatedList<TEntity>(
    List<TEntity> data,
    int count,
    int pageNumber,
    int pageSize)
    where TEntity : class
{
    public List<TEntity> Data { get; } = data;
    public int PageNumber { get; } = pageNumber;
    public int PageSize { get; } = pageSize;
    public int TotalPages { get; } = (int)Math.Ceiling(count / (double)pageSize);
    public int TotalCount { get; } = count;
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public static PaginatedList<TEntity> CreateAsync(List<TEntity> items, int totalCount, int pageNumber, int pageSize) =>
        //var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        new PaginatedList<TEntity>(items, totalCount, pageNumber, pageSize);
}
