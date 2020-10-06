﻿using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class SizeViewModel
    {
        public string Name { get; set; }

        public ICollection<SizeProduct> SizeProducts { get; set; }
    }
}