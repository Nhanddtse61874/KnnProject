using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnnProject.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<CategoryViewModel> SubCategories { get; set; }
    }

    public class CreateCategoryViewModel
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }

        public int? ParentId { get; set; }
    }

    public class ModifiedCategoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        public int? ParentId { get; set; }
    }
}