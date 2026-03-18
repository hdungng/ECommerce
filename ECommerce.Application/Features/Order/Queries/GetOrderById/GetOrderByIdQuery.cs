using ECommerce.Application.Abstractions.Messaging;

namespace ECommerce.Application.Features.Order.Queries.GetOrderById;

public sealed record GetOrderByIdQuery(Guid OrderId) : IQuery<OrderDto?>;
public sealed record OrderItemDto(Guid ProductId, int Quantity, decimal PriceAtPurchase);
public sealed record OrderDto(Guid Id, Guid UserId, DateTime OrderedAtUtc, IReadOnlyCollection<OrderItemDto> Items);
