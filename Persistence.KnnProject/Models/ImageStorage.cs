using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models
{
    public class ImageStorage
    {

        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Alt { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}