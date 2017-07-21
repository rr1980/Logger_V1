using Logger_V1.Logger.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Logger_V1.Logger
{
    internal class Logger_V1<T> : ILogger_V1<T>
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
}

