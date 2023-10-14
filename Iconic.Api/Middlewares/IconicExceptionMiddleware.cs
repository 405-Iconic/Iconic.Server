using Iconic.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;
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
            catch(HttpStatusCodeException)
            {

            }
        }
    }
}
