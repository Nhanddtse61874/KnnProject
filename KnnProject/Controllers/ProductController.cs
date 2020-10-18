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

       
        [Route]
        [HttpGet]//Get all products 
        public IHttpActionResult Get(int? pageIndex, int? pageSize)
        {
            string route = "api/product-management?pageIndex={0}&pageSize={1}";
            //_productService.Count
            
            var result = _mapper.Map<IEnumerable<ProductViewModel>>(_productService.GetAll(pageIndex, pageSize));
            int? totalPages = result.Count()/pageSize;
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


            return Ok(result);
        }

        [HttpPost, Route]
        public virtual IHttpActionResult Post()
        {
            string json = HttpContext.Current.Request.Form["newProduct"];
            
             var newProduct = JsonConvert.DeserializeObject<CreateProductViewModel>(json);
            Validate(newProduct);
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


        [HttpPut][Route]
        public IHttpActionResult Put()
        {
            string json = HttpContext.Current.Request.Form["modifiedProduct"];

            var modifiedProduct = JsonConvert.DeserializeObject<UpdateProductViewModel>(json);
            Validate(modifiedProduct);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }// end if check is model validate

            var product = _mapper.Map<Product>(modifiedProduct);

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
            _productService.Update(product);
            return Ok();

        }
        //Update Product
        //[HttpPut, Route]
        //public IHttpActionResult Put(UpdateProductViewModel modifiedModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    _productService.Update(_mapper.Map<Product>(modifiedModel));
        //    return Ok();
        //}

        //get product by filter (filter may be null )
        [HttpGet] [Route("{colorId}/{sizeId}/{tagId}/{categoryId}")]
        public IHttpActionResult GetByFilter(int? colorId, int? sizeId, int? tagId, int? categoryId, int? pageIndex, int? pageSize)
        {
            var result = _mapper.Map<IEnumerable<ProductViewModel>>(_productService.GetByFilter(colorId, sizeId, tagId, categoryId, pageIndex, pageSize));
            return Ok(result);
        }

        [HttpDelete, Route]//delete 1 product by productid
        public IHttpActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
        
    }
}
