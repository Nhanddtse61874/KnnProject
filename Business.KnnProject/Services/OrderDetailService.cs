using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

namespace Business.KnnProject.Services
{
    public interface IOrderDetailService
    {
        IList<OrderDetail> GetByOrder(int orderId);

        IList<OrderDetail> GetByProduct(int productId);

        void Create(OrderDetail newOderDetail);

        void Update(OrderDetail modifiedOrderDetail);

        void Delete(int orderDetailId);
    }
    public class OrderDetailService : ServiceBase, IOrderDetailService
    {
        private readonly IRepository<OrderDetail> _repository;

        public OrderDetailService()
        {
            _repository = _unitOfWork.Repository<OrderDetail>();
        }
        public void Create(OrderDetail newOderDetail)
        {
            _repository.Create(newOderDetail);
            _unitOfWork.Save();
        }

        public void Delete(int orderDetailId)
        {
            _repository.Delete(orderDetailId);
            _unitOfWork.Save();
        }

        public IList<OrderDetail> GetByOrder(int orderId)
            => _repository.GetAll(x => x.OrderId == orderId);
        public IList<OrderDetail> GetByProduct(int productId)
            => _repository.GetAll(x => x.ProductId == productId);    
        public void Update(OrderDetail modifiedOrderDetail)
        {
            _repository.Update(modifiedOrderDetail);
            _unitOfWork.Save();
        }
    }
}
