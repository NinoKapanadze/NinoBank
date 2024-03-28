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
        TEntity? Add(TEntity model);
        TEntity? Update(TEntity model);
        bool Delete(TEntity entity);
    }
}
