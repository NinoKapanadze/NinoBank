using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NinoBank.Application.Models;
using NinoBank.Application.ResultWrappers.Generic;
using NinoBank.Domain.Entities;

namespace NinoBank.Application.Users.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResultWrapper<RegisterUserDTO>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ResultWrapper<RegisterUserDTO>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Balance = request.Balance
            };
            
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(e => e.Description).Aggregate((current, next) => current + "; " + next);

                return ResultWrapper<RegisterUserDTO>.BadRequest(errorMessages);
            }

            var registerUserDTO = _mapper.Map<RegisterUserDTO>(user);

           return  ResultWrapper<RegisterUserDTO>.Ok(registerUserDTO);

        }
    }
    
}
