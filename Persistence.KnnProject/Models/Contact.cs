﻿namespace Persistence.KnnProject.Models
{
    public class Contact : BaseModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        public string Description { get; set; }
    }
}