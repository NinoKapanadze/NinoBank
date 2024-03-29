using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinoBank.Application.Users.Commands.Delete;
using NinoBank.Application.Users.Commands.Register;
using NinoBank.Application.Users.Queries.Login;
using NinoBank.WebApi.Extensions;
using NinoBank.WebApi.Models;
using System.Security.Claims;

namespace NinoBank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <remarks>
        /// Password must meet the following criteria:
        /// - Minimum length is 6 characters.
        /// - Must contain at least one numeric digit ('0'-'9').
        /// - Must contain at least one lowercase character ('a'-'z').
        /// - Must contain at least one uppercase character ('A'-'Z').
        /// - Must contain at least one non-alphanumeric character (e.g., '!', '@', '#', etc.).
        /// 
        /// Sample request:
        ///
        ///     POST /api/User/Register
        ///     {
        ///        "email": "user@example.com",
        ///        "firstName": "John",
        ///        "lastName": "Doe",
        ///        "password": "Password123!",
        ///        "balance": 100.00
        ///     }
        ///
        /// </remarks>
        /// <param name="registerModel">The registration details.</param>
        /// <returns>A response indicating success or failure.</returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Resgister([FromBody] RegisterModel registerModel)
        {
            var command = _mapper.Map<RegisterCommand>(registerModel);

            var result = await _mediator.Send(command);

            return StatusCode(result.OperationResult.ToHttpStatusCode(), result.IsSuccess? result.Value: result.FailureReason);
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <returns>A response indicating success or failure with reason.</returns>
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized("Unable to identify the authenticated user.");
            }

            var command = new DeleteUserCommand { IdString = userIdClaim.Value };

            var result = await _mediator.Send(command);

            return StatusCode(result.OperationResult.ToHttpStatusCode(), result.IsSuccess ? true : result.FailureReason);
        }

        /// <summary>
        /// Authenticates a user based on username and password.
        /// </summary>
        /// <param name="model">The login details including username and password.</param>
        /// <returns>
        /// If successful, an IActionResult containing a JWT token for authorization in subsequent requests.
        /// If failed, an IActionResult containing the error reason.
        /// </returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            var query = _mapper.Map<LoginQuery>(model);

            var result = await _mediator.Send(query);

            return StatusCode(result.OperationResult.ToHttpStatusCode(), result.IsSuccess ? result.Value : result.FailureReason);
        }
    }
}
