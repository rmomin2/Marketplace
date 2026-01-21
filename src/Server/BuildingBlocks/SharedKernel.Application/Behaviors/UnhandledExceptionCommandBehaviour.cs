using Marketplace.SharedKernel.Application.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Marketplace.SharedKernel.Application.Behaviors;

public class UnhandledExceptionCommandBehaviour<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            logger.LogError(ex, "eMarket ItemListings Command: Unhandled Exception for Command {Name} {@Request}",
                requestName, request);

            throw;
        }
    }
}
