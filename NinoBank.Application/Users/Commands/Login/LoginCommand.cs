using MediatR;
using NinoBank.Application.ResultWrappers.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Application.Users.Commands.Login
{
    public class LoginCommand:IRequest<ResultWrapper<string>>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
