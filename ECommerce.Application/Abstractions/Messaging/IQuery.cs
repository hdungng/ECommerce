using MediatR;

namespace ECommerce.Application.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>;
