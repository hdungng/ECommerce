namespace ECommerce.Domain.Entities;

public sealed class CartItem
{
    private CartItem() { }

    public CartItem(Guid productId, int quantity)
    {
        ProductId = productId;
        SetQuantity(quantity);
    }

    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    public void IncreaseQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity));
        }

        Quantity += quantity;
    }

    public void SetQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity));
        }

        Quantity = quantity;
    }
}
