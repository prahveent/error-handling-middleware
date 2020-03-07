using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandlingMiddleware.Services
{
    class ErrorMiddlewareTestService : IErrorMiddlewareTestService
    {
        public async Task ApplicationErrorTest()
        {
            throw new Application.ApplicationException((int)ExServiceErrorCode.SomeErrorTypeCode, "Error description");
        }

        public Task SystemErrorTest()
        {
            throw new NotImplementedException();
        }
    }
}
