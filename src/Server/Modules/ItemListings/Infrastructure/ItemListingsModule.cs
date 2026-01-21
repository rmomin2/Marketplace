using Marketplace.Modules.ItemListings.Application.Contracts;
using Marketplace.SharedKernel.Application.Commands;
using Marketplace.SharedKernel.Application.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Modules.ItemListings.Infrastructure;

public class ItemListingsModule(IServiceScopeFactory serviceFactory) : IItemListingsModule
{
    public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
    {
        using var scope = serviceFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        return await mediator.Send(command);
    }

    public async Task ExecuteCommandAsync(ICommand command)
    {
        using var scope = serviceFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        await mediator.Send(command);
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
    {
        using var scope = serviceFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        return await mediator.Send(query);
    }
}
