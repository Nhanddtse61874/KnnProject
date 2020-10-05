using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class TagProductConfig : EntityTypeConfiguration<TagProduct>
    {
        public TagProductConfig()
        {
            ToTable("TagProduct").HasKey(x => x.Id);

        }
    }
}