using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public class OrderDetailController : ApiControllerBase
    {
        private readonly IOrderDetailService _service;

        public OrderDetailController()
        {
            _service = new OrderDetailService();
        }

        [HttpGet]
        public IHttpActionResult GetByProduct(int productId)
            => Ok(_mapper.Map<IEnumerable<OrderDetailViewModel>>(_service.GetByProduct(productId)));

        [HttpGet]
        public IHttpActionResult GetByOrder(int orderId)
                => Ok(_mapper.Map<IEnumerable<OrderDetailViewModel>>(_service.GetByOrder(orderId)));


        [HttpPost]
        public IHttpActionResult Post(CreateOrderDetailViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.Create(_mapper.Map<OrderDetail>(newModel));
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(UpdateOrderDetailViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Update(_mapper.Map<OrderDetail>(modifiedModel));
            return Ok();
        }
    }
}
