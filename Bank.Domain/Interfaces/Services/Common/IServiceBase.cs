using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bank.Domain.Interfaces.Services.Common
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetAll();
    }
}
