using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace Business.KnnProject.Services
{
    public interface IKNearestNeighborService
    {

        IList<Order> GetOrderByUser(int userId);

        IList<OrderDetail> GetOrderDetailByOrder(IList<Order> orders);

        IList<ProductRecommence> GetProductCodeByOrderDetail(IList<OrderDetail> orderdetails);

        IList<List<ProductRecommence>> GetAllUsersAndAllProductCodesToRecommend(int userId);

        IList<ProductRecommence> GetAllProductCodeByUserIdToRecommend(int userId);

        Recommence GetRecommenceData(int userId);

        IList<Product> GetBestSellerProducts();

        IList<Product> GetProductByOrderDetail(IList<OrderDetail> orderdetails);

    }

    public class KNearestNeighborService : ServiceBase, IKNearestNeighborService
    {
        private int k = 2;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public KNearestNeighborService()
        {
            _userService = new UserService();
            _orderService = new OrderService();
            _productService = new ProductService();
        }

        //return a list of products for using to suggest for customer who is logging
        //K nearest neighbor

        public IList<ProductRecommence> GetAllProductCodeByUserIdToRecommend(int userId)
        {
            var result = GetProductCodeByOrderDetail(GetOrderDetailByOrder(GetOrderByUser(userId)));

            return result;
        }

        public IList<Product> GetBestSellerProducts()
        {
            IEnumerable<Product> products = new List<Product>();
            var listuser = _userService.Get();
            foreach (var item in listuser)
            {
                var result = GetProductByOrderDetail(GetOrderDetailByOrder(GetOrderByUser(item.Id)));
                products = products.Concat(result);
            }
            var list = from Product in products
                       group Product by Product into groupProduct
                       select new
                       {
                           product = groupProduct.Key,
                           count = groupProduct.Count()
                       };
            var listOrderBySeller = list.OrderByDescending(x => x.count).Select(x => x.product);
            
            return listOrderBySeller.ToList();
        }

        //get all products of logging user!!
        

        public IList<List<ProductRecommence>> GetAllUsersAndAllProductCodesToRecommend(int userId)
        {
            IList<List<ProductRecommence>> listproducts = new List<List<ProductRecommence>>();
            var user = _userService.GetById(userId);
            if(user != null) {
                var listUser = _userService.GetByRank(user.RankId);
                foreach (var item in listUser)
                {
                    if (item != user)
                    {
                        var list = GetAllProductCodeByUserIdToRecommend(item.Id);
                        listproducts.Add(list.ToList());
                    }
                }
            }else
            {
                return null;
            }
            
            return listproducts;
        }

        public Recommence GetRecommenceData(int userId)
        {
            var productCodesOfUserLogging = GetAllProductCodeByUserIdToRecommend(userId);

            var listProductData = GetAllUsersAndAllProductCodesToRecommend(userId);

            return new Recommence(userId, productCodesOfUserLogging, listProductData);
        }

        //Get List<Order> from User
        public IList<Order> GetOrderByUser(int userId)
        {
            var result = _orderService.GetByUser(userId);
            return result;
        }

        //Get List<orderdetail> from user to get all products in purchase history
        public IList<OrderDetail> GetOrderDetailByOrder(IList<Order> orders)
        {
            IList<OrderDetail> orderdetails = new List<OrderDetail>();
            foreach (var item in orders)
            {
                var list = item.Orderdetails.ToList();
                orderdetails = orderdetails.Concat(list).ToList();
            }
            return orderdetails;
        }

        //Get list<productId> to find the neighbors
        public IList<ProductRecommence> GetProductCodeByOrderDetail(IList<OrderDetail> orderdetails)
        {
            IList<ProductRecommence> products = new List<ProductRecommence>();

            foreach (var item in orderdetails)
            {
                var x =_productService.GetById(item.ProductId);
                products.Add(new ProductRecommence(x.Code, x.CategoryId, x.CurrentPrice));
            }
            return products;
        }

        public IList<Product> GetProductByOrderDetail(IList<OrderDetail> orderdetails)
        {
            IList<Product> products = new List<Product>();

            foreach (var item in orderdetails)
            {
                var product = _productService.GetById(item.ProductId);
                products.Add(product);
            }
            return products;
        }


    }
    
    
    public class Recommence : BaseModel
    {
        public Recommence(int userid, IList<ProductRecommence> productCodesOfUserLogging, IList<List<ProductRecommence>> listDataProductCodes)
        {
            UserId = userid;

            ProductCodeOfUserLogging = productCodesOfUserLogging;

            ListDataProductCodes = listDataProductCodes;
        }

        public int UserId { get; set; }

        public ICollection<ProductRecommence> ProductCodeOfUserLogging { get; set; }

        public IList<List<ProductRecommence>> ListDataProductCodes { get; set; }
    }

    public class ProductRecommence
    {
        public ProductRecommence(string code, int categoryId,  double price)
        {
            Code = code;
            CategoryId = categoryId;
            Price = price;
        }

        public double Price { get; set; }
        public string Code { get; set; }

        public int CategoryId { get; set; }
    }


}




