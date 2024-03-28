using AutoMapper;
using NinoBank.Application.Transactions.Commands.Add;
using NinoBank.Application.Users.Commands.Delete;
using NinoBank.Application.Users.Commands.Register;
using NinoBank.WebApi.Models;

namespace NinoBank.WebApi.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterModel, RegisterCommand>();
            CreateMap<DeleteUserModel, DeleteUserCommand>();
            CreateMap<AddTransactionModel, AddTransactionCommand>();
        }
    }
}
