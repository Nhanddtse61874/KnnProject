using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class ImageStorageViewModel
    {
        public string ImageUrl { get; set; }

        public string Alt { get; set; }

        public int ProductId { get; set; }

    }
    public class CreateImageStorageViewModel
    {
        [Required]
        public string ImageUrl { get; set; }


        [Required][MaxLength(255)]
        public string Alt { get; set; }

        [Required]
        public int ProductId { get; set; }

    }

    public class UpdateImageStorageViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        public string ImageUrl { get; set; }


        [Required]
        [MaxLength(255)]
        public string Alt { get; set; }

        [Required]
        public int ProductId { get; set; }

    }
}