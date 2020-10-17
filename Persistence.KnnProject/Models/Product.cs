using System;
using System.Collections.Generic;

namespace Persistence.KnnProject.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public bool Status { get; set; }

        public Category Category { get; set; }

        public DateTime CreatedDate{ get; set; }

        public ICollection<ImageStorage> ImageStorages { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public ICollection<TagProduct> TagProducts { get; set; }

        public ICollection<SizeProduct> SizeProducts { get; set; }

        public ICollection<ColorProduct> ColorProducts { get; set; }

       
    }

}