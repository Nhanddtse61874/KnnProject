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
    public class ReviewController : ApiControllerBase
    {
        private readonly IReviewService _previewSevice;

        public ReviewController()
        {
            _previewSevice = new ReviewService();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _previewSevice.Get();
            return Ok(_mapper.Map<IEnumerable<PreviewViewModel>>(result));
        }

        [HttpPost]
        public IHttpActionResult Post(CreatePreviewViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _previewSevice.Create(_mapper.Map<Review>(newModel));
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(UpdatePreviewViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _previewSevice.Update(_mapper.Map<Review>(modifiedModel));
            return Ok();
        }

    }
}
