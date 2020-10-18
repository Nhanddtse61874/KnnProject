using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/tag-management")]
    public class TagController : ApiControllerBase
    {
        private readonly ITagService _tagService;

        public TagController()
        {
            _tagService = new TagService();
        }


        //Get all Tags
        [HttpGet, Route]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<TagViewModel>>(_tagService.GetAllTag()));
      

        //Create new Tag
        [HttpPost, Route]
        public IHttpActionResult Post(CreateTagViewModel tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _tagService.Create(_mapper.Map<Tag>(tag));

            return Ok();
        }


        //Update Tag
        [HttpPut, Route] 
        public IHttpActionResult Put(UpdateTagViewModel tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _tagService.Update(_mapper.Map<Tag>(tag));
            return Ok();
        }


        //Delete Tag
        [HttpDelete, Route]
        public IHttpActionResult Delete(int tagId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _tagService.Delete(tagId);
            return Ok();
        }
        
    }
}
