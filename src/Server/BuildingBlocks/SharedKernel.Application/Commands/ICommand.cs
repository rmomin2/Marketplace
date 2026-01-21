using MediatR;

namespace Marketplace.SharedKernel.Application.Commands;

public interface ICommand<out TResult> : IRequest<TResult>
{
}

public interface ICommand : IRequest
{
}