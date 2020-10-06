using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
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
}