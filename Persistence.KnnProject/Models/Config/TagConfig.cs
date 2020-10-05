using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class TagConfig : EntityTypeConfiguration<Tag>
    {
        public TagConfig()
        {
            ToTable("Tag").HasKey(x => x.Id);

            Property(x => x.Name).IsRequired().HasMaxLength(20);

            HasMany(x => x.TagProducts)
                .WithRequired(x => x.Tag)
                .HasForeignKey(x => x.TagId);
        }
    }
}