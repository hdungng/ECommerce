using ECommerce.Application.Abstractions.Messaging;

namespace ECommerce.Application.Features.Order.Commands.Checkout;

public sealed record CheckoutCommand(Guid UserId) : ICommand<Guid>;
