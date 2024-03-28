using Microsoft.Extensions.Logging;
using NinoBank.Domain.Entities;
using NinoBank.Infrastructure.Data;
using NinoBank.Infrastructure.Repositories;
using NinoBank.Infrastructure.Repositories.Base;
using NinoBank.Infrastructure.Repositories.Base.Interfaces;
using NinoBank.Infrastructure.UnitOfWorks.Interfaces;

namespace NinoBank.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _dbContext;
        private readonly ILogger<WriteRepository<User>> _userLogger;
        private readonly ILogger<WriteRepository<Transaction>> _transactionLogger;

        public IUserWriteRepository UserWriteRepository { get; private set; }
        public ITransactionWriteRepository TransactionWriteRepository { get; private set; }

        public UnitOfWork(DataContext dbContext, ILogger<WriteRepository<User>> userLogger, ILogger<WriteRepository<Transaction>> transactionLogger)
        {
            _dbContext = dbContext;
            _userLogger = userLogger;
            _transactionLogger = transactionLogger;

            UserWriteRepository = new UserWriteRepository(userLogger, dbContext);
            TransactionWriteRepository = new TransactionWriteRepository(transactionLogger, dbContext);
        }
        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
