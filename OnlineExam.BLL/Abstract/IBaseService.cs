using OnlineExam.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.BLL.Abstract
{
    interface IBaseService<T>
        where T : IEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetByID(int id);
        ICollection<T> GetList();
    }
}