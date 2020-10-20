using System.Collections.Generic;

namespace Persistence.KnnProject.Models
{
    public class Size : BaseModel
    {
        public string Name { get; set; }

        public ICollection<SizeProduct> SizeProducts { get; set; }
    }
}