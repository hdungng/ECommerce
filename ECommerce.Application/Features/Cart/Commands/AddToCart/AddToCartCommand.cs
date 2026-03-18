using ECommerce.Application.Abstractions.Messaging;

namespace ECommerce.Application.Features.Cart.Commands.AddToCart;

public sealed record AddToCartCommand(Guid UserId, Guid ProductId, int Quantity) : ICommand<Guid>;
