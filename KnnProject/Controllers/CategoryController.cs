using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/category-management")]
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        [Route]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryService.GetAllCategory());
            //int totalCategories = result.Count();
            //int totalPages = totalCategories / 2;

            return Ok(result);
            //return Ok(new
            //{
            //    data = result,
            //    pager = new
            //    {
            //        pageIndex = 1,
            //        pageSize = 3,
            //        totalPages,
            //        totalResults = totalCategories
            //    }
            //});
        }

        [HttpPost, Route]
        public IHttpActionResult Post(CreateCategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _categoryService.Create(_mapper.Map<Category>(category));
            return Ok();
        }

        [HttpPut, Route]
        public IHttpActionResult Put(ModifiedCategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _categoryService.Update(_mapper.Map<Category>(category));
            return Ok();
        }

        [HttpDelete, Route]
        public IHttpActionResult Delete(int categoryId)
        {
            _categoryService.Delete(categoryId);
            return Ok();
        }


        [HttpGet][Route("{categoryId}")] 
        public IHttpActionResult GetById(int id)
        
           => Ok(_mapper.Map<Category>(_categoryService.GetById(id)));
        

    }
}
