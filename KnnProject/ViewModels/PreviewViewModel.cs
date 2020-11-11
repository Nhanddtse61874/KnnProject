using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class PreviewViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public double Star { get; set; }

        public string UserName { get; set; }

        public string Comment { get; set; }
    }

    public class CreatePreviewViewModel
    {
        public int ProductId { get; set; }

        public double Star { get; set; }

        public string UserName { get; set; }

        public string Comment { get; set; }
    }
    public class UpdatePreviewViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public double Star { get; set; }

        public string UserName { get; set; }

        public string Comment { get; set; }
    }
}