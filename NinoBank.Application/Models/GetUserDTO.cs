using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Application.Models
{
    public class GetUserDTO
    {
        public required Guid Id { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required decimal Balance { get; set; }

        public ICollection<GetSentTransactionDTO>? SentTransactions { get; set; } 
        public ICollection<GetReceivedTransactionDTO>? RecievedTransactions { get; set; }
    }
}
