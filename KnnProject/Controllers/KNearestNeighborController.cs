using Business.KnnProject.Services;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/knearestneibor-management/users")]
    public class KNearestNeighborController : ApiControllerBase
    {
        private readonly IKNearestNeighborService _kService;

        public KNearestNeighborController()
        {
            _kService = new KNearestNeighborService();
        }

        [HttpGet]
        [Route("{userId}/{pageIndex}/{pageSize}")]
        public IHttpActionResult Get(int userId, int? pageIndex, int? pageSize)
        {
            string route = "api/knearestneibor-management?pageIndex={0}&pageSize={1}";

            var result = _kService.Suggest(userId);
            var totalPages = result.Count() / pageSize;
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
    }
}
