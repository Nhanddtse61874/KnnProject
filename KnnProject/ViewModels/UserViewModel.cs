using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnnProject.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public int RankId { get; set; }

        public int RoleId { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public string Address { get; set; }

        public bool Gender { get; set; }

        public double Point { get; set; }

        public IEnumerable<OrderViewModel> Orders { get; set; }
    }

    public class CreateUserViewModel
    {

        [Required, MaxLength(255)]
        public string UserName { get; set; }

        [Required, MaxLength(255)]
        public string PassWord { get; set; }

        [Required]
        public int RankId { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required, MaxLength(255)]
        public string Address { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public double Point { get; set; }

        public IEnumerable<Order> Orders { get; set; }

    }

    public class UpdateUserViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string UserName { get; set; }

        [Required, MaxLength(255)]
        public string PassWord { get; set; }

        [Required]
        public int RankId { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required, MaxLength(255)]
        public string Address { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public double Point { get; set; }


    }
   
}