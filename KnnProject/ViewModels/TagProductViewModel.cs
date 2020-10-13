using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class TagProductViewModel
    {
        public int ProductId { get; set; }

        public int TagId { get; set; }

        public Product Product { get; set; }

        public Tag Tag { get; set; }
    }

    public class CreateTagProductViewModel
    {

    }
}