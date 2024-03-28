using NinoBank.Application.Models.Enums;

namespace NinoBank.Application.ResultWrappers.Generic
{
    public class ResultWrapper<T> : ResultWrapper
    {
        private readonly T? _value;
        public T Value => IsSuccess ? _value! : throw
            new InvalidOperationException(Resources.ValueCanNotBeAccessed);

        public ResultWrapper(T value, OperationResult operationResult) : base(operationResult)
        {
            _value = value;
        }

        public ResultWrapper(string failureReason, OperationResult operationResult) : base(failureReason, operationResult)
        {
        }

        public static ResultWrapper<T> Ok(T value) => new(value, OperationResult.Success);

        public new static ResultWrapper<T> BadRequest(string errorMessage) => new(errorMessage,
             OperationResult.BadRequest);

        public new static ResultWrapper<T> InternalServerError(string errorMessage) =>
           new(errorMessage, OperationResult.InternalServerError);

        public new static ResultWrapper<T> InternalServerError() =>
            new(Resources.InternalServerError, OperationResult.InternalServerError);
    }
}
