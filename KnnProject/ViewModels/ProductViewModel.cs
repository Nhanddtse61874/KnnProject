using KnnProject.Models;
using System;
using System.Collections.Generic;
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

        public string CategoryName { get; set; }

        public CategoryViewModel Category { get; set; }

        public ICollection<ImageStorage> ImageStorages { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public ICollection<TagProduct> TagProducts { get; set; }

        public ICollection<SizeProduct> SizeProducts { get; set; }

        public ICollection<ColorProduct> ColorProducts { get; set; }
    }
}