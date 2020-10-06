using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models
{
    public class Size : BaseModel
    {
        public string Name { get; set; }

        public ICollection<SizeProduct> SizeProducts { get; set; }
    }
}