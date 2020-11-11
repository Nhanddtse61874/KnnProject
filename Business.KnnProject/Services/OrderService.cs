using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.KnnProject.Services
{
    public interface IOrderService
    {
        IList<Order> Get();

        IList<Order> GetByUser(int userId);

        void Create(Order newOrder);

        void Update(Order modifiedOrder);

        void Delete(int orderId);
    }
    public class OrderService : ServiceBase, IOrderService
    {
        private IOrderDetailService _oderDetail = new OrderDetailService();
        private readonly IRepository<Order> _repository;

        public OrderService()
        {
            _repository = _unitOfWork.Repository<Order>();
        }
        public void Create(Order newOrder)
        {
            newOrder.Date = DateTime.Now;
            _repository.Create(newOrder);
            _unitOfWork.Save();
        }

        public void Delete(int orderId)
        {
            _repository.Delete(orderId);
            _unitOfWork.Save();
        }

        public IList<Order> Get()
        {
            var result = _repository.GetAll(includeProperties: x => x.Orderdetails);
            return result;
        }
            

        public IList<Order> GetByUser(int userId)
        {
           var result = _repository.GetAll(filter : x => x.UserId == userId , includeProperties :  x => x.Orderdetails);
           
            return result;
        }


        public void Update(Order modifiedOrder)
        {
            modifiedOrder.Date = DateTime.Now;
            _repository.Update(modifiedOrder);
            _unitOfWork.Save(); 
        }
    }
}
