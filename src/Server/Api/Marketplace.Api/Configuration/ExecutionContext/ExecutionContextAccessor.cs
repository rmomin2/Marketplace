using Marketplace.SharedKernel.Application.ExecutionContext;
using System.Security.Claims;

namespace Marketplace.Api.Configuration.ExecutionContext;

public class ExecutionContextAccessor(IHttpContextAccessor httpContextAccessor)
    : IExecutionContextAccessor
{
    public Guid UserId => Guid.Parse(httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new ApplicationException("Missing User Id"));

    public Guid CorrelationId => Guid.NewGuid();
}
