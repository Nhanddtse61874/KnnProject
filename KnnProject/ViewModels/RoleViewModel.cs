using KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class RoleViewModel
    {
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}