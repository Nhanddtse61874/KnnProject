﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<User> Users{get; set; }
    } 
}