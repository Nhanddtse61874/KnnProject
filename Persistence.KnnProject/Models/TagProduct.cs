﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models
{
    public class TagProduct : BaseModel
    {

        public int ProductId { get; set; }

        public int TagId { get; set; }

        public Product Product { get; set; }

        public Tag Tag { get; set; }
    }
}