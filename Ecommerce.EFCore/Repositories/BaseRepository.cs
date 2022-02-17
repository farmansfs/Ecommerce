using Ecommerce.Domain;
using Ecommerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.EFCore.Repositories
{
    public class BaseRepository<T> :IRepository<T> where T:Entity
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<T> Add(T entity)
        {
            await applicationDbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            applicationDbContext.Set<T>().Remove(entity);
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return applicationDbContext.Set<T>().AsQueryable();
        }

        public T Update(T entity)
        {
            applicationDbContext.Set<T>().Update(entity);
            return entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<K>> ToListAsync<K>(IQueryable<K> query)
        {
            return await query.ToListAsync();
        }

        public async Task<K> FirstOrDefaultAsync<K>(IQueryable<K> query)
        {
            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync<K>(IQueryable<K> query)
        {
            return await query.CountAsync();
        }
    }
}
