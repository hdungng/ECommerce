using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public sealed class Cart : BaseEntity
{
    private readonly List<CartItem> _items = [];

    private Cart() { }

    public Cart(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; private set; }
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    public void AddItem(Guid productId, int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        }

        var existing = _items.SingleOrDefault(i => i.ProductId == productId);
        if (existing is null)
        {
            _items.Add(new CartItem(productId, quantity));
        }
        else
        {
            existing.IncreaseQuantity(quantity);
        }

        MarkUpdated();
    }

    public void RemoveItem(Guid productId)
    {
        var existing = _items.SingleOrDefault(i => i.ProductId == productId);
        if (existing is null)
        {
            return;
        }

        _items.Remove(existing);
        MarkUpdated();
    }

    public void UpdateQuantity(Guid productId, int quantity)
    {
        var existing = _items.SingleOrDefault(i => i.ProductId == productId)
            ?? throw new InvalidOperationException("Item does not exist in the cart.");

        if (quantity <= 0)
        {
            _items.Remove(existing);
        }
        else
        {
            existing.SetQuantity(quantity);
        }

        MarkUpdated();
    }
}
