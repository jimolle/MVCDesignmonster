using System;
using System.Linq;
using System.Linq.Expressions;

namespace MVCDesignmonster.BusinessObjects.Repository.Generic
{
    public interface IRepository<T>
    {
        void Create(T newEntity);
        void Delete(T entity);
        IQueryable<T> Search(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
    }
}
