
namespace BlazorShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class ShoppingCartProductRecipientsConfiguration : IEntityTypeConfiguration<ShoppingCartProductRecipients>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartProductRecipients> ShoppingCartProductRecipients)
        {
            ShoppingCartProductRecipients
                .HasKey(sc => new { sc.Id });

            ShoppingCartProductRecipients
                .HasOne(sc => sc.ShoppingCart)
                .WithMany(u => u.ProductRecipients)
                .HasForeignKey(sc => sc.ShoppingCartId);

            ShoppingCartProductRecipients
                .HasOne(sc => sc.Product)
                .WithMany(p => p.ShoppingCartProductRecipients)
                .HasForeignKey(sc => sc.ProductId);

            //ShoppingCartProductRecipients
            //   .Property(c => c.Name);

            //ShoppingCartProductRecipients
            //    .Property(p => p.)
            //    .HasMaxLength(MaxUrlLength)
            //    .HasDefaultValue("");

            //ShoppingCartProductRecipients
            //    .Property(p => p.ImageBinary)
            //    .HasMaxLength(MaxImageBinary)
            //    .HasDefaultValue("");

            //ShoppingCartProductRecipients
            //    .Property(p => p.Imagepic)
            //    .HasMaxLength(MaxImagepic).HasDefaultValue("");

            ////category
            ////    .Property(p => p.Imagebinary)
            ////    .HasMaxLength(MaxImagebinaryLength)
            ////    .HasColumnType("text") ;

            //ShoppingCartProductRecipients
            //    .HasIndex(c => c.IsDeleted);

            //ShoppingCartProductRecipients
            //    .HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
