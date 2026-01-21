using MediatR;
using Microsoft.Extensions.Logging;
using Marketplace.SharedKernel.Application.Commands;

namespace Marketplace.SharedKernel.Application.Behaviors;

/// <summary>
/// Represents a logging behavior for commands.
/// </summary>
/// <typeparam name="TRequest">The type of the command request.</typeparam>
/// <typeparam name="TResponse">The type of the command response.</typeparam>
public class LoggingCommandBehaviour<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    /// <summary>
    /// Handles the command request.
    /// </summary>
    /// <param name="request">The command request.</param>
    /// <param name="next">The next handler delegate.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The command response.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        logger.LogInformation("eMarket ItemListings Command: {Name} {@Request}", requestName, request);

        return await next();
    }
}

