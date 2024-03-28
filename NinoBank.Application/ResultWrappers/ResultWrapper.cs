using NinoBank.Application.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinoBank.Application.ResultWrappers
{
    public class ResultWrapper
    {
        public OperationResult OperationResult { get; }
        public string? FailureReason { get; }
        public bool IsSuccess => string.IsNullOrEmpty(FailureReason);

        public ResultWrapper(OperationResult operationResult)
        {
            OperationResult = operationResult;
        }

        public ResultWrapper(string failureReason, OperationResult operationResult)
        {
            FailureReason = failureReason;
            OperationResult = operationResult;
        }

        public static ResultWrapper Ok() => new(OperationResult.Success);

        public static ResultWrapper BadRequest(string errorMessage) =>
           new(errorMessage, OperationResult.BadRequest);

        public static ResultWrapper NotFound(string errorMessage) =>
           new(errorMessage, OperationResult.NotFound);

        public static ResultWrapper InternalServerError(string errorMessage) =>
           new(errorMessage, OperationResult.InternalServerError);

        public static ResultWrapper InternalServerError() =>
            new(Resources.InternalServerError, OperationResult.InternalServerError);
    }
}
