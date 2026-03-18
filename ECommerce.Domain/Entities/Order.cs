using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public sealed class Order : BaseEntity
{
    private readonly List<OrderItem> _items = [];

    private Order() { }

    public Order(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; private set; }
    public DateTime OrderedAtUtc { get; private set; } = DateTime.UtcNow;
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public void AddItem(Guid productId, int quantity, decimal priceAtPurchase)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity));
        }

        if (priceAtPurchase <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(priceAtPurchase));
        }

        _items.Add(new OrderItem(productId, quantity, priceAtPurchase));
        MarkUpdated();
    }
}
