using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public sealed class Category : BaseEntity
{
    private Category() { }

    public Category(string name)
    {
        Rename(name);
    }

    public string Name { get; private set; } = string.Empty;

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Category name is required.", nameof(name));
        }

        Name = name.Trim();
        MarkUpdated();
    }
}
