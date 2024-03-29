using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NinoBank.Application.Transactions.Commands.Add;
using NinoBank.WebApi.Extensions;
using NinoBank.WebApi.Models;
using System.Security.Claims;

namespace NinoBank.WebApi.Controllers
{
    /// <summary>
    /// Handles transaction-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator for handling request/response.</param>
        /// <param name="mapper">The mapper for transforming objects.</param>
        public TransactionController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Transaction
        ///     {
        ///        "receiverId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///        "amount": 100.00
        ///     }
        ///
        /// </remarks>
        /// <param name="model">The transaction details.</param>
        /// <returns>A response indicating the result of the transaction operation.</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MakeTransaction([FromBody] AddTransactionModel model)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
            {
                return Unauthorized("Unable to identify the authenticated user.");
            }
            var command = _mapper.Map<AddTransactionCommand>(model);
            command.SenderId = userId;
            var result = await _mediator.Send(command);

            return StatusCode(result.OperationResult.ToHttpStatusCode(), result.IsSuccess ? result.Value : result.FailureReason);
        }
    }
}
