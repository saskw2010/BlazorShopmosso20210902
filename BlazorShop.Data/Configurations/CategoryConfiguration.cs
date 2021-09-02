namespace BlazorShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    using static ModelConstants.Common;
    using static ModelConstants.Category;

    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category
                .Property(c => c.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            category
                .Property(p => p.ImageSource)
                .HasMaxLength(MaxUrlLength)
                .HasDefaultValue("");

            category
                .Property(p => p.ImageBinary)
                .HasMaxLength(MaxImageBinary)
                .HasDefaultValue("");

            category
                .Property(p => p.Imagepic)
                .HasMaxLength(MaxImagepic).HasDefaultValue("");

            //category
            //    .Property(p => p.Imagebinary)
            //    .HasMaxLength(MaxImagebinaryLength)
            //    .HasColumnType("text") ;

            category
                .HasIndex(c => c.IsDeleted);

            category
                .HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
