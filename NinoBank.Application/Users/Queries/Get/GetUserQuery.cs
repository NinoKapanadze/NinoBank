using MediatR;
using NinoBank.Application.Models;
using NinoBank.Application.ResultWrappers.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Application.Users.Queries.Get
{
    public class GetUserQuery :IRequest<ResultWrapper<GetUserDTO>>
    {
        public Guid Id { get; set; }
    }
}
