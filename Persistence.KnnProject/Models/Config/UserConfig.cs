using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            ToTable("User").HasKey(x => x.Id);

            Property(x => x.UserName).IsRequired().HasMaxLength(255);

            Property(x => x.PassWord).IsRequired().HasMaxLength(255);

            Property(x => x.Name).IsRequired().HasMaxLength(255);

            Property(x => x.Phone).IsRequired();

            Property(x => x.Address).IsRequired().HasMaxLength(255);

            Property(x => x.Gender).IsRequired();

            Property(x => x.Point).IsRequired();

            HasMany(x => x.Orders)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId);



        }
    }
}