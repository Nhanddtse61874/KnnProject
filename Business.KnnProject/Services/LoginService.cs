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
        User Check(LoginService.LoginModel loginMode);
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

        public User Check(LoginModel loginModel)
        {
            

            var user = _userRepo.Get(x => x.UserName == loginModel.UserName);
            
           
            {
                if (user.PassWord == loginModel.PassWord)
                {
                    return user;
                }
            }
            return null;

        }

        public class LoginModel
        {
            public string UserName { get; set; }

            public string PassWord { get; set; }
        }

    }
}
