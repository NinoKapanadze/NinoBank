using NinoBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Application.Models
{
    public class GetSentTransactionDTO
    {
        public DateTime CreatedAt { get; set; } 
        public required Guid ReceiverId { get; set; }
        public required decimal Amount { get; set; }
    }
}
