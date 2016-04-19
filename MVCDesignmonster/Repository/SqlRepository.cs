using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace MVCDesignmonster.Repository
{
    public class SqlRepository<T> : IRepository<T>
        where T : class
    {
        private DbSet<T> _context;

        public SqlRepository(DbContext context)
        {
            _context = context.Set<T>();
        }

        public void Create(T newEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return _context.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}