using MediatR;
using NinoBank.Application.Models;
using NinoBank.Application.ResultWrappers.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Application.Transactions.Commands.Add
{
    public class AddTransactionCommand:IRequest<ResultWrapper<AddTransactionDTO>>
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public decimal Amount { get; set; }
    }
}
