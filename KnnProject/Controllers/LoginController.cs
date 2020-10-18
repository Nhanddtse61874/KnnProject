using Business.KnnProject.Services;
using System.Web.Http;

namespace KnnProject.Controllers
{

    [RoutePrefix("api/login-management")]
    public class LoginController : ApiControllerBase
    {
        private readonly ILoginService _login;
        public LoginController()
        {
            _login = new LoginService();
        }

        [HttpGet][Route]
        public IHttpActionResult Login(string userName, string passWord)
        {
            var userId = _login.Check(userName, passWord);
            return Ok(userId);
        }
    }
}
