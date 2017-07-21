﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Logger_V1.Logger
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger_V1<LoggerMiddleware> _logger;

        public LoggerMiddleware(RequestDelegate next, LoggerService loggerService)
        {
            _next = next;
            _logger = loggerService.CreateLogger<LoggerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            //var watch = new Stopwatch();
            //watch.Start();
            _logger.Log("Hallo");
            await _next(context);

            //context.Response.Headers.Add("X-Processing-Time-Milliseconds", new[] { watch.ElapsedMilliseconds.ToString() });
        }
    }
}
