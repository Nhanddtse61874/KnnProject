using Azure.Storage.Queues;
using Business.KnnProject.Services;
using KnnProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KnnProject.Controllers
{
    [RoutePrefix("api/knearestneibor-management/users")]
    public class KNearestNeighborController : ApiControllerBase
    {
        private readonly IKNearestNeighborService _kService;
        private readonly IUserService _user;
        private readonly IProductService _product;

        private static readonly string connectionString = "AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;DefaultEndpointsProtocol=http;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";

        public KNearestNeighborController()
        {
            _kService = new KNearestNeighborService();
            _user = new UserService();
            _product = new ProductService();
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IHttpActionResult> GetData(int userId)
        {
            var productCodesOfUserLogging = _kService.GetAllProductCodeByUserIdToRecommend(userId);
            
            IList<List<ProductRecommence>> listDataOfProductCode = _kService.GetAllUsersAndAllProductCodesToRecommend(userId);
            var result = new Recommence(userId, productCodesOfUserLogging, listDataOfProductCode);
            await CreateQueue(System.Text.Json.JsonSerializer.Serialize(result));
            return Ok();
        }

        [HttpGet]
        [Route]
        public IHttpActionResult GetBestSeller()
        {
            return Ok(_mapper.Map<IEnumerable<ProductViewModel>>(_kService.GetBestSellerProducts()));
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

        private async Task CreateQueue(string message)
        {
            QueueClient queueClient = new QueueClient(connectionString, "azure");
            await queueClient.SendMessageAsync(Base64Encode(message));
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }

    public class ProductCode
    {
        public string Name { get; set; }
        public IList<string> FinalResult { get; set; }
    }
}
