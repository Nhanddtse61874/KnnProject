using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

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

        [HttpPost]
        public IHttpActionResult Post(CreateCategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _categoryService.Create(_mapper.Map<Category>(category));
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(ModifiedCategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _categoryService.Update(_mapper.Map<Category>(category));
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int categoryId)
        {
            _categoryService.Delete(categoryId);
            return Ok();
        }


    }
}
