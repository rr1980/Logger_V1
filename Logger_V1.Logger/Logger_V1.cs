using Logger_V1.Logger.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Logger_V1.Logger
{
    public enum LogType
    {
        Information,
        Debug,
        Warnig,
        Error
    }

    internal class Logger_V1<T> : ILogger_V1<T>
    {
        private IConfigurationRoot _configuration;

        private bool _withStackTrace = true;

        private DateTime _dateNow
        {
            get { return DateTime.Now.ToLocalTime(); }
        }

        private Type Type
        {
            get { return typeof(T); }
        }

        public Logger_V1(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        void ILogger_V1<T>.Log(string msg, LogType logType = LogType.Information)
        {
            Match lastMatch = _getStackTraceMatch();
            if (lastMatch == null)
            {
                _log(msg, "System", logType);
                return;
            }
            else
            {
                string _namespace = lastMatch.Groups["namespace"].Value.ToString();
                string _class = lastMatch.Groups["class"].Value.ToString();
                string _method = lastMatch.Groups["method"].Value.ToString();
                //string _file = lastMatch.Groups["file"].Value.ToString();
                //string _line = lastMatch.Groups["line"].Value.ToString();

                _log(msg, _namespace + "." + _class + "." + _method, logType);
            }
        }

        private static Match _getStackTraceMatch()
        {
            var st = Environment.StackTrace;

            Regex r = new Regex(@"at (?<namespace>.*)\.(?<class>.*)\.(?<method>.*(.*)) in (?<file>.*):line (?<line>\d*)", RegexOptions.Multiline);
            var matches = r.Matches(st).Cast<Match>();

            var lastMatch = matches.FirstOrDefault(lm => !lm.Groups["namespace"].Value.ToString().Contains("Logger_V1.Logger"));
            return lastMatch;
        }

        void ILogger_V1<T>.LogException(string from, Exception ex)
        {
            var msg = ex.Message;

            if (_withStackTrace)
            {
                msg += Environment.NewLine + ex.StackTrace;
            }

            _log(msg, from, LogType.Error);
        }

        private void _log(string msg, string from, LogType logType)
        {
            var output = string.Format("{0} : {1,-15} : {2,-10} " + Environment.NewLine + " \t{3}" + Environment.NewLine, _dateNow, logType.ToString(), from, msg);
            Debug.WriteLine(output);
        }
    }
}