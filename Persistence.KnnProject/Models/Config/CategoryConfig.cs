using System.Data.Entity.ModelConfiguration;

namespace Persistence.KnnProject.Models.Config
{
    public class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {
            ToTable("Category").HasKey(x => x.Id);

            Property(x => x.CategoryName).IsRequired().HasMaxLength(255);

            HasMany(x => x.Products)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

        }
    }
}