using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Newtonsoft.Json;
using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/product-management")]
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
        [Route]
        [HttpGet]
        public IHttpActionResult Get(int? pageIndex, int? pageSize)
        {
            string route = "api/product-management?pageIndex={0}&pageSize={1}";
            //_productService.Count
            int totalPages = 10;
            var paginationHeader = new
            {
                pageIndex,
                pageSize,
                //TotalCount = totalCount,
                //TotalPages = totalPages,
                prevPageLink = string.Format(route, pageIndex == 1 ? 1 : pageSize - 1, pageSize),
                nextPageLink = string.Format(route, pageIndex == totalPages ? totalPages : pageIndex + 1, pageSize),
                firstPageLink = string.Format(route, 1, pageSize),
                lastPageLink = string.Format(route, totalPages, pageSize)
            };

            HttpContext.Current.Response.Headers.Add("x-pagination",
                JsonConvert.SerializeObject(paginationHeader));


            return Ok(_mapper.Map<IEnumerable<ProductViewModel>>(_productService.GetAll(pageIndex, pageSize)));
        }

        [HttpPost, Route]
        public IHttpActionResult Post()
        {
            string json = HttpContext.Current.Request.Form["newProduct"];
            var newProduct = JsonConvert.DeserializeObject<CreateProductViewModel>(json);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }// end if check is model validate

            var product = _mapper.Map<Product>(newProduct);

            // handle upload image storage
            var images = new List<CreateImageStorageViewModel>();
            var files = HttpContext.Current.Request.Files;
            foreach (string file in files)
            {
                var uploadFile = files[file];
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    var extension = uploadFile.FileName.Substring(uploadFile.FileName.LastIndexOf('.'));

                    var filePath = HttpContext.Current.Server.MapPath("~/Images/" + Guid.NewGuid() + extension);
                    uploadFile.SaveAs(filePath);

                    images.Add(new CreateImageStorageViewModel(uploadFile.FileName, filePath));
                }// end if check is image uploaded
            }
            if (!images.Any())
            {
                images.Add(new CreateImageStorageViewModel("default-image", "https://picsum.photos/300/400"));
            }// end if handle default image using https://picsum.photos/300/400

            product.ImageStorages = _mapper.Map<List<ImageStorage>>(images);

            _productService.Create(product);
            return Ok();
        }

        [HttpPut, Route]
        public IHttpActionResult Put(UpdateProductViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _productService.Update(_mapper.Map<Product>(modifiedModel));
            return Ok();
        }

        [HttpGet] [Route("{colorId}/{sizeId}/{tagId}/{categoryId}")]
        public IHttpActionResult GetByFilter(int? colorId, int? sizeId, int? tagId, int? categoryId, int? pageIndex, int? pageSize)
        {
            var result = _mapper.Map<IEnumerable<ProductViewModel>>(_productService.GetByFilter(colorId, sizeId, tagId, categoryId, pageIndex, pageSize));
            return Ok(result);
        }

        [HttpDelete, Route]
        public IHttpActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
        
    }
}
