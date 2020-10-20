using System.Collections.Generic;

namespace Persistence.KnnProject.Models
{
    public class Role : BaseModel
    {
        public string Description { get; set; }

        public ICollection<User> Users{get; set; }
    } 
}