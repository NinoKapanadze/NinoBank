using NinoBank.Infrastructure.Repositories.Base.Interfaces;

namespace NinoBank.Infrastructure.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITransactionWriteRepository TransactionWriteRepository { get; }
        IUserWriteRepository UserWriteRepository { get; }
        Task CompleteAsync();
    }
}
