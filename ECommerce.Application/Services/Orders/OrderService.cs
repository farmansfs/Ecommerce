using Ecommerce.Application.Shared.Services.Orders;
using Ecommerce.Application.Shared.Services.Orders.DTO;
using Ecommerce.Application.Shared.Services.Products.DTO;
using Ecommerce.Domain;
using Ecommerce.Domain.Repositories;
using Ecommerce.Domain.Shared.CurrentUser;
using Ecommerce.Domain.Shared.Enums;
using Ecommerce.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly ICurrentUserService _currentUser;

        public OrderService(IRepository<Order> orderRepository,
            IRepository<Product> productRepository,
            ICurrentUserService currentUser)
        {
            this._orderRepository = orderRepository;
            this._productRepository = productRepository;
            this._currentUser = currentUser;
        }

        public async Task<bool> CheckIfProductInStock(CheckIfProductInStock input)
        {
            var product = await _productRepository.FirstOrDefaultAsync(_productRepository.GetAll().Where(x => x.Id == input.ProductId));
            if (product != null && input.Amount < product.Stock)
            {
                return true;
            }
            return false;
        }

        public async Task<OrderState> CreateOrder(OrderDto input)
        {
            var order = new Order();
            order.Address = input.Adresss;
            foreach (var item in input.OrderLines)
            {
                var product = await _productRepository.FirstOrDefaultAsync(_productRepository.GetAll().Where(x => x.Id == item.ProductId));
                if (product != null && item.Amount < product.Stock)
                {
                    order.OrderLines.Add(new OrderLine
                    {
                        Price = product.Price,
                        ProductId = product.Id,
                        Amount = item.Amount,
                        Order = order
                    });
                }
                else
                {
                    throw new FriendlyException("Product does not exist or not have enough amount in stock", $"{product?.Name} - {product.Id}");
                }
            }
            order.State = OrderState.Accepted;
            await _orderRepository.Add(order);
            await _orderRepository.SaveChangesAsync();
            return order.State;
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            var currentUserId = _currentUser.GetCurrentUserId();
            var query = _orderRepository.GetAll().Where(x => x.UserId == currentUserId).Select(x => new OrderDto
            {
                Adresss = x.Address,
                CreationTime = x.CreationTime,
                State = x.State,
                OrderLines = x.OrderLines.Select(ol => new OrderLineDto
                {
                    Amount = ol.Amount,
                    Price = ol.Price,
                    Product = new ProductDto
                    {
                        Price = ol.Price,
                        Name = ol.Product.Name,
                        Description = ol.Product.Description,
                        Id = ol.ProductId
                    },
                }).ToList()
            });
            return await _orderRepository.ToListAsync(query);
        }
    }
}
