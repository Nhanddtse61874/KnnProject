using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

namespace Business.KnnProject.Services
{
    public interface IRankService
    {
        IList<Rank> Get();

        void Create(Rank newRank);

        void Update(Rank modifiedRank);

        void Delete(int rankId);
    }
    public class RankService : ServiceBase, IRankService
    {
        private readonly IRepository<Rank> _repo;
        private readonly IUserService _userService;

        public RankService()
        {
            _userService = new UserService();
            _repo = _unitOfWork.Repository<Rank>();
        }
        public void Create(Rank newRank)
        {
            _repo.Create(newRank);
            _unitOfWork.Save();
        }

        public void Delete(int rankId)
        {
            _repo.Delete(rankId);
            _unitOfWork.Save();
        }

        public IList<Rank> Get()
        {
            var result  = _repo.GetAll(includeProperties: x => x.Users);
            foreach (var item in result)
            {
                item.Users = _userService.GetByRank(item.Id);
            }
            return result;
        }
            
        public void Update(Rank modifiedRank)
        {
            _repo.Update(modifiedRank);
            _unitOfWork.Save();
        }
    }
}