using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tt1ap.CustomMiddleware
{
    public class CustomExHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exp)
            {
                await ExeptionHandlerAsync(context, exp);
                
            }
        }

        private async Task ExeptionHandlerAsync(HttpContext context, Exception ex)
        {
            var error = new ApiError(context, ex);

            //Test
            //error.Status = 500;

            if (error.Status == 500)
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                await context.Response.WriteAsync("<center><b style=\"color: Red; font-size:48px; top:50%\">Internal Server Error!</b><center><img src=\"https://myprestamodules.com/img/cms/500.png\" alt=\"alternatetext\">");
            }
            else
            {
                var result = JsonConvert.SerializeObject(error);
                context.Response.Clear();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = error.Status.Value;
                await context.Response.WriteAsync(result);
            }



        }
    }
}
