using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Shared.Services.Orders.DTO
{
    public class CheckIfProductInStock
    {
        public Guid ProductId { get; set; }
        public double Amount { get; set; }
    }
}
