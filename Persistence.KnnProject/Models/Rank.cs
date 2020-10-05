using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models
{
    public class Rank
    {
        public int Id{ get; set; }

        public string Name { get; set; }

        public int Point { get; set; }

        public ICollection<User> Users { get; set; }
    }
}