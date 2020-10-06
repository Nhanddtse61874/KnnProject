using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public Role Role { get; set; }

        public Rank Rank { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}