using KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class ImageStorageViewModel
    {
        public string ImageUrl { get; set; }

        public string Alt { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}