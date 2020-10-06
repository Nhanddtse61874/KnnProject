using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class TagViewModel
    {
        public string Name { get; set; }

        public ICollection<TagProduct> TagProducts { get; set; }
    }
}