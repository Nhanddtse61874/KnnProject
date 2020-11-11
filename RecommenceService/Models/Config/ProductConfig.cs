using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace RecommenceService.Models.Config
{
   public  class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            ToTable("Product").HasKey(x => x.Id);

            Property(x => x.Name).IsRequired().HasMaxLength(255);

            Property(x => x.CategoryId).IsRequired();

            Property(x => x.Price).IsRequired();

            Property(x => x.CurrentPrice).IsRequired();

            Property(x => x.Star).IsRequired();

        }

    }
}
