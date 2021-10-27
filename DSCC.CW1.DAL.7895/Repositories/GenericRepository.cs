using DSCC.CW1.DAL._7895.DalDbContext;
using DSCC.CW1.DAL._7895.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DSCC.CW1.DAL._7895.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        public GenericRepository(ServiceDbContext context)
        {
            _context = context;
        }

        private readonly ServiceDbContext _context;
        private DbSet<T> _dbTable => _context.Set<T>();
        
        public async Task CreateAsync(T entity)
        {
            _dbTable.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbTable.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _dbTable.Any(a => a.Id == id);
        }

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            return await IncludeNavigationProperties(_dbTable, navigationProperties).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] navigationProperties)
        {
            return await IncludeNavigationProperties(_dbTable, navigationProperties).SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbTable.Update(entity);
            await _context.SaveChangesAsync();
        }

        public static IQueryable<T> IncludeNavigationProperties(IQueryable<T> query ,params Expression<Func<T, object>>[] navigationProperties)
        {
            if (navigationProperties != null)
            {
                query = navigationProperties.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;
        }
    }
}
