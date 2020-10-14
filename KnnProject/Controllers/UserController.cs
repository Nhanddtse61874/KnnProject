using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _service;

        public UserController()
        {
            _service = new UserService(); 
        }


        [HttpGet]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<UserViewModel>>(_service.Get()));

        [HttpGet]
        [Route("api/User/{rankId}")]
        public IHttpActionResult Get(int rankId)
            => Ok(_mapper.Map<IEnumerable<UserViewModel>>(_service.GetByRank(rankId)));


        [HttpPost]
        public IHttpActionResult Post(CreateUserViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Create(_mapper.Map<User>(newModel));
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(UpdateUserViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Update(_mapper.Map<User>(modifiedModel));
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int userId)
        {
            _service.Delete(userId);
            return Ok();
        }
    }
}
