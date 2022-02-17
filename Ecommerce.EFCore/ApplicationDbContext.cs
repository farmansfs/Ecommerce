using Ecommerce.Domain;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.EFCore
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if(item.State == EntityState.Deleted && item.Entity is Entity)
                {
                    (item.Entity as Entity).IsDeleted = true;
                    item.State = EntityState.Modified;
                }
                if (item.State == EntityState.Added && item.Entity is Entity)
                {
                    (item.Entity as Entity).CreationTime = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Category>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Order>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<OrderLine>().HasQueryFilter(x => !x.IsDeleted);
            base.OnModelCreating(builder);
        }
    }
}
