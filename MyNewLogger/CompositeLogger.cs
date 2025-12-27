using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewLogger
{
    public class CompositeLogger : ILogger
    {
        //private readonly ConsoleLogger _consoleLogger;
        //private readonly FileLogger _FileLogger;
        private readonly IList<ILogger> _loggers = new List<ILogger>();
        //public CompositeLogger(ConsoleLogger consoleLogger, FileLogger fileLogger)
        public CompositeLogger(IList<ILogger> loggers)
        {
            _loggers = loggers;
        }
        public void LogError(Exception exception, string? additionalMessage = null)
        {
            foreach (var logger in _loggers)
            {
                logger.LogError(exception, additionalMessage);
                
            }
        }

        public void LogInformation(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.LogInformation(message);
            }
        }
    }
}
