
using System;
using System.Collections.Generic;
using System.Text;

namespace RecommenceService.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public double CurrentPrice { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

        public double Star { get; set; }

        public Category Category { get; set; }


    }
}
