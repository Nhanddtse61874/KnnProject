
using Persistence.KnnProject.Models;
using System.Collections.Generic;

namespace KnnProject.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}