namespace NinoBank.Application.Models
{
    public class AddTransactionDTO
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
