using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/size-management")]
    public class SizeController : ApiControllerBase
    {
        private readonly ISizeService _service;

        public SizeController()
        {
            _service = new SizeService();
        }


        //Get all Sizes
        [HttpGet, Route]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<SizeViewModel>>(_service.Get()));


        //Create new Size
        [HttpPost, Route]
        public IHttpActionResult Post(CreateSizeViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Create(_mapper.Map<Size>(newModel));
            return Ok();
        }


        //Update Size
        [HttpPut, Route]
        public IHttpActionResult Put(UpdateSizeViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Update(_mapper.Map<Size>(modifiedModel));

            return Ok();
        }


        //DElete Size
        [HttpDelete, Route]
        public IHttpActionResult Delete(int sizeId)
        {
            _service.Delete(sizeId);
            return Ok();

        }

    }
}
