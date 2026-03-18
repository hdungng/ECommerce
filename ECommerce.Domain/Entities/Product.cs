using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public sealed class Product : BaseEntity
{
    private Product() { }

    public Product(string name, decimal price, int stock, Guid categoryId)
    {
        SetName(name);
        SetPrice(price);
        SetStock(stock);
        CategoryId = categoryId;
    }

    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public Guid CategoryId { get; private set; }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name is required.", nameof(name));
        }

        Name = name.Trim();
        MarkUpdated();
    }

    public void SetPrice(decimal price)
    {
        if (price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Price must be greater than zero.");
        }

        Price = price;
        MarkUpdated();
    }

    public void SetStock(int stock)
    {
        if (stock < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(stock), "Stock cannot be negative.");
        }

        Stock = stock;
        MarkUpdated();
    }

    public void DecreaseStock(int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        }

        if (Stock < quantity)
        {
            throw new InvalidOperationException("Insufficient stock.");
        }

        Stock -= quantity;
        MarkUpdated();
    }
}
