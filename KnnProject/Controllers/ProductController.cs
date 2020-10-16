using AutoMapper;
using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System;
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
        public IHttpActionResult Get(int? pageIndex, int? pageSize)
            => Ok(_mapper.Map<IEnumerable<ProductViewModel>>(_productService.GetAll(pageIndex, pageSize)));   


        [HttpPost]
        public IHttpActionResult Post(CreateProductViewModel newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productService.Create(_mapper.Map<Product>(newProduct));
            return Ok();
        }

        [HttpPut] 
        public IHttpActionResult Put(UpdateProductViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productService.Update(_mapper.Map<Product>(modifiedModel));
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetByFilter(int? id, int? sizeId, int? tagId, int? categoryId)
        {
            var result = _mapper.Map<IEnumerable<ProductViewModel>>(_productService.GetByFilter(id, sizeId, tagId, categoryId));
            return Ok(result);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }

    }
}
