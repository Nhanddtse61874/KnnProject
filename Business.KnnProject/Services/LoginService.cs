using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Business.KnnProject.Services
{
    public interface ILoginService
    {
        User Check(LoginService.LoginModel loginModel);
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
            var user = _userRepo.Get(x => x.UserName == loginModel.UserName
                    && x.PassWord == loginModel.Password);
            return user;   
        }

        public class LoginModel
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            public string Password { get; set; }

            
        }

    }
}
