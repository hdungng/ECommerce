using ECommerce.Application.Abstractions.Messaging;

namespace ECommerce.Application.Features.Order.Commands.Checkout;

public sealed class CheckoutCommandHandler : ICommandHandler<CheckoutCommand, Guid>
{
    public Task<Guid> Handle(CheckoutCommand request, CancellationToken cancellationToken)
    {
        // Intentionally left as a scaffold. Checkout orchestration and payment workflow
        // should be implemented with domain services and transactional boundaries.
        throw new NotImplementedException("Checkout flow is not implemented in this scaffold.");
    }
}
