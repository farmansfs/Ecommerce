using Ecommerce.Application.Shared.Services.Products.DTO;
using Ecommerce.Application.Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Shared.Services.Products
{
    public interface IProductService
    {
        Task<PagedResultDto<ProductDto>> GetProducts(GetProductsInput input);

        Task<List<CategoryDto>> GetCategories();
        Task<ProductDto> GetProductById(Guid Id);
    }
}
