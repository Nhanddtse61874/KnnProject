using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class SizeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
    }
    public class CreateSizeViewModel
    {

        public int Id { get; set; }
        [Required][MaxLength(255)]
        public string Name { get; set; }
    }

    public class UpdateSizeViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required][MaxLength(255)]
        public string Name { get; set; }
    }
}