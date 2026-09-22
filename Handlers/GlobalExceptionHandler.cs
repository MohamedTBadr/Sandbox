using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace Sandbox.Handlers
{
    public class GlobalExceptionHandler:ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var correlationId = context.Request.Properties.ContainsKey("X-Correlation-ID") ? context.Request.Properties["X-Correlation-ID"].ToString() : "N/A";
            var exception = context.Exception;
            Log.Error(exception, "Unhandled exception occurred with correlation ID: {CorrelationId}", correlationId);

            context.Result = new ResponseMessageResult(
                new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("An unexpected error occurred. Please try again later."),
                    ReasonPhrase = "Internal Server Error"
                });

            return Task.CompletedTask;
        }
    }
}