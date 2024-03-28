using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Resgister([FromBody] RegisterModel registerModel)
        {
            var command = _mapper.Map<RegisterCommand>(registerModel);

            var result = await _mediator.Send(command);

            return StatusCode(result.OperationResult.ToHttpStatusCode(), result.IsSuccess? result.Value: result.FailureReason);
        }
    }
}
