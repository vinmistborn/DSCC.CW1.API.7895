using DSCC.CW1.API._7895.DBO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DSCC.CW1.API._7895.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        bool Exists(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] navigationProperties);
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties);
    }
}
