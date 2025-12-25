internal class Program
{
    private static void Main(string[] args)
    {
        var helpMassage = @"Команды:
Help - Помощь
Exit - выход из приложения

Доступные операции:
Сложение +
Вычетание -
Умножение *
Деление /
Остаток от деления %
Возведение в степень ^";

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
                            Calculate(InputHandler(input));
                            Console.WriteLine("Для продолжения работы нажмите любую клавишу");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    }
            }
        }
    }
    public static void Calculate(List<string> input)
    {
        string action = input[1];

        var dictionary = new Dictionary<string, Func<double, double, double>>()
        {
            {"+", Sum},
            {"-", Subtract},
            {"*", Multiply},
            {"/", Divide},
            {"%", Mod},
            {"^", Pow},
        };

        Console.WriteLine(dictionary[input[1]](double.Parse(input[0]), double.Parse(input[2])));
    }
    public static List<string> InputHandler(string input)
    {
        var temp = input.Split(' ').ToList();
        return temp;
    }
    public static double Sum(double x, double y) => x + y;
    public static double Subtract(double x, double y) => x - y;
    public static double Multiply(double x, double y) => x * y;
    public static double Divide(double x, double y) => x / y;
    public static double Mod(double x, double y) => x % y;
    public static double Pow(double x, double y) => Math.Pow(x, y);
}
