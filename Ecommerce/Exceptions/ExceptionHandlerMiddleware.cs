using Ecommerce.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ecommerce.Exceptions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = 200;
                var result = new ErrorResponse();
                switch (error)
                {
                    case FriendlyException e:
                        // custom application error
                        result.StatusCode = (int)HttpStatusCode.BadRequest;
                        result.Message = e.Message;
                        result.Details = e.Details;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        result.StatusCode = (int)HttpStatusCode.NotFound;
                        result.Message = e.Message;
                        break;
                    default:
                        // unhandled error
                        result.StatusCode = (int)HttpStatusCode.InternalServerError;
                        result.Message = "Internal Server Error";
                        break;
                }
                await response.WriteAsJsonAsync(result);
            }
        }
    }
}
