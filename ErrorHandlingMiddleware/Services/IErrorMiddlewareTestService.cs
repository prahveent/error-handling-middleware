using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandlingMiddleware.Services
{
    public interface IErrorMiddlewareTestService
    {
        Task ApplicationErrorTest();
        Task SystemErrorTest();
    }
}
