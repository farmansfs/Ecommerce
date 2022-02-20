using Ecommerce.Application.Shared.Services.Orders;
using Ecommerce.Application.Shared.Services.Products;
using Ecommerce.HttpApi.Client.Implementations;
using Ecommerce.HttpApi.Client.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Ecommerce.HttpApi.Client
{
    public class ECommereClient : IECommerceClient
    {
        public ECommereClient(string baseUrl)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            Products = new ProductServiceModule(httpClient);
            Orders = new OrderServiceModule(httpClient);
        }
        public IProductService Products { get; private set; }
        public IOrderService Orders { get; private set; }
    }
}
