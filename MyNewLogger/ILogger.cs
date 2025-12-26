using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewLogger
{
    public interface ILogger
    {
        void LogInformation(string message);
        void LogError(Exception exception, string? additionalMessage = null);
    }
}
