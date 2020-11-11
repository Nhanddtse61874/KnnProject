
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace RecommenceService.Models.Config
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            ToTable("User").HasKey(x => x.Id);

            Property(x => x.Name).IsRequired().HasMaxLength(255);
        }
    }
}
