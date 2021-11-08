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
    //T => Generics has a contraint => should be only a type of IEntity interface or class
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Instantiates ServiceDbContext class and assigns it to _context field
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(ServiceDbContext context)
        {
            _context = context;
        }

        private readonly ServiceDbContext _context;
        /// <summary>
        /// GenericRepository class uses the generic type T
        /// therefore, DbSet cannot be accessed as a property of data context.
        /// That’s why a generic DbSet variable is declared that points to an appropriate DbSet based on the type of T
        /// </summary>
        private DbSet<T> _dbTable => _context.Set<T>();

        /// <summary>
        /// Inserts a new element of a T entity to the database
        /// </summary>
        /// <param name="entity">a new entity</param>
        /// <returns>void</returns>
        public async Task CreateAsync(T entity)
        {
            _dbTable.Add(entity);
            //The insertion will be saved in the database
            await SaveAsync();
        }

        /// <summary>
        /// Deletes an element of a T entity from the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>void</returns>
        public async Task DeleteAsync(T entity)
        {
            _dbTable.Remove(entity);
            //Changes are saved after the deletion
            await SaveAsync();
        }

        /// <summary>
        /// Checks whether an element exists in the database
        /// </summary>
        /// <param name="id">search is done using id</param>
        /// <returns>boolean</returns>
        public bool Exists(int id)
        {
            return _dbTable.Any(a => a.Id == id);
        }

        /// <summary>
        /// Retrieves all elements of a T entity
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbTable.ToListAsync();            
        }

        /// <summary>
        /// Retrieves one element of a table
        /// </summary>
        /// <param name="id">id of element</param>
        /// <returns>an element of a type T</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbTable.SingleOrDefaultAsync(a => a.Id == id);            
        }

        /// <summary>
        /// Updates an element in the database
        /// </summary>
        /// <param name="entity">an element to be updated</param>
        /// <returns>Task</returns>
        public async Task UpdateAsync(T entity)
        {
            _dbTable.Update(entity);
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
