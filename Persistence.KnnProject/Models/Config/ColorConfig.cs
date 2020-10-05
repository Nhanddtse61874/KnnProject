using System.Data.Entity.ModelConfiguration;

namespace Persistence.KnnProject.Models.Config
{
    public class ColorConfig : EntityTypeConfiguration<Color>
    {
        public ColorConfig()
        {
            ToTable("Color").HasKey(x => x.Id);

            Property(x => x.Name).IsRequired().HasMaxLength(10);

            HasMany(x => x.ColorProducts)
                .WithRequired(x => x.Color)
                .HasForeignKey(x => x.ColorId);
        }
    }
}