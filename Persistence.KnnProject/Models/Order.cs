using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistence.KnnProject.Models
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }

        public double TotalPrice { get; set; }

        public string AddressShipping { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }

        public User User { get; set; }

        public ICollection<OrderDetail> Orderdetails { get; set; }

    }
}