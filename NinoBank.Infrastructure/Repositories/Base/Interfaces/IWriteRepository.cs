using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Infrastructure.Repositories.Base.Interfaces
{
    public interface IWriteRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> AddAsync(TEntity model);
        Task<bool> UpdateAsync(TEntity model);
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<bool> DeleteAsync(TEntity entity);
    }
}
