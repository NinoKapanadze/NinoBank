using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NinoBank.Infrastructure.Data;
using NinoBank.Infrastructure.Repositories.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Infrastructure.Repositories.Base
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class
    {
        private protected readonly ILogger<WriteRepository<TEntity>> _logger;
        protected readonly DataContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public WriteRepository(
            ILogger<WriteRepository<TEntity>> logger,
            DataContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity?> AddAsync(TEntity model)
        {
            _logger.LogInformation("Adding model in DB. Model - {model}", model.GetType().Name);
            var entityEntry = await _dbSet.AddAsync(model);

            if (await SaveChangesAsync())
            {
                return entityEntry.Entity;
            }

            return null;
        }

        public async Task<bool> UpdateAsync(TEntity model)
        {
            _dbSet.Update(model);
            _logger.LogInformation("Updating model in DB. Model - {model}", model.GetType().Name);

            return await SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                _logger.LogWarning("Attempted to delete a null entity.");
                return false;
            }

            _dbSet.Remove(entity);
            _logger.LogInformation("Deleting model from DB. Model - {model}", entity.GetType().Name);

            return await SaveChangesAsync();
        }
    }
}
