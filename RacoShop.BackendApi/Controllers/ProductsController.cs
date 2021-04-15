using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RacoShop.Application.Catalog.Products;
using RacoShop.ViewModel.Catalog.ProductImages;
using RacoShop.ViewModel.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RacoShop.BackendApi.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;

        public ProductsController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        //https://localhost:port/product?pageIndex=1&pageSize=10&CategoryId
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId,[FromQuery]GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryId(languageId, request);
            return Ok(products);
        }

        //https://localhost:port/product/1
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _manageProductService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Can't not find product");
            return Ok(product);
        }

        //https://localhost:port/product/1
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productId = await _manageProductService.Create(request);
            if (productId == 0)
                return BadRequest();

            var product = _manageProductService.GetById(productId, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _manageProductService.Update(request);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResult = await _manageProductService.Delete(productId);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSuccess = await _manageProductService.UpdatePrice(productId, newPrice);
            if (!isSuccess)
                return BadRequest();

            return Ok();
        }

        //image
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm]ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var imageId = await _manageProductService.AddImages(productId, request);
            if (imageId == 0)
                return BadRequest();

            var image = await _manageProductService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        //https://localhost:port/product/1
        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _manageProductService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Can not find iamge");
            return Ok(image);
        }

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdatImage(int imageId, [FromForm]ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _manageProductService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        } 

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult>RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _manageProductService.RemoveImages(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

    }
}
