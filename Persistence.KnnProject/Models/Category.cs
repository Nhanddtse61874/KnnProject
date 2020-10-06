using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models
{
    public class Category : BaseModel
    {
            public string CategoryName { get; set; }

            public ICollection<Product> Products { get; set; }
       
    }
}