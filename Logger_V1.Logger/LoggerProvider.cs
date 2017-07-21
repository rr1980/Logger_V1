using Logger_V1.Logger.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Logger_V1.Logger
{
    internal class LoggerProvider : ILoggerProvider
    {
        private readonly IConfigurationRoot _config;
        private readonly ConcurrentDictionary<string, LoggerWrapper> _loggers = new ConcurrentDictionary<string, LoggerWrapper>();
        private readonly ILoggerService _loggerService;

        public LoggerProvider(ILoggerService loggerService, IConfigurationRoot config)
        {
            _loggerService = loggerService;
            _config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new LoggerWrapper(_loggerService, name, _config));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}