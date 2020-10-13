using System.Collections.Generic;

namespace Persistence.KnnProject.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }

        public ICollection<Category> SubCategories { get; set; }
    }
}