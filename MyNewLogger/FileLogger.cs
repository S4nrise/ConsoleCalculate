using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewLogger
{
    public class FileLogger : ILogger
    {
        public void LogError(Exception exception, string? additionalMessage = null)
        {
            FileWorker(exception.Message, additionalMessage);
        }

        public void LogInformation(string message)
        {
            FileWorker(message);
        }

        public void FileWorker(string message, string? additionalMessage = null)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                if (additionalMessage != null)
                {
                    sw.WriteLine($"Message - {message}, Additional message - {additionalMessage}");
                }
                else sw.WriteLine($"Message - {message}");
            }
        }
    }
}
