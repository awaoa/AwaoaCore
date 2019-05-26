using Awaoa.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Awaoa.Core.Repository
{
    public interface IRepository<TEntity> : IRepository<TEntity, long>
               where TEntity : class, IEntity
    {
    }

    public interface IRepository<TEntity, TPrimaryKey>
               where TEntity : class, IEntity<TPrimaryKey>
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                 params string[] includeProperties);

        Task<TEntity> GetAsync(TPrimaryKey id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entityToUpdate);

        Task<TEntity> DeleteAsync(TPrimaryKey id);

        Task<TEntity> DeleteAsync(TEntity entityToDelete);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
