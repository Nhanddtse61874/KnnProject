using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
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

        //Get all categories
        [Route]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryService.GetAllCategory());
           

            return Ok(result);
            
        }

        //Create new category
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


        //Update Category
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


        //Delete Category
        [HttpDelete, Route]
        public IHttpActionResult Delete(int categoryId)
        {
            _categoryService.Delete(categoryId);
            return Ok();
        }


        //Get category by categoryId
        [HttpGet][Route("{categoryId}")] 
        public IHttpActionResult GetById(int id)
        
           => Ok(_mapper.Map<Category>(_categoryService.GetById(id)));
        

    }
}
