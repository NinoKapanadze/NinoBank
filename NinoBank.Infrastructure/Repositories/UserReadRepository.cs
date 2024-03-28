using NinoBank.Domain.Entities;
using NinoBank.Infrastructure.Data;
using NinoBank.Infrastructure.Repositories.Base.Interfaces;

namespace NinoBank.Infrastructure.Repositories.Base
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
