using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class SalesByCategoryConfiguration : IEntityTypeConfiguration<SalesByCategory>
    {
        public void Configure(EntityTypeBuilder<SalesByCategory> builder)
        {
            builder.HasNoKey();

            builder.ToView("Sales by Category");

            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

            builder.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(e => e.ProductSales).HasColumnType("money");
        }
    }
}