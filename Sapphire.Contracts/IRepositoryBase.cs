using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sapphire.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll(bool trackChange);
        IQueryable<T> GetThroughCondition(Expression<Func<T, bool>> exp, bool trackChange);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);  

    }
}
