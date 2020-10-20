using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnnProject.ViewModels
{
    public class OrderViewModel
    {
        public int UserId { get; set; }

        public double TotolPrice { get; set; }

        public string AddressShipping { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }

        public ICollection<OrderDetailViewModel> Orderdetails { get; set; }
    }
    public class CreateOrderViewModel
    {
        [Required]
        public int UserId { get; set; }


        [Required]
        public double TotolPrice { get; set; }


        [Required][MaxLength(225)]
        public string AddressShipping { get; set; }


        [Required]
        public DateTime Date { get; set; }


        [Required]
        public bool Status { get; set; }

        public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }
    }

    public class UpdateOrderViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        public int UserId { get; set; }


        [Required]
        public double TotolPrice { get; set; }


        [Required]
        [MaxLength(225)]
        public string AddressShipping { get; set; }


        [Required]
        public DateTime Date { get; set; }


        [Required]
        public bool Status { get; set; }

        public IEnumerable<OrderDetailViewModel> OrderDetails { get; set; }

    }
}