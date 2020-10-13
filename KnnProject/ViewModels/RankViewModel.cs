using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class RankViewModel
    {
        public string Name { get; set; }

        public int Point { get; set; }

        public ICollection<User> Users { get; set; }
    }

    public class CreateRankViewModel{
        [Required][MaxLength(255)]
        public string Name { get; set; }
        
        [Required]
        public int Point { get; set; }

    }
    public class UpdateRankViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Point { get; set; }

    }
}