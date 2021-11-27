using Bank.Domain.Interfaces.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bank.Domain.Services.Common
{
    public abstract class ServiceBase<TEntity, TIRepository> where TIRepository : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly TIRepository _repository;

        public ServiceBase(TIRepository repository)
        {
            _repository = repository;
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public virtual TEntity GetById(int id)
            => _repository.GetById(id);

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
            => _repository.Find(expression);

        public virtual IEnumerable<TEntity> GetAll()
            => _repository.GetAll();
    }
}
