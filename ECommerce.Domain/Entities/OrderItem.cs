namespace ECommerce.Domain.Entities;

public sealed class OrderItem
{
    private OrderItem() { }

    public OrderItem(Guid productId, int quantity, decimal priceAtPurchase)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity));
        }

        if (priceAtPurchase <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(priceAtPurchase));
        }

        ProductId = productId;
        Quantity = quantity;
        PriceAtPurchase = priceAtPurchase;
    }

    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal PriceAtPurchase { get; private set; }
}
