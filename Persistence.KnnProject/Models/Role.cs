using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models
{
    public class Role : BaseModel
    {
        public string Description { get; set; }

        public ICollection<User> Users{get; set; }
    } 
}