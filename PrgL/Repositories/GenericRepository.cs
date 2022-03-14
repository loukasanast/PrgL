using Microsoft.EntityFrameworkCore;
using PrgL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrgL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public virtual Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
