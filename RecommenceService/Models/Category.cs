using RecommenceService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecommenceService.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
