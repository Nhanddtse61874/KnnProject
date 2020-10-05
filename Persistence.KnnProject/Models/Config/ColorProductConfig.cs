using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class ColorProductConfig : EntityTypeConfiguration<ColorProduct>
    {
        public ColorProductConfig()
        {
            ToTable("ColorProduct").HasKey(x => x.Id);
        }
    }
}