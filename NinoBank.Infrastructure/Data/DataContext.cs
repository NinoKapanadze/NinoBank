using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NinoBank.Domain.Entities;

namespace NinoBank.Infrastructure.Data
{
    public class DataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
