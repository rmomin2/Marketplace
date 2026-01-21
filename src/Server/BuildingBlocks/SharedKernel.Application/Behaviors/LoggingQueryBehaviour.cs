using Marketplace.SharedKernel.Application.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Marketplace.SharedKernel.Application.Behaviors;

/// <summary>
/// Represents a logging behavior for query handlers.
/// </summary>
/// <typeparam name="TRequest">The type of the query request.</typeparam>
/// <typeparam name="TResponse">The type of the query response.</typeparam>
public class LoggingQueryBehaviour<TRequest, TResponse>(ILogger<TRequest> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IQuery<TResponse>
{
    /// <summary>
    /// Handles the query request and logs the information.
    /// </summary>
    /// <param name="request">The query request.</param>
    /// <param name="next">The next handler delegate.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The query response.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        logger.LogInformation("eMarket ItemLisitngs Query: {Name} {@Request}", requestName, request);

        return await next();
    }
}