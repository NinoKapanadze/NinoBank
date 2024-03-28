using MediatR;
using NinoBank.Application.ResultWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Application.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<ResultWrapper>
    {
        public required string Email { get; set; }
    }
}
