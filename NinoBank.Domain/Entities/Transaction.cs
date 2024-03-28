namespace NinoBank.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public required User Sender { get; set; }
        public required Guid SenderId { get; set; }
        public required User Receiver { get; set; }
        public required Guid ReceiverId { get; set; }
        public required decimal Amount { get; set; }
    }
}
