using Ecommerce.Application.Shared.Services.Orders;
using Ecommerce.Application.Shared.Services.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.HttpApi.Client.Interfaces
{
    public interface IECommerceClient
    {
        IProductService Products { get; }
        IOrderService Orders { get; }
    }
}
