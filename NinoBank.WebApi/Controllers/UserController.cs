using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NinoBank.Application.Users.Commands.Delete;
using NinoBank.Application.Users.Commands.Register;
using NinoBank.WebApi.Extensions;
using NinoBank.WebApi.Models;

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
        /// <param name="model">The user deletion details.</param>
        /// <returns>A response indicating success or failure.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteUserModel model)
        {
            var command = _mapper.Map<DeleteUserCommand>(model);

            var result = await _mediator.Send(command);

            return StatusCode(result.OperationResult.ToHttpStatusCode(), result.IsSuccess ? true : result.FailureReason);
        }
    }
}
