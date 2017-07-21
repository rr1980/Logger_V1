using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;

namespace Logger_V1.Logger
{
    public class LoggerService
    {
        private IConfigurationRoot _configuration;
        private readonly ConcurrentDictionary<string, LoggerWrapper> _loggers = new ConcurrentDictionary<string, LoggerWrapper>();

        public LoggerService(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public ILogger_V1 CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new LoggerWrapper(name, _configuration));
        }
    }
}

