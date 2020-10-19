using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace Business.KnnProject.Services
{
    public interface IKNearestNeighborService
    {
        IList<Product> Suggest(int userId);

        IList<int> listDictin(IList<int> list1, IList<int> list2);

        IList<Order> GetOrderByUser(User user);

        IList<OrderDetail> GetOrderDetailByOrder(IList<Order> orders);

        IList<int> GetProductByOrderDetail(IList<OrderDetail> orderdetails);
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
        public IList<Product> Suggest(int userId)
        {
            
            User user = _userService.GetById(userId);
            var listUser = _userService.GetByRank(user.RankId);
            var listProductOfUser = GetProductByOrderDetail(GetOrderDetailByOrder(GetOrderByUser(user)));
            IEnumerable<int> result = new List<int>();

            foreach (var item3 in listUser)
            {
                var listProductAllUser = GetProductByOrderDetail(GetOrderDetailByOrder(GetOrderByUser(item3)));
                result = result.Concat(listDictin(listProductOfUser, listProductAllUser)).Distinct();
            }
            IList<Product> products = new List<Product>();
            foreach (var item in result)
            {
                products.Add(_productService.GetById(item));
            }
            return products;

        }
        //Removes the duplicate elements between 2 lists when user is neighbor
        public IList<int> listDictin(IList<int> list1, IList<int> list2)
        {
            IList<int> result = new List<int>();
            int count = 0;
            foreach (var item in list1)
            {
                if (list2.Contains(item))
                {
                    count++;
                }
                if (count >= k)
                {
                    foreach (var item2 in list2)
                    {
                        if (!list2.Contains(item))
                        {
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        //Get List<Order> from User
        public IList<Order> GetOrderByUser(User user)
        {
            var result = _orderService.GetByUser(user.Id);
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
        public IList<int> GetProductByOrderDetail(IList<OrderDetail> orderdetails)
        {
            var result = orderdetails.Select(x => x.ProductId);
            return result.ToList();
        }

    }
}




