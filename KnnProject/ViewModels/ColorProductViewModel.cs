using KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class ColorProductViewModel
    { 
        public int ProductId { get; set; }

        public int ColorId { get; set; }

        public Color Color { get; set; }

        public Product Product { get; set; }
    }
}