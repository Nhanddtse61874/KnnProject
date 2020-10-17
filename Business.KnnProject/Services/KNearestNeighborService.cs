using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.KnnProject.Services
{
    public class KNearestNeighborService : ServiceBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUserService _userService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IOrderService _orderService;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IOrderDetailService _orderDetailService;

        private readonly IProductService _productService;
        private readonly IRepository<Product> _productRepository;

        public KNearestNeighborService()
        {
            _userRepository = _unitOfWork.Repository<User>();
            _userService = new UserService();
            _orderRepository = _unitOfWork.Repository<Order>();
            _orderService = new OrderService();
            _orderDetailRepository = _unitOfWork.Repository<OrderDetail>();
            _orderDetailService = new OrderDetailService();
            _productService = new ProductService();
            _productRepository = _unitOfWork.Repository<Product>();
        }
        public List<int> Suggest(int  userId)
        {
            User user = _userService.GetById(userId);
            var listUser = _userService.GetByRank(userId);
            var listProductOfUser = GetProductByOrderDetail(GetOrderDetailByOrder(GetOrderByUser(user)));
            IList<int> result = new List<int>();

            foreach (var item3 in listUser)
            {
                var listProductAllUser = GetProductByOrderDetail(GetOrderDetailByOrder(GetOrderByUser(item3)));
                var x  = listDictin(listProductOfUser, listProductAllUser);
                foreach(var item in x)
                {
                    result.Add(item);
                }
            }
            return result.Distinct().ToList();
            
        }   

        public IList<int> listDictin(IList<int> list1, IList<int> list2)
        {
            IList<int> result = new List<int>();
            int count = 0;
            foreach(var item in list1)
            {
                if (list2.Contains(item)){
                    count++;
                }
                if(count >= 2)
                {
                    foreach(var item2 in list2)
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

        public IList<Order> GetOrderByUser(User user)
        {
            var result = _orderService.GetByUser(user.Id);
            return result;
        }

        public IList<OrderDetail> GetOrderDetailByOrder(IList<Order> orders)
        {
            IList<OrderDetail> orderdetails = new List<OrderDetail>();
            foreach(var item in orders)
            {
                var list = item.Orderdetails.ToList();
                foreach(var item2 in list)
                {

                    orderdetails.Add(item2);
                }
            }
            return orderdetails;
        }

        public IList<int> GetProductByOrderDetail(IList<OrderDetail> orderdetails)
        {
            var result = orderdetails.Select(x => x.ProductId);
            return result.ToList();
        }

    }
}




