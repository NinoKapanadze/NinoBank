using MediatR;
using NinoBank.Application.Models;
using NinoBank.Application.ResultWrappers.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Application.Users.Commands.Register
{
    public class RegisterCommand: IRequest<ResultWrapper<RegisterUserDTO>>
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public decimal Balance { get; set; }

    }
}
