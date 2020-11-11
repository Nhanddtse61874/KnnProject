using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnnProject.ViewModels
{
    public class ProductViewModel
    {
        
        public int Id { get; set; }


       
        public string Name { get; set; }

        
        public double Price { get; set; }

       
        public int Quantity { get; set; }

        public double Star { get; set; }
        public string Description { get; set; }

        public string Code { get; set; }
        public double CurrenPrice { get; set; }
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
        [Required][MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double CurrenPrice { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required, MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
       
        [Required]
        public double Star { get; set; }

        [Required]
        public bool Status { get; set; }

        public IEnumerable<int> Colors { get; set; }

        public IEnumerable<int> Tags { get; set; }

        public IEnumerable<int> Sizes { get; set; }

    }

    public class UpdateProductViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Code { get; set; }
        
        [Required]
        public double CurrenPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required, MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        [Required]
        public double Star { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public IEnumerable<ColorViewModel> Colors { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }

        public IEnumerable<SizeViewModel> Sizes { get; set; }

    }

   
}