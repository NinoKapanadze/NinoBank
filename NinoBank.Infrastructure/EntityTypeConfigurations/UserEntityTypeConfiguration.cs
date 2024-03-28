using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinoBank.Domain.Entities;

namespace NinoBank.Infrastructure.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();

            builder.HasMany(u => u.SentTransactions)
                   .WithOne(t => t.Sender)
                   .HasForeignKey(t => t.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.RecievedTransactions)
                   .WithOne(t => t.Receiver)
                   .HasForeignKey(t => t.ReceiverId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.Balance)
                   .HasColumnType("decimal(20, 4)")
                   .IsRequired();
        }
    }
}
