using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class RankConfig : EntityTypeConfiguration<Rank>
    {
        public RankConfig()
        {
            ToTable("Rank").HasKey(x => x.Id);

            Property(x => x.Name).IsRequired().HasMaxLength(255);

            Property(x => x.Point).IsRequired();

            HasMany(x => x.Users);
        }
    }
}