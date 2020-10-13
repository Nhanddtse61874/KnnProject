using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

namespace Business.KnnProject.Services
{
    public interface IUserService
    {
        IList<User> Get();

        IList<User> GetByRank(int rankId);

        void Create(User newUser);

        void Update(User modifiedUser);

        void Delete(int userId);
    }
    public class UserService : ServiceBase, IUserService
    {
        private readonly IRepository<User> _repo;

        public UserService()
        {
            _repo = _unitOfWork.Repository<User>();
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
            => _repo.GetAll();

        public IList<User> GetByRank(int rankId)
            => _repo.GetAll(x => x.RankId == rankId);

        public void Update(User modifiedUser)
        {
            _repo.Update(modifiedUser);
            _unitOfWork.Save();
        }
    }
}
