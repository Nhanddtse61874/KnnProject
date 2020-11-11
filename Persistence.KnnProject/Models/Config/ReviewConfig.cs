using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.KnnProject.Models.Config
{
    public class ReviewConfig : EntityTypeConfiguration<Review>
    {
        public ReviewConfig()
        {
            ToTable("Review").HasKey(x => x.Id);

            Property(x => x.ProductId).IsRequired();

            Property(x => x.Star).IsRequired();

            Property(x => x.UserName).HasMaxLength(255);

            Property(x => x.Comment).HasMaxLength(255);
        }
    }
}
