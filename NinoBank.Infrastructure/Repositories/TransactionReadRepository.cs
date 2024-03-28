using NinoBank.Domain.Entities;
using NinoBank.Infrastructure.Data;
using NinoBank.Infrastructure.Repositories.Base.Interfaces;

namespace NinoBank.Infrastructure.Repositories.Base
{
    public class TransactionReadRepository : ReadRepository<Transaction>, ITransactionReadRepository
    {
        public TransactionReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
