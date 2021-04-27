using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Conexia.SR.WebAPI.Extensions
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation(string.Format("{0} {1} - {2}{3}",
                        context.Request.Protocol, context.Request.Method, context.Request.Host, context.Request.Path));

            await _next(context);
        }
    }
}
