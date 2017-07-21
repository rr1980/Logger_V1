using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Logger_V1.Logger
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = (ILogger)loggerFactory.CreateLogger<LoggerWrapper>();
        }

        public async Task Invoke(HttpContext context)
        {
            //var watch = new Stopwatch();
            //watch.Start();
            _logger.LogInformation("Hallo");
            await _next(context);

            //context.Response.Headers.Add("X-Processing-Time-Milliseconds", new[] { watch.ElapsedMilliseconds.ToString() });
        }
    }
}
