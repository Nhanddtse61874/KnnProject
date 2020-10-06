using System.Collections.Generic;

namespace Persistence.KnnProject.Models
{
    public class Tag : BaseModel
    {
        public string Name { get; set; }

        public ICollection<TagProduct> TagProducts { get; set; }
    }
}