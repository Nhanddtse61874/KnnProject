using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class ContactConfig : EntityTypeConfiguration<Contact>
    {
        public ContactConfig()
        {
            ToTable("Contact").HasKey(x => x.Id);

            Property(x => x.Name).IsRequired().HasMaxLength(225);

            Property(x => x.Phone).IsRequired();

            Property(x => x.Description).IsRequired().HasMaxLength(255);

            Property(x => x.Address).IsRequired().HasMaxLength(255);
        }
    }
}