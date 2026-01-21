namespace Marketplace.SharedKernel.Application.ExecutionContext;

public interface IExecutionContextAccessor
{
    Guid UserId { get; }
    Guid CorrelationId { get; }
}
