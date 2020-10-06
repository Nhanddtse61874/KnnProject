using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Persistence.KnnProject.Models;

namespace Persistence.KnnProject.Models
{
    public class Contact : BaseModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        public string Description { get; set; }
    }
}