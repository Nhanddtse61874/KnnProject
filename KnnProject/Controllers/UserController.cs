using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/user-management/users")]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _service;

        public UserController()
        {
            _service = new UserService(); 
        }


        //get 1 user by userId
        [Route("{id}/details")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
            => Ok(_mapper.Map<UserViewModel>(_service.GetById(id))); 


        //get all users
        [Route]
        [HttpGet]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<UserViewModel>>(_service.Get()));


        //get all users have the same rank 
        [Route("{rankId}/ranks")]
        [HttpGet]
        public IHttpActionResult Get(int rankId)
            => Ok(_mapper.Map<IEnumerable<UserViewModel>>(_service.GetByRank(rankId)));


        //get all users have the same role
        [Route("{roleId}/roles")]
        [HttpGet]
        public IHttpActionResult GetByUser(int roleId)
            => Ok(_mapper.Map<IEnumerable<UserViewModel>>(_service.GetByRank(roleId)));


        //create a user 
        [Route]
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


        //update a user 
        [Route("{id}")]
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


        //Delete user by userId
        [Route]
        [HttpDelete]
        public IHttpActionResult Delete(int userId)
        {
            _service.Delete(userId);
            return Ok();
        }
    }
}
