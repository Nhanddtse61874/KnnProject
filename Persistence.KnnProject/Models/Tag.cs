using System.Collections.Generic;

namespace Persistence.KnnProject.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TagProduct> TagProducts { get; set; }
    }
}