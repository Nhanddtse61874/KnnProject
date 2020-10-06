using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models
{
    public class SizeProduct : BaseModel
    {
        public int ProductId { get; set; }

        public int SizeId { get; set; }

        public Size Size { get; set; }

        public Product Product { get; set; }
    }
}