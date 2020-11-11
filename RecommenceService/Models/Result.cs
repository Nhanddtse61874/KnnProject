using System;
using System.Collections.Generic;
using System.Text;

namespace RecommenceService.Models
{
    public class Result
    {
        public int Id { get; set; }

        public int userId { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
