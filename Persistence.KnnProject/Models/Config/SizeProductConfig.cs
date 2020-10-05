using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class SizeProductConfig : EntityTypeConfiguration<SizeProduct>
    {
        public SizeProductConfig()
        {
            ToTable("SizeProduct").HasKey(x => x.id);
        }
    }
}