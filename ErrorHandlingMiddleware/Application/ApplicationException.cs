using System;
using System.Runtime.Serialization;

namespace ErrorHandlingMiddleware.Application
{
    [Serializable]
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message)
        {
            this.ErrorCode = (int)ApplcaitonErrorCode.UnknownError;
        }
        public ApplicationException(int appErrorCode, string message) : base(message)
        {
            this.ErrorCode = appErrorCode;
        }

        public ApplicationException(string message, Exception inner) : base(message, inner)
        {
            this.ErrorCode = (int)ApplcaitonErrorCode.UnknownError;
        }

        public ApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }

        public int ErrorCode { get; }
    }

    enum ApplcaitonErrorCode
    {
        UnknownError,
    }
}
