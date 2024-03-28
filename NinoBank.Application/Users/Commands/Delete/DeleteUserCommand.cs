using MediatR;
using NinoBank.Application.ResultWrappers;

namespace NinoBank.Application.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<ResultWrapper>
    {
        public required string Email { get; set; }
    }
}
