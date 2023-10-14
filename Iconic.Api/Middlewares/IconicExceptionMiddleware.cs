using Iconic.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Iconic.Api.Middlewares
{
    public class IconicExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<IconicExceptionMiddleware> logger;

        public IconicExceptionMiddleware(RequestDelegate next, ILogger<IconicExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context);
            }
            catch(HttpStatusCodeException ex)
            {
                await this.HandleException(context, ex.Code, ex.Message);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.ToString());
                await this.HandleException(context, 500, ex.Message);
            }
        }
        public async Task HandleException(HttpContext context, int code, string message)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new
            {
                Code = code,
                Message = message
            });
        }
    }
}
