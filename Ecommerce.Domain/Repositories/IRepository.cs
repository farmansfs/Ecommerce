using Ecommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        IQueryable<T> GetAll();
        Task<int> SaveChangesAsync();
        Task<List<K>> ToListAsync<K>(IQueryable<K> query);
        Task<K> FirstOrDefaultAsync<K>(IQueryable<K> query);
        Task<int> CountAsync<K>(IQueryable<K> query);
    }
}
