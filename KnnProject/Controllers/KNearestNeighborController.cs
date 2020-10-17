using Business.KnnProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public class KNearestNeighborController : ApiControllerBase
    {
        private readonly KNearestNeighborService _kService;

        public KNearestNeighborController()
        {
            _kService = new KNearestNeighborService();
        }

        [HttpGet]
        public IHttpActionResult Get(int userId)
        {
            var result = _kService.Suggest(userId);
            
            return Ok(result);
        }
    }
}
