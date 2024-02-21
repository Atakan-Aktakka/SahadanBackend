using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sahadan.DataAccess.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity:class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetById(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
    }
   
}