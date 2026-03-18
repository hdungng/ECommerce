using ECommerce.Application.Abstractions.Messaging;

namespace ECommerce.Application.Features.Cart.Queries.GetCartByUserId;

public sealed record GetCartByUserIdQuery(Guid UserId) : IQuery<CartDto?>;
public sealed record CartItemDto(Guid ProductId, int Quantity);
public sealed record CartDto(Guid Id, Guid UserId, IReadOnlyCollection<CartItemDto> Items);
