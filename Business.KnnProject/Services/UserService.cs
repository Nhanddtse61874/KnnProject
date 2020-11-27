using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;
using System.Linq;

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

        void UpdatePoint(int userId, double totalPrice);
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
            var users = _repo.GetAll(x => x.RankId == rankId, includeProperties: x => x.Orders);
            return users;
        }
        public IList<User> GetByRole(int roleId)
        {
            var result = _repo.GetAll(x => x.RoleId == roleId, includeProperties: x => x.Orders);
            //foreach (var item in result)
            //{
            //    item.Orders = _orderService.GetByUser(item.Id);
            //}
            return result;
        }
        public User GetById(int id)
        {
            var result = _repo.GetById(id, includeProperties: x => x.Orders);
            //check result null
            if(result != null)
            {
                result.Orders = _orderService.GetByUser(result.Id);
            }
            return result;
        }
        public void Update(User modifiedUser)
        {
            _repo.Update(modifiedUser);
            _unitOfWork.Save();
        }

        public void UpdatePoint(int userId, double totalPrice)
        {
            var user = _repo.GetById(userId);
            var point  = user.Point + totalPrice * 5;
            if(point < 10000 && point > 5000)
            {
                user.RankId = 1;
            }
            if(point > 10000 && point < 15000)
            {
                user.RankId = 2;
            }
            if(point > 15000)
            {
                user.RankId = 3;
            }
            user.Point = point;
            _repo.Update(user);
            _unitOfWork.Save();
        }
    }
}
