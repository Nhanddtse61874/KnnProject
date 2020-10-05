using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models.Config
{
    public class ImageStorageConfig : EntityTypeConfiguration<ImageStorage>
    {
        public ImageStorageConfig()
        {
            ToTable("ImageStorage").HasKey(x => x.Id);

            Property(x => x.ImageUrl).HasMaxLength(255);

            Property(x => x.Alt).IsRequired().HasMaxLength(255);

        }
    }
}