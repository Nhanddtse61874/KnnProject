using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/order-management")]
    public class OrderController : ApiControllerBase
    {
        private readonly IOrderService _service;

        public OrderController()
        {
            _service = new OrderService();
        }
        

        //Get all Orders
        [Route]
        [HttpGet]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<OrderViewModel>>(_service.Get()));


        //Get Orders By userId
        [Route("users/{userId}/orders")]
        [HttpGet]
        public IHttpActionResult GetByUser(int userId)
        {
            var result = _service.GetByUser(userId);
            
            return Ok(_mapper.Map<IEnumerable<OrderViewModel>>(result));
        }


        //Create new Order and OrderDetail
        [Route ("users/orders")]
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

        //Update Order
        [Route("users/orders")]
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

        //Delete Order
        [Route("{orderId}")]
        [HttpDelete]
        public IHttpActionResult Delete(int orderId)
        {
            _service.Delete(orderId);
            return Ok();
        }
    }
}
