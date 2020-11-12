using PermisosApp.Domain.Entities;
using PermisosApp.Repository.Abstract;
using PermisosApp.Services.Abstract;
using System.Collections.Generic;

namespace PermisosApp.Services.Implementations
{
    public abstract class BaseService<T, U> : IBaseService<T, U> where T : BaseEntity where U : IBaseRepository<T>
    {
        protected U repository;
        public BaseService(U repository) => this.repository = repository;
        public int Create(T entity) => repository.Insert(entity);
        public int Update(T entity, int id) =>  repository.Update(entity, id);
        public int Delete(int id) => repository.SoftDelete(id);
        public virtual List<T> GetAll() => repository.GetAll();
        public T GetById(int id) => repository.GetById(id);
    }
}
