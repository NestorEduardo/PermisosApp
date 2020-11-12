using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PermisosApp.Repository.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        int CommitChanges();
        T GetById(int id);
        List<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> where, string includeProperties = "");
        IQueryable<T> Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include);
        IQueryable<T> Get(params Expression<Func<T, object>>[] include);
        int Insert(T entity);
        public int Update(T entity);
        int Update(T entity, int id);
        public int SoftDelete(int id);
        int Count();
    }
}
