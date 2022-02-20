using Ecommerce.Application.Shared.Services.Orders;
using Ecommerce.Application.Shared.Services.Products;
using Ecommerce.Domain.Shared.CurrentUser;
using ECommerce.Application.Services.Orders;
using ECommerce.Application.Services.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            return services;
        }
    }
}
