using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class OrderConfig : EntityTypeConfiguration<Order>
    {
        public OrderConfig()
        {
            ToTable("Order").HasKey(x => x.Id);

            Property(x => x.TotalPrice).IsRequired();

            Property(x => x.AddressShipping).IsRequired().HasMaxLength(255);

            HasMany(x => x.Orderdetails)
                .WithRequired(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }
    }
}