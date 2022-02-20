using Ecommerce.Application.Shared.Services.Orders;
using Ecommerce.Application.Shared.Services.Orders.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Ecommerce.Application.Shared.Shared.Endpoints.ApplicationEndpoints;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet(Orders.GetOrders)]
        public async Task<ActionResult> GetOrders()
        {
            return Ok(await _orderService.GetOrders());
        }

        [HttpGet(Orders.CheckIfProductInStock)]
        [AllowAnonymous]
        public async Task<ActionResult> CheckIfProductInStock([FromQuery] CheckIfProductInStock input)
        {
            return Ok(await _orderService.CheckIfProductInStock(input));
        }

        [HttpPost(Orders.CreateOrder)]
        public async Task<ActionResult> CreateOrder([FromBody] OrderDto input)
        {
            return Ok(await _orderService.CreateOrder(input));
        }
    }
}
