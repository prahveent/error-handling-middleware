using ErrorHandlingMiddleware.Application;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ErrorHandlingMiddleware.Extensions
{
    public class ErrorHandleMiddleware
    {
        public ErrorHandleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        private readonly RequestDelegate next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var appErrorCode = (int)ApplcaitonErrorCode.UnknownError;
            if(ex is Application.ApplicationException)
            {
                var applicationError = ex as Application.ApplicationException;
                code = HttpStatusCode.BadRequest;
                appErrorCode = applicationError.ErrorCode;
            }

            var result = JsonConvert.SerializeObject(new ErrorResponse(appErrorCode, ex.Message));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
