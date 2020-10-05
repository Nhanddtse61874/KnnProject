using System.Collections.Generic;

namespace Persistence.KnnProject.Models
{
    public class Color : BaseModel
    {
        public string Name { get; set; }

        public ICollection<ColorProduct> ColorProducts { get; set;}
    }
}