﻿using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/user-management/users")]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _service;
        private readonly IOrderService _orderService;

        public UserController()
        {
            _service = new UserService();
            _orderService = new OrderService();
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
        {
            return Ok(_mapper.Map<IEnumerable<UserViewModel>>(_service.GetByRank(rankId)));

        }


        //get all users have the same role
        [Route("{roleId}/roles")]
        [HttpGet]
        public IHttpActionResult GetByUser(int roleId)
        {

            return Ok(_mapper.Map<IEnumerable<UserViewModel>>(_service.GetByRole(roleId)));
        }


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

        [Route("{userId}/{totalPrice}")]
        [HttpPost]
        public IHttpActionResult UpdatePoint(int userId, double totalPrice)
        {
            _service.UpdatePoint(userId, totalPrice);
            return Ok();
        }

        //update a user 
        [Route]
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
