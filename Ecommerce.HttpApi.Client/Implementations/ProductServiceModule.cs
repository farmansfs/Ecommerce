using Ecommerce.Application.Shared.Services.Products;
using Ecommerce.Application.Shared.Services.Products.DTO;
using Ecommerce.Application.Shared.Shared;
using Ecommerce.Application.Shared.Shared.Endpoints;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.HttpApi.Client.Implementations
{
    public class ProductServiceModule : BaseModule, IProductService
    {
        public ProductServiceModule(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<List<CategoryDto>> GetCategories()
        {
            return Get<List<CategoryDto>>(ApplicationEndpoints.Products.GetCategories);
        }

        public Task<ProductDto> GetProductById(Guid Id)
        {
            return Get<ProductDto>(ApplicationEndpoints.Products.GetProductById);
        }

        public Task<PagedResultDto<ProductDto>> GetProducts(GetProductsInput input)
        {
            return Get<PagedResultDto<ProductDto>>(ApplicationEndpoints.Products.GetProducts);
        }
    }
}
