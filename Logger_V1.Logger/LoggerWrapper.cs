using Logger_V1.Logger.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

//using System.Diagnostics;

namespace Logger_V1.Logger
{
    internal class LoggerWrapper : ILogger, IExceptionFilter, IDisposable
    {
        private readonly string _name;
        private readonly IConfigurationRoot _config;

        private readonly ILogger_V1<LoggerWrapper> _logger;

        public LoggerWrapper(ILoggerService loggerService, string name, IConfigurationRoot config)
        {
            _logger = loggerService.CreateLogger<LoggerWrapper>();
            _name = name;
            _config = config;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (exception != null)
            {
                return;
            }

            LogType lt = LogType.Information;

            switch (logLevel)
            {
                case LogLevel.Trace:
                    lt = LogType.Debug;
                    break;

                case LogLevel.Debug:
                    lt = LogType.Debug;
                    break;

                case LogLevel.Information:
                    lt = LogType.Information;
                    break;

                case LogLevel.Warning:
                    lt = LogType.Warnig;
                    break;

                case LogLevel.Error:
                    Debug.WriteLine("HIER FEHLT ETWAS!!! LoggerWrapper.Log");
                    break;

                case LogLevel.Critical:
                    Debug.WriteLine("HIER FEHLT ETWAS!!! LoggerWrapper.Log");
                    break;

                case LogLevel.None:
                    lt = LogType.Information;
                    break;
            }

            _logger.Log(state.ToString(), lt);
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogException(context.ActionDescriptor.DisplayName, context.Exception);
        }
    }
}