namespace BlazorShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    using static ModelConstants.Common;
    using static ModelConstants.Product;

    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            product
                .Property(p => p.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            product
                .Property(p => p.Description)
                .HasMaxLength(MaxDescriptionLength);
            product
                .Property(p => p.ProductCode)
                .HasMaxLength(MaxProductCodeLength);
                //.IsRequired();

            product
                .Property(p => p.ImageSource)
                .HasMaxLength(MaxUrlLength);
                //.IsRequired();

            //product
            //    .Property(p => p.Imagebinary)
            //    .HasMaxLength(MaxImagebinaryLength)
            //    .HasColumnType("text");
            product
                .Property(p => p.PriceBeforeDiscount)
                .HasColumnType("decimal(18,2)");

            product
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            product
                .Property(p => p.PriceType) ;

            product
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            product
                .HasIndex(p => p.IsDeleted);

            product
                .HasQueryFilter(p => !p.IsDeleted);
        }
    }
}