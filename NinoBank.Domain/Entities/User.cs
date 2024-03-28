using Microsoft.AspNetCore.Identity;

namespace NinoBank.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required decimal Balance { get; set; }


        public ICollection<Transaction> SentTransactions { get; set; } = new List<Transaction>();
        public ICollection<Transaction> RecievedTransactions { get; set; } = new List<Transaction>();


    }
}
