using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class OrderDetailConfig : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfig()
        {
            ToTable("OrderDetail").HasKey(x => x.Id);

            Property(x => x.CurrentPrice).IsRequired();

            Property(x => x.TotalLine).IsRequired();

            Property(x => x.Quantity).IsRequired();


        }
    }
}