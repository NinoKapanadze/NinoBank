using MediatR;
using NinoBank.Application.ResultWrapper.Generic;

namespace NinoBank.Application.Users.Queries.Login
{
    public class LoginQuery :IRequest<ResultWrapper<string>>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
