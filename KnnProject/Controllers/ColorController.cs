using Business.KnnProject.Services;
using KnnProject.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public class ColorController : ApiControllerBase
    {
        private readonly IColorService _service;

        public ColorController()
        {
            _service = new ColorService();
        }

        [HttpGet]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<ColorViewModel>>(_service.GetAllColor()));

        [HttpPost] 
        public IHttpActionResult Post(CreateColorViewModel colormodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.Create(_mapper.Map<Persistence.KnnProject.Models.Color>(colormodel));
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int colorId)
        {
            _service.Delete(colorId);
            return Ok();
        }

        [HttpPut] public IHttpActionResult Put(UpdateColorViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.Update(_mapper.Map<Persistence.KnnProject.Models.Color>(modifiedModel));
            return Ok();
        }
    }
}
