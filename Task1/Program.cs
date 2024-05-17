
using System.Collections.Immutable;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 3) Console.WriteLine("Запустите программу, передавая в качестве параметров выражение вида \"a + b\", \"a - b\", \"a / b\" или  \"a * b\"");
            else
            {
                bool aParsed = Double.TryParse(args[0], out double a);
                bool bParsed = Double.TryParse(args[2], out double b);
                bool operatorParsed = allowableOperators.TryGetValue(args[1], out Func<double, double, double>? operation);
                if (aParsed && bParsed && operatorParsed && operation != null)
                    Console.WriteLine($"a {args[1]} b = {a} {args[1]} {b} = {operation(a, b):F3}");
                else
                {
                    if (!aParsed) Console.WriteLine($"Ошибка преобразования строки {args[0]} в значение переменной \"a\".");
                    if (!bParsed) Console.WriteLine($"Ошибка преобразования строки {args[2]} в значение переменной \"b\".");
                    if (!operatorParsed) Console.WriteLine($"Недопустимый оператор \"{args[1]}\". Допустимые операторы: {String.Join(", ", 
                    allowableOperators.Keys.Select(x => $"\"{x}\""))}.");
                }
            }
        }
        private static readonly ImmutableDictionary<string, Func<double, double, double>> allowableOperators =
        new Dictionary<string, Func<double, double, double>>
        {
        {"+", (a, b) => a + b },
        {"-", (a, b) => a - b },
        {"*", (a, b) => a * b },
        {"/", (a, b) => a / b }
        }.ToImmutableDictionary();
    }
}
