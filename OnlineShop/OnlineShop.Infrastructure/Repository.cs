using Microsoft.EntityFrameworkCore;
using OnlineShop.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure
{
    public interface IRepository<TContext, TEntity> : IDisposable, IAsyncDisposable
        where TContext : BaseDbContext
        where TEntity : BaseEntity
    {
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> ConstainsAsync(TEntity entity);
        Task<bool> ConstainsAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);
        Task AddAsync(params TEntity[] entities);

        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(params TEntity[] entities);

        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(params TEntity[] entities);
        Task DeleteAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindByIdAsync(object id);


        IQueryable<TEntity> SelectAll();
        IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> predicate);
    }

    public class Repository<TContext, TEntity> : IRepository<TContext, TEntity>
        where TContext : BaseDbContext
        where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private TContext _dbContext;
        public Repository(TContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).CountAsync();
        }


        public virtual async Task<bool> ConstainsAsync(TEntity entity)
        {
            return await _dbSet.ContainsAsync(entity);
        }

        public virtual async Task<bool> ConstainsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            int count = await CountAsync(predicate);
            return count > 0;
        }


        public virtual async Task AddAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (ValidationException dbEx)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task AddAsync(params TEntity[] entities)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch (ValidationException dbEx)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public virtual async Task UpdateAsync(TEntity entity)
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (ValidationException dbEx)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task UpdateAsync(params TEntity[] entities)
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (ValidationException dbEx)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public virtual async Task DeleteAsync(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (ValidationException dbEx)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task DeleteAsync(params TEntity[] entities)
        {
            try
            {
                _dbSet.RemoveRange(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch (ValidationException dbEx)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                _dbSet.RemoveRange(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch (ValidationException dbEx)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var entities = await _dbSet.Where(predicate).AsNoTracking().ToListAsync();
                _dbSet.RemoveRange(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch (ValidationException dbEx)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> FindByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual IQueryable<TEntity> SelectAll()
        {
            return _dbSet.AsQueryable();
        }

        public virtual IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }


        #region Implement Dispose Object
        public virtual void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public virtual async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);
            Dispose(disposing: false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext is not null)
                    _dbContext.Dispose();

                _dbContext = null;
            }
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (_dbContext is not null)
            {
                await _dbContext.DisposeAsync().ConfigureAwait(false);
            }
            _dbContext = null;
        }
        #endregion
    }
}