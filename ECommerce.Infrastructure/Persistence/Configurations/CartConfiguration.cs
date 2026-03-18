using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

internal sealed class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserId).IsRequired();

        builder.OwnsMany(x => x.Items, item =>
        {
            item.ToTable("CartItems");
            item.WithOwner().HasForeignKey("CartId");
            item.HasKey("CartId", nameof(CartItem.ProductId));
            item.Property(x => x.ProductId).IsRequired();
            item.Property(x => x.Quantity).IsRequired();
        });
    }
}
