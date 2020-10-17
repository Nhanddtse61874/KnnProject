using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/rank-management")]
    public class RankController : ApiControllerBase
    {
        private readonly IRankService _service;

        public RankController()
        {
            _service = new RankService();
        }

        [HttpGet, Route]
        public IHttpActionResult Get()
            => Ok(_mapper.Map<IEnumerable<RankViewModel>>(_service.Get()));

        [HttpPost, Route]
        public IHttpActionResult Post(CreateRankViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Create(_mapper.Map<Rank>(newModel));
            return Ok();
        }

        [HttpPut, Route]
        public IHttpActionResult Put(UpdateRankViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.Update(_mapper.Map<Rank>(modifiedModel));
            return Ok();
        }

        [HttpDelete, Route]
        public IHttpActionResult Delete(int rankId)
        {
            _service.Delete(rankId);
            return Ok();
        }
    }
}
