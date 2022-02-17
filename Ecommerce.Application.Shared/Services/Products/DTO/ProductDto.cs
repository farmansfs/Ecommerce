using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Shared.Services.Products.DTO
{
    [DebuggerDisplay("Product - {Name}")]
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
