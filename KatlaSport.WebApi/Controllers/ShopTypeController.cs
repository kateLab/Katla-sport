using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using KatlaSport.Services.ShopManagement;
using KatlaSport.WebApi.CustomFilters;
using Microsoft.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace KatlaSport.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api/types")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [CustomExceptionFilter]
    [SwaggerResponseRemoveDefaults]
    public class ShopTypeController : ApiController
    {
        private readonly IRepository<ShopType> _shopTypeRepositoryService;
        private readonly IShopService _shopService;

        public ShopTypeController(IRepository<ShopType> shopTypeService, IShopService shopService)
        {
            _shopTypeRepositoryService = shopTypeService ?? throw new ArgumentNullException(nameof(shopTypeService));
            _shopService = shopService ?? throw new ArgumentNullException(nameof(shopService));
        }

        [HttpGet]
        [Route("show")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of shop types.", Type = typeof(ShopTypeListItem[]))]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetShopTypes()
        {
            var shopTypes = await _shopTypeRepositoryService.GetShopTypesAsync();
            return Ok(shopTypes);
        }

        [HttpGet]
        [Route("show/{shopTypeId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a shop type.", Type = typeof(ShopType))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetShopType(int shopTypeId)
        {
            var shopType = await _shopTypeRepositoryService.GetShopTypeAsync(shopTypeId);
            return Ok(shopType);
        }

        [HttpGet]
        [Route("show/{shopTypeId:int:min(1)}/shops")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Returns a list of shops.", Type = typeof(ShopListItem))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> GetShops(int shopTypeId)
        {
            var shop = await _shopService.GetShopsAsync(shopTypeId);
            return Ok(shop);
        }

        [HttpPost]
        [Route("create")]
        [SwaggerResponse(HttpStatusCode.Created, Description = "Creates a new shopType.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> AddShopType([FromBody] ShopType createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _shopTypeRepositoryService.CreateShopTypeAsync(createRequest);
            var shopTypes = await _shopTypeRepositoryService.GetShopTypesAsync();
            var shopType = shopTypes.Last();
            var location = string.Format("/api/types/show/{0}", shopType.Id);
            return Created<ShopType>(location, shopType);
        }

        [HttpPost]
        [Route("update/{shopTypeId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Updates an existed shop type.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> UpdateShopType([FromUri] int shopTypeId, [FromBody] ShopType shopType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            shopType.Id = shopTypeId;
            await _shopTypeRepositoryService.UpdateShopTypeAsync(shopType); 
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [HttpPost]
        [Route("destroy/{shopTypeId:int:min(1)}")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "Deletes an existed shop type.")]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Conflict)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IHttpActionResult> DeleteShopType([FromUri] int shopTypeId)
        {
            await _shopTypeRepositoryService.DeleteShopTypeAsync(new ShopType() {Id = shopTypeId }); 
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}