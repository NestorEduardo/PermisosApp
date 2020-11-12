using PermisosApp.Domain.Entities;
using PermisosApp.Repository.Abstract;
using System.Collections.Generic;

namespace PermisosApp.Services.Abstract
{
    public interface IBaseService<T, U> where T : BaseEntity where U : IBaseRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        public int Create(T entity);
        public int Update(T entity, int id);
        public int Delete(int id);
    }
}
