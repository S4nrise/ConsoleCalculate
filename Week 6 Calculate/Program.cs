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
        double op1 = double.Parse(input[0]);
        double op2 = double.Parse(input[2]);
        string action = input[1];

        switch (action)
        {
            case "+": Console.WriteLine(Sum(op1, op2)); break;
            case "-": Console.WriteLine(Subtract(op1, op2)); break;
            case "*": Console.WriteLine(Multiply(op1, op2)); break;
            case "/": Console.WriteLine(Divide(op1, op2)); break;
            case "%": Console.WriteLine(Mod(op1, op2)); break;
            case "^": Console.WriteLine(Pow(op1, op2)); break;
        }
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
