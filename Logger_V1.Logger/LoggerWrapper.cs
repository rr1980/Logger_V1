using Logger_V1.Logger.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Logger_V1.Logger
{
    internal class LoggerWrapper : ILogger
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

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _logger.Log(state.ToString());
        }
    }
}