using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AlphabeticalListOfProductsConfiguration : IEntityTypeConfiguration<AlphabeticalListOfProducts>
    {
        public void Configure(EntityTypeBuilder<AlphabeticalListOfProducts> builder)
        {
            
                builder.HasNoKey();

                builder.ToView("Alphabetical list of products");

                builder.Property(e => e.CategoryId)
                      .HasColumnName("CategoryID");

                builder.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15);

                builder.Property(e => e.ProductId).HasColumnName("ProductID");

                builder.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40);

                builder.Property(e => e.QuantityPerUnit).HasMaxLength(20);

                builder.Property(e => e.SupplierId).HasColumnName("SupplierID");

                builder.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}