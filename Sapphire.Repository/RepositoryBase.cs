using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sapphire.Repository;
namespace Sapphire.Contracts
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext repositoryContext;

        public RepositoryBase(RepositoryContext repContext) => this.repositoryContext = repContext;
        public void Create(T entity) => repositoryContext.Add(entity);

        public void Delete(T entity) => repositoryContext.Remove(entity);
        public void Update(T entity) => repositoryContext.Update(entity);

        public IQueryable<T> GetAll(bool trackChange) => !trackChange ? repositoryContext.Set<T>().AsNoTracking() : repositoryContext.Set<T>();

        public IQueryable<T> GetThroughCondition(Expression<Func<T, bool>> exp, bool trackChange) => !trackChange ? repositoryContext.Set<T>().Where(exp).AsNoTracking() : repositoryContext.Set<T>().Where(exp);

        
    }
}
