using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Logger_V1.Logger
{

    public interface ILogger_V1
    {
        void Log(string msg);
    }

    public class LoggerWrapper : ILogger, ILogger_V1
    {
        private readonly string _name;
        private readonly IConfigurationRoot _config;

        public LoggerWrapper(string name, IConfigurationRoot config)
        {
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
            (this as ILogger_V1).Log(state.ToString());
        }

        void ILogger_V1.Log(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}

