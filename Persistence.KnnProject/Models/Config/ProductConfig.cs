using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        public ProductConfig()
        {
            ToTable("Product").HasKey(x => x.Id);

            Property(x => x.Name).IsRequired().HasMaxLength(255);

            Property(x => x.Price).IsRequired();

            Property(x => x.Quantity).IsRequired();

            Property(x => x.Description).IsRequired().HasMaxLength(255);

            Property(x => x.Status).IsRequired();

            Property(x => x.CreatedDate).IsRequired();

        HasMany(x => x.ImageStorages)
                .WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            HasMany(x => x.OrderDetails)
                .WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            HasMany(x => x.ColorProducts)
                .WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            HasMany(x => x.TagProducts)
                .WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            HasMany(x => x.SizeProducts)
                .WithRequired(x => x.Product)
                .HasForeignKey(x => x.ProductId);
        }
    }
}