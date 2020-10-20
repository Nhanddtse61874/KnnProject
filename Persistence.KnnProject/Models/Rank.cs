using System.Collections.Generic;

namespace Persistence.KnnProject.Models
{
    public class Rank : BaseModel
    {
        public string Name { get; set; }

        public int Point { get; set; }

        public ICollection<User> Users { get; set; }
    }
}