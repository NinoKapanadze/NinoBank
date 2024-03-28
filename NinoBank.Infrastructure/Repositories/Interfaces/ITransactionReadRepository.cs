using NinoBank.Domain;
using NinoBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Infrastructure.Repositories.Base.Interfaces
{
    public interface ITransactionReadRepository:IReadRepository<Transaction>
    {
    }
}
