using MediatR;
using Microsoft.AspNetCore.Identity;
using NinoBank.Application.ResultWrappers.Generic;
using NinoBank.Application.Services;
using NinoBank.Domain.Entities;

namespace NinoBank.Application.Users.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ResultWrapper<string>>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;


        public LoginQueryHandler(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<ResultWrapper<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return ResultWrapper<string>.BadRequest(Resources.UserWithEmailDoesNotExist);
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return ResultWrapper<string>.BadRequest(Resources.IncorrectPassword);
            }

            var token = _tokenService.GenerateJwtToken(user.Id);

            return ResultWrapper<string>.Ok(token);
         }
    }
}
