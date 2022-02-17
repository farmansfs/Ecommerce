using Ecommerce.Application.Shared.Services.Orders.DTO;
using Ecommerce.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Shared.Services.Orders
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetOrders();
        Task<OrderState> CreateOrder(OrderDto input);
        Task<bool> CheckIfProductInStock(CheckIfProductInStock input);
    }
}
