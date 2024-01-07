using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProductsAboveAveragePriceConfiguration : IEntityTypeConfiguration<ProductsAboveAveragePrice>
    {
        public void Configure(EntityTypeBuilder<ProductsAboveAveragePrice> builder)
        {
            builder.HasNoKey();

            builder.ToView("Products Above Average Price");

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}