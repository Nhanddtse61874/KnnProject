using System.ComponentModel.DataAnnotations;

namespace KnnProject.ViewModels
{
    public class OrderDetailViewModel
    {
        public int ProductId { get; set; }

        public double CurrentPrice { get; set; }

        public int Quantity { get; set; }

        public double TotalLine { get; set; }
    }

    public class CreateOrderDetailViewModel
    {
        [Required]
        public int ProductId { get; set; }


        [Required]
        public double CurrentPrice { get; set; }


        [Required]
        public int Quantity { get; set; }


        [Required]
        public double TotalLine { get; set; }
    }

    public class UpdateOrderDetailViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        public int OrderId { get; set; }


        [Required]
        public int ProductId { get; set; }


        [Required]
        public double CurrentPrice { get; set; }


        [Required]
        public int Quantity { get; set; }


        [Required]
        public double TotalLine { get; set; }
    }
}