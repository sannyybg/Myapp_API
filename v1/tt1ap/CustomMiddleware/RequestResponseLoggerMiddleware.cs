using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tt1ap.CustomMiddleware
{
    public class RequestResponseLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<RequestResponseLoggerMiddleware> _logger;

        public RequestResponseLoggerMiddleware(RequestDelegate next, ILogger<RequestResponseLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogInformation($"Request Method Type: { context.Request.Method}, Time:{DateTime.Now}");
                await _next.Invoke(context);
                _logger.LogInformation($"Type: {context.Response.ContentType}, StatusCode: {context.Response.StatusCode}, Date: {DateTime.Now}");

            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var error = new ApiError(context, ex);

            //log
            _logger.Log(error.LogLevel, ex, "{TraceId}, {Title}, {Code}, {Message}",
                error.TraceId, error.TraceId, error.Code, error.Detail);

            var result = JsonConvert.SerializeObject(error);

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.Status.Value;

            await context.Response.WriteAsync(result);
        }
    }
}
