namespace BlazorShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class OrdersProductRecipientsmossoConfiguration : IEntityTypeConfiguration<OrdersProductRecipientsmosso>
    {
        public void Configure(EntityTypeBuilder<OrdersProductRecipientsmosso> OrdersProductRecipientsmosso)
        {
            OrdersProductRecipientsmosso
                .HasKey(op => new { op.Id });

            OrdersProductRecipientsmosso
                .HasOne(op => op.OrderProduct)
                .WithMany(o => o.OrdersProductRecipientsmosso)
                .HasForeignKey(o => o.OrdersProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

           
        }
    }
}
