using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Shared.Shared.Endpoints
{
    public static class ApplicationEndpoints
    {
        public static class Orders
        {
            public const string Controller = "/api/order";
            public const string GetOrders = Controller + "/getOrders";
            public const string CheckIfProductInStock = Controller + "/checkIfProductInStock";
            public const string CreateOrder = Controller + "/createOrder";
        }

        public static class Products
        {
            public const string Controller = "/api/product";
            public const string GetProducts = Controller + "/getProducts";
            public const string GetProductById = Controller + "/getProductById";
            public const string GetCategories = Controller + "/getCategories";
        }
    }
}
