using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Shared.Services.Products.DTO
{
    [DebuggerDisplay("Category - {Name}")]
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
