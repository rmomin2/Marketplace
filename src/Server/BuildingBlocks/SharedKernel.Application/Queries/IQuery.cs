using MediatR;

namespace Marketplace.SharedKernel.Application.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
}