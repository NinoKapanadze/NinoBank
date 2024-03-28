using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Application.Models.Enums
{
    public enum OperationResult
    {
        Success,
        NotFound,
        BadRequest,
        Unauthorized,
        Forbidden,
        InternalServerError
    }
}
