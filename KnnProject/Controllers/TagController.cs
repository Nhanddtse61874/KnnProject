using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public class TagController : ApiControllerBase
    {
        private readonly ITagService _tagService;

        public TagController()
        {
            _tagService = new TagService();
        }

        [HttpGet]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<TagViewModel>>(_tagService.GetAllTag()));
      
        [HttpPost]
        public IHttpActionResult Post(CreateTagViewModel tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _tagService.Create(_mapper.Map<Tag>(tag));

            return Ok();
        }

        [HttpPut] 
        public IHttpActionResult Put(UpdateTagViewModel tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _tagService.Update(_mapper.Map<Tag>(tag));
            return Ok();
        }

        [HttpDelete]
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
