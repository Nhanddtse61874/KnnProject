using KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnnProject.ViewModels
{
    public class OrderViewModel
    {
        public int UserId { get; set; }

        public double TotolPrice { get; set; }

        public string AddressShipping { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }

        public User User { get; set; }

        public ICollection<OrderDetail> Orderdetails { get; set; }
    }
}