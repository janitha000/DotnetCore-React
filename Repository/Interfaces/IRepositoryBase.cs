using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using React.Entity;

namespace React.Repository
{
    public interface IRepositryBase<T> where T : class, IEntitybase , new()
    {
        IEnumerable<T> GetAll();
        T GetSingle(string id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete (T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);

        
    }
}