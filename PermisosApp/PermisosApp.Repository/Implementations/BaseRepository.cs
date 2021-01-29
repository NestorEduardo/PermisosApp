using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PermisosApp.Data;
using PermisosApp.Domain.Entities;
using PermisosApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PermisosApp.Repository.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext Database;
        protected DbSet<T> DbSet => Database.Set<T>();
        protected BaseRepository(ApplicationDbContext database) => Database = database;
        public int CommitChanges() => Database.SaveChanges();
        public int Count() => Database.Set<T>().Count();
        public IQueryable<T> Get(Expression<Func<T, bool>> where, string includeProperties = "")
        {
            IQueryable<T> query = Database.Set<T>().AsQueryable();

            foreach (string includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (where != null)
            {
                query = query.Where(where);
            }

            return query;
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = Database.Set<T>().AsQueryable();

            foreach (Expression<Func<T, object>> includeProperty in include)
            {
                query = query.Include(includeProperty);
            }

            if (where != null)
            {
                query = query.Where(where);
            }

            return query;
        }
        
        public IQueryable<T> Get(params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = Database.Set<T>().AsQueryable();

            foreach (Expression<Func<T, object>> includeProperty in include)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }
        public T GetById(int id) => Database.Set<T>().Find(id);
        public int Insert(T entity)
        {
            Database.Set<T>().Add(entity);
            return CommitChanges();
        }
        public int SoftDelete(int id)
        {
            T entity = GetById(id);
            entity.DeletedAt = DateTime.UtcNow;
            entity.IsActive = false;
            Database.Entry(entity).State = EntityState.Modified;
            return Database.SaveChanges();
        }
        public int Update(T entity)
        {
            Database.Set<T>().Attach(entity);
            Database.Entry(entity).State = EntityState.Modified;
            return CommitChanges();
        }
        public int Update(T entity, int id)
        {
            EntityEntry<T> entry = Database.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                var attachedEntity = Database.Set<T>().Find(id);

                if (attachedEntity != null)
                {
                    entity.CreatedAt = attachedEntity.CreatedAt;
                    entity.Id = attachedEntity.Id;

                    EntityEntry<T> attachedEntry = Database.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }

            return CommitChanges();
        }
        public List<T> GetAll() => Database.Set<T>().Where(e => e.IsActive).ToList();
    }
}
