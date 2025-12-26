using MyNewLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_6_Calculate
{
    public class Calculator
    {
        private readonly ILogger _logger;
        public Calculator(ILogger logger)
        {
            _logger = logger;
        }
        public void Calculate(List<string> input)
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
        public double Sum(double x, double y)
        {
            try
            {
                string opMessage = $"Sum: {x} + {y} = {x + y}";
                _logger.LogInformation(opMessage);
                return x + y;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибочка в сумме? Возможно очень большие числа");
                return 0.0;
            }
        }
        public double Subtract(double x, double y)
        {
            try
            {
                string opMessage = $"Subtract: {x} - {y} = {x - y}";
                _logger.LogInformation(opMessage);
                return x - y;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибочка в вычитании? Возможно очень большие числа");
                return 0.0;
            }
        }
        public double Multiply(double x, double y)
        {
            try
            {
                string opMessage = $"Multiply: {x} * {y} = {x * y}";
                _logger.LogInformation(opMessage);
                return x * y;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибочка в умножении? Возможно очень большие числа");
                return 0.0;
            }
        }
        public double Divide(double x, double y)
        {
            try
            {
                if (y == 0)
                {
                    var exception = new DivideByZeroException();
                    _logger.LogError(exception, "Ошибочка в делении? Возможно деление на 0?");
                    return 0.0;
                }
                string opMessage = $"Divide: {x} / {y} = {x / y}";
                _logger.LogInformation(opMessage);
                return x / y;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибочка в делении?");
                return 0.0;
            }
        }
        public double Mod(double x, double y)
        {
            try
            {
                string opMessage = $"Mod {x} % {y} = {x % y}";
                _logger.LogInformation(opMessage);
                return x % y;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибочка в остаточном делении?");
                return 0.0;
            }
        }
        public double Pow(double x, double y)
        {
            try
            {
                var res = Math.Pow(x, y);
                string opMessage = $"Pow: {x} ^ {y} = {res}";
                _logger.LogInformation(opMessage);
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибочка в возведении в степень?");
                return 0.0;
            }
        }
    }
}