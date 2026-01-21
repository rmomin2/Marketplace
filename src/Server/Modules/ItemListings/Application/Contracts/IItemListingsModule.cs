using Marketplace.SharedKernel.Application.Commands;
using Marketplace.SharedKernel.Application.Queries;

namespace Marketplace.Modules.ItemListings.Application.Contracts;

public interface IItemListingsModule
{
    Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

    Task ExecuteCommandAsync(ICommand command);

    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}
