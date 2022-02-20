using Ecommerce.Application.Shared.Services.Orders;
using Ecommerce.Application.Shared.Services.Orders.DTO;
using Ecommerce.Application.Shared.Shared.Endpoints;
using Ecommerce.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.HttpApi.Client.Implementations
{
    public class OrderServiceModule : BaseModule, IOrderService
    {
        public OrderServiceModule(HttpClient httpClient) : base(httpClient)
        {
        }

        public Task<bool> CheckIfProductInStock(CheckIfProductInStock input)
        {
            return Get<bool>($"{ApplicationEndpoints.Orders.CheckIfProductInStock}?productId={input.ProductId}&amount={input.Amount}");
        }

        public Task<OrderState> CreateOrder(OrderDto input)
        {
            return Post<OrderState,OrderDto>(ApplicationEndpoints.Orders.CreateOrder, input);
        }

        public Task<List<OrderDto>> GetOrders()
        {
            return Get<List<OrderDto>>(ApplicationEndpoints.Orders.GetOrders);
        }
    }
}
