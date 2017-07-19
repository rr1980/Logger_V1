using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Logger_V1.Logger
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly IConfigurationRoot _config;
        private readonly ConcurrentDictionary<string, Logger> _loggers = new ConcurrentDictionary<string, Logger>();

        public LoggerProvider(IConfigurationRoot config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new Logger(name, _config));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
