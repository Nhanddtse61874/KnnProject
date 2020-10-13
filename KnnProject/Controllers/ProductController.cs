using Business.KnnProject.Services;
using KnnProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        [HttpGet]
        public IHttpActionResult Get(int productId)
          => Ok(_mapper.Map<IEnumerable<ProductViewModel>>(_productService.GetById(productId)));

       
    }
}
