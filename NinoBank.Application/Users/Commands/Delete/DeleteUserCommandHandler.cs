using MediatR;
using Microsoft.AspNetCore.Identity;
using NinoBank.Application.ResultWrappers;
using NinoBank.Domain.Entities;

namespace NinoBank.Application.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultWrapper>
    {
        private readonly UserManager<User> _userManager;

        public DeleteUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResultWrapper> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.IdString);

            if (user == null)
            {
                return ResultWrapper.BadRequest(Resources.UserWithEmailDoesNotExist);
            }

            var result = await _userManager.DeleteAsync(user);

            if(!result.Succeeded)
            {
                return ResultWrapper.InternalServerError(Resources.InternalServerError);
            }

            return ResultWrapper.NoContent();
        }
    }
}
