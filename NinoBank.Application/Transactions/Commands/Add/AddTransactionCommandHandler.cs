using AutoMapper;
using MediatR;
using NinoBank.Application.Models;
using NinoBank.Application.ResultWrappers.Generic;
using NinoBank.Domain.Entities;
using NinoBank.Infrastructure.Repositories.Base.Interfaces;
using NinoBank.Infrastructure.UnitOfWorks.Interfaces;

namespace NinoBank.Application.Transactions.Commands.Add
{
    public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, ResultWrapper<AddTransactionDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;

        public AddTransactionCommandHandler(IUnitOfWork unitOfWork, IUserReadRepository userReadRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userReadRepository = userReadRepository;
            _mapper = mapper;
        }

        public async Task<ResultWrapper<AddTransactionDTO>> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var receiver = await _userReadRepository.GetSingleAsync(user => user.Id == request.ReceiverId);

            var sender = await _userReadRepository.GetSingleAsync(user => user.Id == request.SenderId);


            if (sender == null || receiver == null)
            {
                return ResultWrapper<AddTransactionDTO>.BadRequest(Resources.IncorrectId);
            }

            if (sender.Balance < request.Amount)
            {
                return ResultWrapper<AddTransactionDTO>.BadRequest(Resources.NotEnoughFundsForTransaction);
            }


            sender.Balance -= request.Amount;
            receiver.Balance += request.Amount;

            var isSenderUpdated =  _unitOfWork.UserWriteRepository.Update(sender);
            var isRecieverUpdated=  _unitOfWork.UserWriteRepository.Update(receiver);

            if (isSenderUpdated == null || isRecieverUpdated == null)
            {
                return ResultWrapper<AddTransactionDTO>.InternalServerError(Resources.InternalServerError);
            }

            var transaction = new Transaction
            {
                SenderId = request.SenderId,
                ReceiverId = request.ReceiverId,
                Amount = request.Amount,
                Sender = sender,
                Receiver = receiver
            };

            if ( _unitOfWork.TransactionWriteRepository.Add(transaction) == null)
            {
                return ResultWrapper<AddTransactionDTO>.InternalServerError(Resources.InternalServerError);
            }

            await _unitOfWork.CompleteAsync();

            var transactionDto = _mapper.Map<AddTransactionDTO>(transaction);

            return ResultWrapper<AddTransactionDTO>.Ok(transactionDto);
        }
    }

}
