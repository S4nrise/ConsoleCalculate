using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewLogger
{
    public class CompositeLogger : ILogger
    {
        private readonly ConsoleLogger _consoleLogger;
        private readonly FileLogger _FileLogger;
        public CompositeLogger(ConsoleLogger consoleLogger, FileLogger fileLogger)
        {
            _consoleLogger = consoleLogger;
            _FileLogger = fileLogger;
        }
        public void LogError(Exception exception, string? additionalMessage = null)
        {
            _consoleLogger.LogError(exception, additionalMessage);
            _FileLogger.LogError(exception, additionalMessage);
        }

        public void LogInformation(string message)
        {
            _consoleLogger.LogInformation(message);
            _FileLogger.LogInformation(message);
        }
    }
}
