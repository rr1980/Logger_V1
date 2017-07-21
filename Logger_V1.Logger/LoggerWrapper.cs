using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Logger_V1.Logger
{

    public interface ILogger_V1<T>
    {
        void Log(string msg);
    }

    public class Logger_V1<T> : ILogger_V1<T>
    {
        private IConfigurationRoot _configuration;

        public Logger_V1(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        void ILogger_V1<T>.Log(string msg)
        {
            Debug.WriteLine(msg);
        }
    }

    public class LoggerWrapper : ILogger
    {
        private readonly string _name;
        private readonly IConfigurationRoot _config;

        private readonly ILogger_V1<LoggerWrapper> _logger;

        public LoggerWrapper(LoggerService loggerService, string name, IConfigurationRoot config)
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

