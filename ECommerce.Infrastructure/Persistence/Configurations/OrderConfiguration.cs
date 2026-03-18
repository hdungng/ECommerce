using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.OrderedAtUtc).IsRequired();

        builder.OwnsMany(x => x.Items, item =>
        {
            item.ToTable("OrderItems");
            item.WithOwner().HasForeignKey("OrderId");
            item.HasKey("OrderId", nameof(OrderItem.ProductId));
            item.Property(x => x.ProductId).IsRequired();
            item.Property(x => x.Quantity).IsRequired();
            item.Property(x => x.PriceAtPurchase).HasColumnType("decimal(18,2)").IsRequired();
        });
    }
}
