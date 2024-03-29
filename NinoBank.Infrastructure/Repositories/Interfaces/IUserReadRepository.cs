using NinoBank.Domain.Entities;
using System.Security.AccessControl;

namespace NinoBank.Infrastructure.Repositories.Base.Interfaces
{
    public interface IUserReadRepository:IReadRepository<User>
    {
        public Task<User> GetDetailsAsync(Guid id);

    }
}
