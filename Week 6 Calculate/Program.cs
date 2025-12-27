using MyNewLogger;
using Week_6_Calculate;

internal class Program
{
    private static List<ILogger> _loggers = new List<ILogger>()
    {
     {new ConsoleLogger() },
     {new FileLogger()},
    };
    private static readonly CompositeLogger _compositeLogger = new CompositeLogger(_loggers);
    private static readonly string helpMassage = @"Команды:
Help - Помощь
Exit - выход из приложения

Доступные операции:
Сложение +
Вычетание -
Умножение *
Деление /
Остаток от деления %
Возведение в степень ^";
    private static void Main(string[] args)
    {

        Calculator calculator = new Calculator(_compositeLogger);
        while (true)
        {
            Console.WriteLine("Калькулятор!");
            Console.WriteLine();
            Console.Write("Ввод: ");
            var input = Console.ReadLine().Trim().ToLower();
            switch (input)
            {
                case "help":
                    {
                        Console.WriteLine(helpMassage);
                        break;
                    }
                case "exit":
                    {
                        return;
                    }
                default:
                    {
                        if (input != "")
                        {
                            try//Реализация исключения без повторения в методах калькулятора
                            {
                                calculator.Calculate(ParseString(input));
                            }
                            catch (Exception ex)
                            {
                                foreach (var logger in _loggers)
                                {
                                    logger.LogError(ex);
                                    logger.LogInformation(ex.Message);
                                }
                            }
                            Console.WriteLine("Для продолжения работы нажмите любую клавишу");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    }
            }
        }

    }
    public static List<string> ParseString(string input)
    {
        var temp = input.Split(' ').ToList();
        return temp;
    }
}