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
using static Ecommerce.Application.Shared.Shared.Endpoints.ApplicationEndpoints;

namespace Ecommerce.Controllers
{
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Products.GetProducts)]
        public async Task<ActionResult<PagedResultDto<ProductDto>>> GetProducts([FromQuery] GetProductsInput input)
        {
            return Ok(await _productService.GetProducts(input));
        }

        [HttpGet(Products.GetProductById)]
        public async Task<ActionResult<ProductDto>> GetProductById([FromQuery] Guid id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpGet(Products.GetCategories)]
        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            return Ok(await _productService.GetCategories());
        }
    }
}
