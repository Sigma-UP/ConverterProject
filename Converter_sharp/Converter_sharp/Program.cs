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
            bool isOk;

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
            bool isOk;

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
            int MenuSelector(List<string> menu)
            {
                int choise;

                for (int i = 0; i < menu.Count; i++) 
                    Console.WriteLine($"[{i}] {menu[i]}");
                choise = InputInt("Your choise: ", 0, menu.Count - 1);
                return choise;
            }

            //target currencies selection
            List<string> CurrenciesSelector(List<string> currencies)
            {
                List<string> selected = new List<string>();
                int choise;
                bool isOneItemSelected = false;

                while (true) 
                {
                    Console.WriteLine("Choose target currency:");
                    choise = MenuSelector(currencies);

                    if (!isOneItemSelected)
                    {
                        isOneItemSelected = true;
                        currencies.Insert(0, "Convert");
                        choise++;
                    }

                    if ((choise == 0 && isOneItemSelected) || currencies.Count == 2) 
                        break;

                    selected.Add(currencies[choise]);
                    currencies.Remove(currencies[choise]);

                    Console.Clear();
                }

                return selected;
            }



            void main()
            {
                Console.WriteLine("Choose source currency:");
                List<string> currencies = new List<string>() { "USD", "EUR", "UAH", "PLN", "BYR", "CNY", "RUB" };
                int srcCurr = MenuSelector(currencies);
                Console.Clear();

                List<string> selCurrencies;
                {
                    List<string> param = new List<string>(currencies); //copy currency list
                    param.Remove(currencies[srcCurr]); //delete source currency from new list
                    selCurrencies = CurrenciesSelector(param);
                }

                Console.Clear();
                float convValue = InputFloat("Enter convert value: ", 1);

                //enter currency rate
                Console.WriteLine();
                List<float> selCurrenciesRate = new List<float>();
                for (int i = 0; i < selCurrencies.Count; i++)
                    selCurrenciesRate.Add(InputFloat($"Enter {currencies[srcCurr]} cost in {selCurrencies[i]}: ", 0));

                //convert
                Console.Clear();
                for (int i = 0; i < selCurrencies.Count; i++)
                    Console.WriteLine($"{convValue} {currencies[srcCurr]} = {convValue * selCurrenciesRate[i]} {selCurrencies[i]}");
            }

            main();
            while (true)
            {
                Console.Write("\nConvert again? (y/n): ");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    main();
                }
                else
                    break;
            }
        }
    }
}