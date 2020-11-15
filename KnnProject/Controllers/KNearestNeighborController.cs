using Business.KnnProject.Services;
using KnnProject.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/knearestneibor-management/users")]
    public class KNearestNeighborController : ApiControllerBase
    {
        private readonly IKNearestNeighborService _kService;
        private readonly IUserService _user;
        private readonly IProductService _product;

        public KNearestNeighborController()
        {
            _kService = new KNearestNeighborService();
            _user = new UserService();
            _product = new ProductService();
        }

        [HttpGet]
        [Route("{userId}")]
        public IHttpActionResult GetData(int userId)
        {
            var productCodesOfUserLogging = _kService.GetAllProductCodeByUserIdToRecommend(userId);
            
            IList<List<ProductRecommence>> listDataOfProductCode = _kService.GetAllUsersAndAllProductCodesToRecommend(userId);
            var result = new Recommence(userId, productCodesOfUserLogging, listDataOfProductCode);
            return Ok(System.Text.Json.JsonSerializer.Serialize(result));
        }

        [HttpPost]
        [Route]
        public IHttpActionResult GetResult(ProductCode data)
        {
            
            var productCodes = data.FinalResult;
            if (productCodes.Count != 0)
            {
                var result = _product.GetByProductCodes(productCodes);
                return Ok(_mapper.Map<IEnumerable<ProductViewModel>>(result));
            }
            else
            {
                return Ok(_mapper.Map<IEnumerable<ProductViewModel>>(_kService.GetBestSellerProducts()));
            }
        }
    }

    public class ProductCode
    {
        public string Name { get; set; }
        public IList<string> FinalResult { get; set; }
    }
}
