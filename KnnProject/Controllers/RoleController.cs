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

        [HttpGet, Route]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<RoleViewModel>>(_service.Get()));

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

        [HttpDelete, Route]
        public IHttpActionResult Delete(int roleId) 
        {
            _service.Delete(roleId);
            return Ok();
        }
    }
}
