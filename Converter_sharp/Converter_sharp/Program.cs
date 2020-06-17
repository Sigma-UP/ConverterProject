using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class Program
    {
        static int InputInt(string prompt = "", int min = int.MinValue, int max = int.MaxValue)
        {
            int output;
            string input;
            bool isOk = false;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                isOk = int.TryParse(input, out output);

                if (isOk && (output < min || output > max))
                {
                    Console.WriteLine($"number {output} not in range[{min}; {max}]");
                    isOk = false;
                    continue;
                }

                if (!isOk)
                    Console.WriteLine("Invalid input");

            } while (!isOk);

            return output;
        }

        static float InputFloat(string prompt = "", float min = float.MinValue, float max = float.MaxValue)
        {
            float output;
            string input;
            bool isOk = false;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                isOk = float.TryParse(input, out output);

                if (isOk && (output < min || output > max))
                {
                    Console.WriteLine($"number {output} not in range[{min}; {max}]");
                    isOk = false;
                    continue;
                }

                if (!isOk)
                    Console.WriteLine("Invalid input");

            } while (!isOk);

            return output;
        }



        static void Main(string[] args)
        {
            void main()
            {
                Console.WriteLine("Choose source currency");
                List<string> currencies = new List<string>() { "USD", "EUR", "UAH", "PLN", "BYR", "CNY", "RUB" };
                int srcCurr = MenuSelector(currencies);
                Console.Clear();
            }

            int MenuSelector(List<string> menu)
            {
                int choise;

                for (int i = 0; i < menu.Count; i++)
                    Console.WriteLine($"[{i}] {menu[i]}");
                choise = InputInt("Your choise: ", 0, menu.Count - 1);
                return choise;
            }

            main();
        }
    }
}