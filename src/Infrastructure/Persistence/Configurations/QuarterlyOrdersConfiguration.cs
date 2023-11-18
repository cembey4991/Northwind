using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class QuarterlyOrdersConfiguration : IEntityTypeConfiguration<QuarterlyOrders>
    {
        public void Configure(EntityTypeBuilder<QuarterlyOrders> builder)
        {
            builder.HasNoKey();

            builder.ToView("Quarterly Orders");

            builder.Property(e => e.City).HasMaxLength(15);

            builder.Property(e => e.CompanyName).HasMaxLength(40);

            builder.Property(e => e.Country).HasMaxLength(15);

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasMaxLength(5)
                .IsFixedLength();
        }
    }
}