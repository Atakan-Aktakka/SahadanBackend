using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sahadan.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T:class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default);
 
    }
   
}