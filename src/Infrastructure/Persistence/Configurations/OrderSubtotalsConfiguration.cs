using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
     public class OrderSubtotalsConfiguration : IEntityTypeConfiguration<OrderSubtotals>
    {
        public void Configure(EntityTypeBuilder<OrderSubtotals> builder)
        {
            builder.HasNoKey();

            builder.ToView("Order Subtotals");

            builder.Property(e => e.OrderId).HasColumnName("OrderID");

            builder.Property(e => e.Subtotal).HasColumnType("money");
        }
    }
}