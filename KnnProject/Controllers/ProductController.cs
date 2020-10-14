using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public class ProductController : ApiControllerBase
    {
        private readonly IProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        //[HttpGet]
        //public IHttpActionResult Get(int productId)
        //  => Ok(_mapper.Map<ProductViewModel>(_productService.GetById(productId)));

        // -- filter theo 
        //gia <>
        //size == 
        //tag == 
        //color ==
        //category ==
        // -- sort theo 
        //moi nhat (mac dinh)
        //rating
        //price
        // -- phan trang
        //12
        //24
        //36
        [HttpGet]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<ProductViewModel>>(_productService.GetAll()));   
    }
}
