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

    public class SQLProfileRepository : IRepository<Profile>
    {
        public void Create(Profile newEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Profile entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Profile> Search(Expression<Func<Profile, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Profile> GetAll()
        {
            throw new NotImplementedException();
        }
    }

    public class SQLStartpageRepository : IRepository<Startpage>
    {
        public void Create(Startpage newEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Startpage entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Startpage> Search(Expression<Func<Startpage, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Startpage> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
