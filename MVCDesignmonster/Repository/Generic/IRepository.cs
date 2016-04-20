using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MVCDesignmonster.Models;

namespace MVCDesignmonster.Repository
{
    public interface IRepository<T>
    {
        void Create(T newEntity);
        void Delete(T entity);
        IQueryable<T> Search(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
    }
}
