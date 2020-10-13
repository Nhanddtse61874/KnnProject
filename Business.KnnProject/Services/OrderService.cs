using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

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
        private readonly IRepository<Order> _repository;

        public OrderService()
        {
            _repository = _unitOfWork.Repository<Order>();
        }
        public void Create(Order newOrder)
        {
            _repository.Create(newOrder);
            _unitOfWork.Save();
        }

        public void Delete(int orderId)
        {
            _repository.Delete(orderId);
            _unitOfWork.Save();
        }

        public IList<Order> Get()
            => _repository.GetAll();

        public IList<Order> GetByUser(int userId)
            => _repository.GetAll(x => x.UserId == userId);

        public void Update(Order modifiedOrder)
        {
            _repository.Update(modifiedOrder);
            _unitOfWork.Save(); 
        }
    }
}
