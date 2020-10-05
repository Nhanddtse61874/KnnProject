using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class RoleConfig : EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {
            ToTable("Role").HasKey(x => x.Id);

            Property(x => x.Description).IsRequired().HasMaxLength(255);
        }
    }
}