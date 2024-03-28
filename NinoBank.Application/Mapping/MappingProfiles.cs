using AutoMapper;
using NinoBank.Application.Models;
using NinoBank.Domain.Entities;

namespace NinoBank.Application.Mapping
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, RegisterUserDTO>();
            CreateMap<Transaction, AddTransactionDTO>();
        }
    }
}
