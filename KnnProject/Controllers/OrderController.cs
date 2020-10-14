using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public class OrderController : ApiControllerBase
    {
        private readonly IOrderService _service;

        public OrderController()
        {
            _service = new OrderService();
        }

        //[HttpGet]
        //public IHttpActionResult GetByUser(int userId)
        //        => Ok(_mapper.Map<IEnumerable<OrderViewModel>>(_service.GetByUser(userId)));


        [HttpGet]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<OrderViewModel>>(_service.Get()));


        [HttpPost]
        public IHttpActionResult Post(CreateOrderViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Create(_mapper.Map<Order>(newModel));
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(UpdateOrderViewModel modifiedModel) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Update(_mapper.Map<Order>(modifiedModel));
            return Ok();
        }
    }
}
