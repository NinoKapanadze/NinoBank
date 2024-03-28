using MediatR;
using Microsoft.AspNetCore.Identity;
using NinoBank.Application.ResultWrappers.Generic;
using NinoBank.Domain.Entities;

namespace NinoBank.Application.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResultWrapper<string>>
    {
        //private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ResultWrapper<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //var user = await _userManager.FindByEmailAsync(request.Email);
            //if (user == null)
            //{
            //    // User not found
            //    return ResultWrapper<string>.BadRequest("Invalid login attempt.");
            //}

            //var result = await _userManager.CheckPasswordAsync(user, request.Password);
            //if (result)
            //{
            //    // Password is correct. Here, you would generate a token or perform additional steps
            //    // necessary for your application's authentication process.
            //    // For demonstration, we'll just return a success message.
            //    return ResultWrapper<string>.Ok("User logged in successfully.");
            //}
            //else
            //{
            //    // Password is incorrect
            //    return ResultWrapper<string>.BadRequest("Invalid login attempt.");
            //}
            throw new NotImplementedException();
        }
    }
}
