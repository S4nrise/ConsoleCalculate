
namespace MyNewLogger
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(Exception exception, string? additionalMessage = null)
        {
            Console.WriteLine($"Message: {exception.Message}", additionalMessage);
        }

        public void LogInformation(string message)
        {
            Console.WriteLine($"Log - {message}");
        }
    }
}
