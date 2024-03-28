using Microsoft.Extensions.Logging;
using NinoBank.Domain;
using NinoBank.Domain.Entities;
using NinoBank.Infrastructure.Data;
using NinoBank.Infrastructure.Repositories.Base.Interfaces;

namespace NinoBank.Infrastructure.Repositories.Base
{
    public class TransactionWriteRepository : WriteRepository<Transaction>, ITransactionWriteRepository
    {
        public TransactionWriteRepository(ILogger<WriteRepository<Transaction>> logger, DataContext dbContext) : base(logger, dbContext)
        {
        }
    }
}
