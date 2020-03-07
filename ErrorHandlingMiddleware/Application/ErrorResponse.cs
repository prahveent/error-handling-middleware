using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandlingMiddleware.Application
{
    public class ErrorResponse
    {
        public ErrorResponse()
        { }

        public ErrorResponse(int errorCode, string message)
        {
            this.ErrorCode = errorCode;
            this.Message = message;
        }

        public int ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
