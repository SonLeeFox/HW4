using System.Globalization;

namespace ConverterApp;

static class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Converter converter = new(
            ReadDecimal("Введіть курс долара до гривні (грн за 1 USD): "),
            ReadDecimal("Введіть курс євро до гривні (грн за 1 EUR): "));

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1 - Гривні в долари");
            Console.WriteLine("2 - Гривні в євро");
            Console.WriteLine("3 - Долари в гривні");
            Console.WriteLine("4 - Євро в гривні");
            Console.WriteLine("0 - Вихід");

            int choice = ReadChoice();
            if (choice == 0)
            {
                return;
            }

            decimal amount = ReadDecimal("Введіть суму: ");

            try
            {
                switch (choice)
                {
                    case 1:
                        Print(amount, "UAH", converter.UahToUsd(amount), "USD");
                        break;
                    case 2:
                        Print(amount, "UAH", converter.UahToEur(amount), "EUR");
                        break;
                    case 3:
                        Print(amount, "USD", converter.UsdToUah(amount), "UAH");
                        break;
                    case 4:
                        Print(amount, "EUR", converter.EurToUah(amount), "UAH");
                        break;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Помилка: занадто велике число.");
            }
        }
    }

    private static void Print(decimal amount, string from, decimal result, string to)
    {
        Console.WriteLine($"{amount:F2} {from} = {result:F2} {to}");
    }

    private static int ReadChoice()
    {
        while (true)
        {
            Console.Write("Виберіть пункт меню: ");
            string? input = Console.ReadLine();

            if (input is null)
            {
                Environment.Exit(0);
            }

            if (int.TryParse(input, out int choice) && choice >= 0 && choice <= 4)
            {
                return choice;
            }

            Console.WriteLine("Введіть ціле число від 0 до 4.");
        }
    }

    private static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (input is null)
            {
                Environment.Exit(0);
            }

            if (decimal.TryParse(input.Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Введіть додатне число (наприклад, 41.5).");
        }
    }
}
