using Ecommerce.Domain;
using Ecommerce.Domain.Repositories;
using Ecommerce.EFCore.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.EFCore
{
    public static class EFCoreModule
    {
        public static IServiceCollection AddEfCoreModule(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            //options.UseSqlServer("DefaultConnection"));
            options.UseInMemoryDatabase("eCommerce"));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            return services;
        }

        public static IApplicationBuilder SeedData(this IApplicationBuilder application)
        {
            var db = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var categories = new List<Category>
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Man Products",
                    CreationTime = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Woman Products",
                    CreationTime = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Child Products",
                    CreationTime = DateTime.Now,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Pet Products",
                    CreationTime = DateTime.Now,
                    IsDeleted = false
                }
            };
            var products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Man Product 1",
                    Description = ProductDescription,
                    Price = 11.99,
                    Stock = 10,
                    CategoryId = categories[0].Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Man Product 2",
                    Description = ProductDescription,
                    Price = 9.99,
                    Stock = 10,
                    CategoryId = categories[0].Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Man Product 3",
                    Description = ProductDescription,
                    Price = 2.99,
                    Stock = 10,
                    CategoryId = categories[0].Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Woman Product 1",
                    Description = ProductDescription,
                    Price = 2.09,
                    Stock = 10,
                    CategoryId = categories[1].Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Woman Product 2",
                    Description = ProductDescription,
                    Price = 12.99,
                    Stock = 10,
                    CategoryId = categories[1].Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Woman Product 3",
                    Description = ProductDescription,
                    Price = 12.99,
                    Stock = 10,
                    CategoryId = categories[1].Id
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Pet Product 1",
                    Description = ProductDescription,
                    Price = 12.9,
                    Stock = 10,
                    CategoryId = categories[2].Id
                },
            };

            if (!db.Categories.Any())
            {
                db.Categories.AddRange(categories);
                db.SaveChanges();
            }
            if (!db.Products.Any())
            {
                db.Products.AddRange(products);
                db.SaveChanges();
            }
            return application;
        }
        private const string ProductDescription = "Can’t stop buying plants? Unbeleafable. Don’t worry—us too! Cover yourself in your favourite obsession in our NEW I Love Plants Oodie! For every I Love Plants Oodie sold, one tree is planted across Australia.";

    }
}
