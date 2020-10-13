using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Ninject;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
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
            => Ok(_mapper.Map<IEnumerable<CategoryViewModel>>(_categoryService.GetAllCategory()));

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
