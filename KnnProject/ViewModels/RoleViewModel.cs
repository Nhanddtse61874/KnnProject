using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

    }

    public class CreateRoleViewModel
    {
        [Required][MaxLength(255)]
        public string Description { get; set; }

    }

    public class UpdateRoleViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

    }
}