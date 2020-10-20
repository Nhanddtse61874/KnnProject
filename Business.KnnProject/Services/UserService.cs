using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

namespace Business.KnnProject.Services
{
    public interface IUserService
    {
        IList<User> Get();

        IList<User> GetByRank(int rankId);

        User GetById(int id);

        void Create(User newUser);

        void Update(User modifiedUser);

        void Delete(int userId);

        IList<User> GetByRole(int roleId);
    }
    public class UserService : ServiceBase, IUserService
    {
        private readonly IRepository<User> _repo;
        private readonly IOrderService _orderService;


        public UserService()
        {
            _repo = _unitOfWork.Repository<User>();
            _orderService = new OrderService();

        }
        public void Create(User newUser)
        {
            _repo.Create(newUser);
            _unitOfWork.Save();
        }

        public void Delete(int userId)
        {
            _repo.Delete(userId);
            _unitOfWork.Save();
        }

        public IList<User> Get()
        {
            var result = _repo.GetAll(includeProperties: x => x.Orders);
            foreach (var item in result)
            {
                item.Orders = _orderService.GetByUser(item.Id);
            }
            return result;
        }
        public IList<User> GetByRank(int rankId)

        {
            var result = _repo.GetAll(x => x.RankId == rankId, includeProperties: x => x.Orders);
            foreach (var item in result)
            {
                item.Orders = _orderService.GetByUser(item.Id);
            }
            return result;
        }
        public IList<User> GetByRole(int roleId)
        {
            var result = _repo.GetAll(x => x.RoleId == roleId, includeProperties: x => x.Orders);
            foreach (var item in result)
            {
                item.Orders = _orderService.GetByUser(item.Id);
            }
            return result;
        }
        public User GetById(int id)
        {
            var result = _repo.GetById(id, includeProperties: x => x.Orders);
            result.Orders = _orderService.GetByUser(result.Id);
            return result;
        }
        public void Update(User modifiedUser)
        {
            _repo.Update(modifiedUser);
            _unitOfWork.Save();
        }
    }
}
