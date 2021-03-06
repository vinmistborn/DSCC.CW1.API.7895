using DSCC.CW1.DAL._7895.DBO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DSCC.CW1.DAL._7895.Repositories
{
    //T => Generics has a contraint => should be only a type of IEntity interface
    public interface IRepository<T> where T : IEntity
    {
        bool Exists(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
