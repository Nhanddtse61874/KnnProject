using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Persistence.KnnProject.Models
{
    public class ColorProduct : BaseModel
    {
        public int ProductId { get; set; }

        public int ColorId { get; set; }

        public Color Color { get; set; }

        public Product Product { get; set; }
    }
}