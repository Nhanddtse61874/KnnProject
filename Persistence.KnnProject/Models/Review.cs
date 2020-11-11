using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.KnnProject.Models
{
    public class Review : BaseModel
    {
        public int ProductId { get; set; }

        public double Star { get; set; }

        public string UserName { get; set; }

        public string Comment { get; set; }

        public Product Product { get; set; }
    }
}
