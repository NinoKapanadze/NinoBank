using MediatR;
using Microsoft.AspNetCore.Identity;
using NinoBank.Application.ResultWrapper;
using NinoBank.Domain.Entities;

namespace NinoBank.Application.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultWrapper.ResultWrapper>
    {
        private readonly UserManager<User> _userManager;

        public DeleteUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResultWrapper.ResultWrapper> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return ResultWrapper.ResultWrapper.BadRequest(Resources.UserWithEmailDoesNotExist);
            }

            var result = await _userManager.DeleteAsync(user);

            if(!result.Succeeded)
            {
                return ResultWrapper.ResultWrapper.InternalServerError(Resources.InternalServerError);
            }

            return ResultWrapper.ResultWrapper.Ok();
        }
    }
}
