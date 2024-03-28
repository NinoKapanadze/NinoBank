using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinoBank.Domain.Entities;

namespace NinoBank.Infrastructure.EntityTypeConfigurations
{
    public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(t => t.Amount)
                   .HasColumnType("decimal(20, 4)")
                   .IsRequired();
        }
    }
}
