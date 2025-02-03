using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
       // .HasPrecision(18, 2);  // Add this line
        builder.Property(x => x.Name).IsRequired();
    }
}



// public void Configure(EntityTypeBuilder<Product> builder)
// {
//     builder.Property(x => x.Price)
//            .HasColumnType("decimal(18,2)")
//            .HasPrecision(18, 2);  // Add this line
//     builder.Property(x => x.Name).IsRequired();
// }
