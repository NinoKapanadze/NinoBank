using Microsoft.EntityFrameworkCore;
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

        public async Task<User> GetDetailsAsync(Guid id)
        {
            return  await _dbSet.AsNoTracking()
                .Include(x => x.SentTransactions)
                .Include(x => x.RecievedTransactions)
                .FirstAsync(u => u.Id == id);
        }
    }
}
