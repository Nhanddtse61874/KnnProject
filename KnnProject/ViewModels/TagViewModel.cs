using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class TagViewModel
    {
        public string Name { get; set; }

        public ICollection<TagProduct> TagProducts { get; set; }
    }

    public class CreateTagViewModel
    {
        [Required][MaxLength(255)]
        public string Name { get; set; }

    }

    public class UpdateTagViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

    }


}