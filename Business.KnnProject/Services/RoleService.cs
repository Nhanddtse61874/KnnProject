using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

namespace Business.KnnProject.Services
{
    public interface IRoleService
    {
        IList<Role> Get();

        void Create(Role newRole);

        void Update(Role modifiedRole);

        void Delete(int roleId);
    }
    public class RoleService : ServiceBase, IRoleService
    {
        private readonly IRepository<Role> _repo;
        private readonly IUserService _userService;

        public RoleService()
        {
            _repo = _unitOfWork.Repository<Role>();
            _userService = new UserService();
        }
        public void Create(Role newRole)
        {
            _repo.Create(newRole);
            _unitOfWork.Save();
        }

        public void Delete(int roleId)
        {
            _repo.Delete(roleId);
            _unitOfWork.Save();
        }

        public IList<Role> Get()
        {
            var result = _repo.GetAll(includeProperties: x => x.Users);
            foreach (var item in result)
            {
                item.Users = _userService.GetByRole(item.Id);
            }
            return result;
        }
        public void Update(Role modifiedRole)
        {
            _repo.Update(modifiedRole);
            _unitOfWork.Save();
        }
    }

}
