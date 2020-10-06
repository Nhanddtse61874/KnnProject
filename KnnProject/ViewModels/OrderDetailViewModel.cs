using Persistence.KnnProject.Models;


namespace KnnProject.ViewModels
{
    public class OrderDetailViewModel
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public double CurrentPrice { get; set; }

        public int Quantity { get; set; }

        public double TotalLine { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}