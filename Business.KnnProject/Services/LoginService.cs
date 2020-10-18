using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.KnnProject.Services
{
    public interface ILoginService
    {
        int Check(string userName, string passWord);
    }
    public class LoginService : ServiceBase, ILoginService
    {
        private readonly IRepository<User> _userRepo;
        private readonly IUserService _userService;

        public LoginService()
        {
            _userRepo = _unitOfWork.Repository<User>();
            _userService = new UserService();
        }

        public int Check(string userName, string passWord)
        {
            var users = _userRepo.GetAll();
            foreach (var item in users)
            {
                if(item.UserName == userName && item.PassWord == passWord)
                {
                    return item.Id;
                }
            }
            return -1;

        }
    }
}
