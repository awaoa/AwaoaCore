using Awaoa.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Awaoa.Core.Repository
{
    public class EfCoreRepository<TEntity> : EfCoreRepository<TEntity, long>, IRepository<TEntity>
           where TEntity : class, IEntity
    {
        public EfCoreRepository(DbContext context) : base(context)
        { }
    }

    public class EfCoreRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
           where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly DbContext dbContext;

        public DbSet<TEntity> Table => dbContext.Set<TEntity>();

        public bool SaveChanges { get; set; }

        public EfCoreRepository(DbContext context)
        {
            dbContext = context;
            SaveChanges = true;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params string[] includeProperties)
        {
            IQueryable<TEntity> query = Table;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await Table.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var entityEntry = await Table.AddAsync(entity);
            if (SaveChanges)
            {
                await dbContext.SaveChangesAsync();
            }
            return entityEntry.Entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            AttachIfNot(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            if (SaveChanges)
            {
                await dbContext.SaveChangesAsync();
            }
            return await Task.FromResult(entity);
        }

        public virtual async Task<TEntity> DeleteAsync(TPrimaryKey id)
        {
            TEntity entityToDelete = Table.Find(id);
            return await DeleteAsync(entityToDelete);
        }

        public virtual async Task<TEntity> DeleteAsync(TEntity entityToDelete)
        {
            AttachIfNot(entityToDelete);
            var entityEntry = Table.Remove(entityToDelete);
            if (SaveChanges)
            {
                await dbContext.SaveChangesAsync();
            }
            return await Task.FromResult(entityEntry.Entity);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.CountAsync(predicate);
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            var entityEntry = dbContext.ChangeTracker
                                 .Entries()
                                 .FirstOrDefault(entry => entry.Entity == entity);
            if (entityEntry != null)
            {
                return;
            }

           Table.Attach(entity);
        }
    }
}
