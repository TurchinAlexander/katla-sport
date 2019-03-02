using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.ProductManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/requests")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class ProductStoreRequestController : ApiController
    {
        private readonly IProductStoreRequestService _productStoreRequestService;

        public ProductStoreRequestController(IProductStoreRequestService productStoreRequestService)
        {
            _productStoreRequestService = productStoreRequestService ?? throw new ArgumentNullException(nameof(productStoreRequestService));
        }


        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Return a list of all requests of all product stores.", Type = typeof(ProductStoreItemRequest[]))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetRequest()
        {
            var productStoreRequests = await _productStoreRequestService.GetRequestsAsync();
            return Ok(productStoreRequests);
        }

        [HttpGet]
        [Route("{requestId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a product store request.", Type = typeof(ProductStoreItemRequest))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetRequest([FromUri] int requestId)
        {
            var productStoreRequest = await _productStoreRequestService.GetRequestAsync(requestId);
            return Ok(productStoreRequest);
        }

        [HttpPost]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new product store request.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddRequest([FromBody] UpdateRequestRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productStoreRequest = await _productStoreRequestService.CreateRequestAsync(createRequest);
            var location = string.Format("api/products/{0}", productStoreRequest.Id);
            return Created<ProductStoreItemRequest>(location, productStoreRequest);
        }

        [HttpPut]
        [Route("{requestId:int:min(1)}/completed")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Sets deleted status for an existed product category.")]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> SetCompletedStatus([FromUri] int requestId)
        {
            await _productStoreRequestService.SetCompletedStatus(requestId);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}