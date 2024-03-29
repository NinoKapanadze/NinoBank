using NinoBank.Domain.Entities;

namespace NinoBank.Application.Models
{
    public class GetReceivedTransactionDTO
    {
        public DateTime CreatedAt { get; set; } 
        public required Guid SenderId { get; set; }
        public required decimal Amount { get; set; }
    }
}
