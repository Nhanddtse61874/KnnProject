using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class SizeConfig : EntityTypeConfiguration<Size>
    {
        public SizeConfig()
        {
            ToTable("Size").HasKey(x => x.Id);

            Property(x => x.Name).IsRequired().HasMaxLength(10);

            HasMany(x => x.SizeProducts)
                .WithRequired(x => x.Size)
                .HasForeignKey(x => x.SizeId);
                
        }

    }
}