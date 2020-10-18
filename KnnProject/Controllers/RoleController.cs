using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/role-management")]
    public class RoleController : ApiControllerBase
    {
        private readonly IRoleService _service;

        public RoleController()
        {
            _service = new RoleService();
        }


        //Get All Roles
        [HttpGet, Route]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<RoleViewModel>>(_service.Get()));


        //Create new role
        [HttpPost, Route]
        public IHttpActionResult Post(CreateRoleViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Create(_mapper.Map<Role>(newModel));
            return Ok();
        }


        //Update Role
        [HttpPut, Route]
        public IHttpActionResult Put(UpdateRoleViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Update(_mapper.Map<Role>(modifiedModel));
            return Ok();
        }


        //Delete Role
        [HttpDelete, Route]
        public IHttpActionResult Delete(int roleId) 
        {
            _service.Delete(roleId);
            return Ok();
        }
    }
}
