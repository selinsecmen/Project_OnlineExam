using OnlineExam.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnlineExam.Core.DataAccess.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        // Singleton Pattern
        readonly TContext context = OnlineExam.Core.DataAccess.EntityFramework.EFDbContextSingleton<TContext>.Instance;

        public void Add(TEntity entity)
        {
          
            var addEntity = context.Entry(entity);
            addEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            var updateEntity = context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            var deleteEntity = context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return context.Set<TEntity>().Where(filter).FirstOrDefault();
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return context.Set<TEntity>().ToList();
            }
            else
            {
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public ICollection<TEntity> GetAllById(Expression<Func<TEntity, bool>> filter)
        {
            return context.Set<TEntity>().Where(filter).ToList();
        }
    }
}
