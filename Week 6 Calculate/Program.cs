using MyNewLogger;
using Week_6_Calculate;

internal class Program
{
    private static readonly ILogger _logger;
    private static readonly ConsoleLogger _consoleLogger = new ConsoleLogger();
    private static readonly FileLogger _fileLogger = new FileLogger();
    private static readonly CompositeLogger _compositeLogger = new CompositeLogger(_consoleLogger, _fileLogger);
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
                            calculator.Calculate(InputHandler(input));
                            Console.WriteLine("Для продолжения работы нажмите любую клавишу");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    }
            }
        }

    }
    public static List<string> InputHandler(string input)
    {
        var temp = input.Split(' ').ToList();
        return temp;
    }
}