using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public class SizeController : ApiControllerBase
    {
        private readonly ISizeService _service;

        public SizeController()
        {
            _service = new SizeService();
        }

        [HttpGet]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<SizeViewModel>>(_service.Get()));

        [HttpPost]
        public IHttpActionResult Post(CreateSizeViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Create(_mapper.Map<Size>(newModel));
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(UpdateSizeViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Update(_mapper.Map<Size>(modifiedModel));

            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int sizeId)
        {
            _service.Delete(sizeId);
            return Ok();

        }

    }
}
