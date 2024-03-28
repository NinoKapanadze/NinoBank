using NinoBank.Application.Models.Enums;

namespace NinoBank.WebApi.Extensions
{
    public static class OperationResultExtensions
    {
        public static int ToHttpStatusCode(this OperationResult result)
        {
            switch (result)
            {
                case OperationResult.Success:
                    return StatusCodes.Status200OK;
                case OperationResult.NotFound:
                    return StatusCodes.Status404NotFound;
                case OperationResult.BadRequest:
                    return StatusCodes.Status400BadRequest;
                case OperationResult.InternalServerError:
                    return StatusCodes.Status500InternalServerError;
                case OperationResult.Forbidden:
                    return StatusCodes.Status403Forbidden;
                default:
                    return StatusCodes.Status500InternalServerError;
            }
        }
    }
}
