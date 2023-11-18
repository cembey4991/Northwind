using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
      public  class CurrentProductListConfiguration : IEntityTypeConfiguration<CurrentProductList>
    {
        public void Configure(EntityTypeBuilder<CurrentProductList> builder)
        {
            builder.HasNoKey();

            builder.ToView("Current Product List");

            builder.Property(e => e.ProductId)
                .HasColumnName("ProductID")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}