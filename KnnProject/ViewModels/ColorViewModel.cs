using KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class ColorViewModel
    {
        public string Name { get; set; }

        public ICollection<ColorProduct> ColorProducts { get; set; }
    }
}