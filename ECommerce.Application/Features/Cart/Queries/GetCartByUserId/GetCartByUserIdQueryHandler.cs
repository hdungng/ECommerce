using ECommerce.Application.Abstractions.Messaging;
using ECommerce.Application.Abstractions.Persistence;

namespace ECommerce.Application.Features.Cart.Queries.GetCartByUserId;

public sealed class GetCartByUserIdQueryHandler : IQueryHandler<GetCartByUserIdQuery, CartDto?>
{
    private readonly ICartRepository _cartRepository;

    public GetCartByUserIdQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<CartDto?> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByUserIdAsync(request.UserId, cancellationToken);
        if (cart is null)
        {
            return null;
        }

        var items = cart.Items.Select(i => new CartItemDto(i.ProductId, i.Quantity)).ToList();
        return new CartDto(cart.Id, cart.UserId, items);
    }
}
