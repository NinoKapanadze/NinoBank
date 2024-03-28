namespace NinoBank.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public required User Sender { get; set; }
        public required Guid SenderId { get; set; }
        public required User Reciever { get; set; }
        public required Guid RecieverId { get; set; }
        public required decimal Amount { get; set; }
    }
}
