using Ecommerce.Application.Shared.Services.Products;
using Ecommerce.Application.Shared.Services.Products.DTO;
using Ecommerce.Application.Shared.Shared;
using Ecommerce.Domain;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductService(IRepository<Product> productRepository,
            IRepository<Category> categoryRepository)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }

        public Task<List<CategoryDto>> GetCategories()
        {
            var query = _categoryRepository.GetAll().Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name
            });
            return _categoryRepository.ToListAsync(query);
        }

        public async Task<PagedResultDto<ProductDto>> GetProducts(GetProductsInput input)
        {
            var query = _productRepository.GetAll().Select(x => new ProductDto
            {
                Id = x.Id,
                Description = x.Description,
                Category = new CategoryDto
                {
                    Id = x.CategoryId,
                    Name = x.Category.Name
                },
                Name = x.Name,
                Price = x.Price
            });
            if (input.CategoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == input.CategoryId.Value);
            }
            if (!string.IsNullOrWhiteSpace(input.Search))
            {
                query = query.Where(x => x.Name.Contains(input.Search) || x.Category.Name.Contains(input.Search));
            }

            var totalCount = await _productRepository.CountAsync(query);
            var items = await _productRepository.ToListAsync(query);
            return new PagedResultDto<ProductDto>(items, totalCount);
        }
    }
}
