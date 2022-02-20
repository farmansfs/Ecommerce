using Ecommerce.Application.Shared.Services.Products.DTO;
using Ecommerce.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Shared.Services.Orders.DTO
{
    public class OrderDto
    {
        public OrderState  State { get; set; }
        public DateTime CreationTime { get; set; }
        public string Adresss { get; set; }
        public List<OrderLineDto> OrderLines { get; set; }
    }
    public class OrderLineDto
    {
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
    }
}
