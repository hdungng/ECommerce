using ECommerce.Application.Abstractions.Messaging;
using ECommerce.Application.Abstractions.Persistence;

namespace ECommerce.Application.Features.Order.Queries.GetOrderById;

public sealed class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId, cancellationToken);
        if (order is null)
        {
            return null;
        }

        var items = order.Items.Select(i => new OrderItemDto(i.ProductId, i.Quantity, i.PriceAtPurchase)).ToList();
        return new OrderDto(order.Id, order.UserId, order.OrderedAtUtc, items);
    }
}
