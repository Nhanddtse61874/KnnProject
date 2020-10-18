using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public bool Status { get; set; }

        public DateTime DateTime { get; set; }

        public IEnumerable<ColorViewModel> Colors { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public IEnumerable<SizeViewModel> Sizes { get; set; }

        public IEnumerable<ImageStorageViewModel> ImageStorages { get; set; }
    }

    public class CreateProductViewModel
    {
        [Required]
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public bool Status { get; set; }

        public IEnumerable<int> Colors { get; set; }

        public IEnumerable<int> Tags { get; set; }

        public IEnumerable<int> Sizes { get; set; }

    }

    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public bool Status { get; set; }

        public DateTime DateTime { get; set; }

        public IEnumerable<ColorViewModel> Colors { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public IEnumerable<SizeViewModel> Sizes { get; set; }
    }
}