using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public class ImageStorageController : ApiControllerBase
    {

        private readonly IImageStorageService _service;

        public ImageStorageController()
        {
            _service = new ImageStorageService();
        }

        [HttpGet]
        public IHttpActionResult Get(int productId)
            => Ok(_mapper.Map<IEnumerable<ImageStorageViewModel>>(_service.GetByProduct(productId)));

        [HttpPost]
        public IHttpActionResult Post(CreateImageStorageViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Create(_mapper.Map<ImageStorage>(newModel));
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int imgId)
        {
            _service.Delete(imgId);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(UpdateImageStorageViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Update(_mapper.Map<ImageStorage>(modifiedModel));
            return Ok();
        }
    }
}
