using OnlineExam.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineExam.Core.DataAccess
{
    public interface IEntityRepository<T>
        where T : class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> filter);
        ICollection<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}