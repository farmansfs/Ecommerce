using Ecommerce.Application.Shared.Services.Products;
using Ecommerce.Application.Shared.Services.Products.DTO;
using Ecommerce.Application.Shared.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getProducts")]
        public async Task<ActionResult<PagedResultDto<ProductDto>>> GetProducts([FromQuery] GetProductsInput input)
        {
            return Ok(await _productService.GetProducts(input));
        }

        [HttpGet("getCategories")]
        public async Task<ActionResult<PagedResultDto<ProductDto>>> GetCategories()
        {
            return Ok(await _productService.GetCategories());
        }
    }
}
