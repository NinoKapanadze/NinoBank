using Microsoft.Extensions.Logging;
using NinoBank.Domain.Entities;
using NinoBank.Infrastructure.Data;
using NinoBank.Infrastructure.Repositories.Base;
using NinoBank.Infrastructure.Repositories.Base.Interfaces;

namespace NinoBank.Infrastructure.Repositories
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(ILogger<WriteRepository<User>> logger, DataContext dbContext) : base(logger, dbContext)
        {
        }
    }
}
