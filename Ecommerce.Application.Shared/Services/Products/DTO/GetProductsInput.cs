using Ecommerce.Application.Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Shared.Services.Products.DTO
{
    public class GetProductsInput:PagedRequestDto
    {
        public Guid? CategoryId { get; set; }
        public string Search { get; set; }
    }
}
