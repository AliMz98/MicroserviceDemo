using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWebApi.Domain.Entities;

namespace ProductWebApi.Infrastructure.Persistence.Configuraitons
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .HasMaxLength(50);
        }
    }
}
