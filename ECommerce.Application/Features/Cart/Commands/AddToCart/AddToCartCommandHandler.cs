using ECommerce.Application.Abstractions.Messaging;
using ECommerce.Application.Abstractions.Persistence;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Cart.Commands.AddToCart;

public sealed class AddToCartCommandHandler : ICommandHandler<AddToCartCommand, Guid>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddToCartCommandHandler(ICartRepository cartRepository, IUnitOfWork unitOfWork)
    {
        _cartRepository = cartRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByUserIdAsync(request.UserId, cancellationToken)
            ?? new Cart(request.UserId);

        cart.AddItem(request.ProductId, request.Quantity);

        await _cartRepository.UpsertAsync(cart, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return cart.Id;
    }
}
