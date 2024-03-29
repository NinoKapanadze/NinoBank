using MediatR;
using NinoBank.Application.Models;
using NinoBank.Application.ResultWrapper.Generic;

namespace NinoBank.Application.Transactions.Commands.Add
{
    public class AddTransactionCommand:IRequest<ResultWrapper<AddTransactionDTO>>
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public decimal Amount { get; set; }
    }
}
