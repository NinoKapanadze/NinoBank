using NinoBank.Infrastructure.Repositories.Base.Interfaces;

namespace NinoBank.Infrastructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITransactionWriteRepository TransactionWriteRepository { get; }
        IUserWriteRepository UserWriteRepository { get; }
        Task CompleteAsync();
    }
}
