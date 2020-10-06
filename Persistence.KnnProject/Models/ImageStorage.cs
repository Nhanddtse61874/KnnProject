using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Persistence.KnnProject.Models;

namespace Persistence.KnnProject.Models
{
    public class ImageStorage : BaseModel
    {
        public string ImageUrl { get; set; }

        public string Alt { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}