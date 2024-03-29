using MediatR;
using NinoBank.Application.ResultWrapper;

namespace NinoBank.Application.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<ResultWrapper.ResultWrapper>
    {
        public required string Email { get; set; }
    }
}
