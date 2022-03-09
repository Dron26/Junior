using System;

namespace converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            float USD = random.Next(50, 100);
            float RUB = random.Next(5000, 10000);
            float EUR = random.Next(50, 100);
            bool isWorking = true;
            int positionX;
            int positionY;
            int summconvert = 0;
            string inputUser;
            float coursRubToUsd = 0.0095f;
            float coursRubToEur = 0.0086f;
            float coursEurToUsd = 1.0927f;
            float coursEurToRub = 115.6212f;
            float coursUsdToEur = 0.9152f;
            float coursUsdToRub = 105.8124f;

            Console.WriteLine("  Доброго времени суток!\n  Вас приветствует конвертор валют.Здесь вы можете обменять:\n\n  Рубли - RUB\n  Доллары - USD\n  Евро - EUR");
            Console.ReadLine();

            while (isWorking)
            {
                Console.Clear();
                positionX = Console.CursorLeft;
                positionY = Console.CursorTop;
                Console.SetCursorPosition(2, 20);
                Console.WriteLine($"Ваш баланс: \nRUB - {RUB}\nUSD - {USD}\nEUR - {EUR}");
                Console.SetCursorPosition(2, 27);
                Console.WriteLine("Для выхода нажмите (E)xite");
                Console.SetCursorPosition(positionX, positionY);
                Console.WriteLine("Выберете подходящую операцию по обмену \n\n" +
                    "  1 - RUB->USD\n  2 - RUB->EUR\n" +
                    "  3 - USD->RUB\n  4 - USD->EUR\n" +
                    "  5 - EUR->RUB\n  6 - EUR->USD\n");                
                inputUser = Console.ReadLine();

                if (inputUser == "e" | inputUser == "E" | inputUser == "exite" | inputUser == "Exite")
                {
                    Console.WriteLine("Программа завершена");
                    isWorking = false;
                }

                else if (isWorking)
                {
                    Console.WriteLine("Введите сумму для обмена: ");
                    summconvert = Convert.ToInt32(Console.ReadLine());

                    if (inputUser == "1" && summconvert <= RUB && isWorking == true)
                    {
                        RUB -= summconvert;
                        USD += coursRubToUsd * summconvert;
                    }

                    else if (inputUser == "2" && summconvert <= RUB && isWorking == true)
                    {
                        RUB -= summconvert;
                        EUR += coursRubToEur * summconvert;
                    }

                    else if (inputUser == "3" && summconvert <= USD && isWorking == true)
                    {
                        USD -= summconvert;
                        RUB += coursUsdToRub * summconvert;
                    }

                    else if (inputUser == "4" && summconvert <= USD && isWorking == true)
                    {
                        USD -= summconvert;
                        EUR += coursUsdToEur * summconvert;
                    }

                    else if (inputUser == "5" && summconvert <= EUR && isWorking == true)
                    {
                        EUR -= summconvert;
                        RUB += coursEurToRub * summconvert;
                    }

                    else if (inputUser == "6" && summconvert <= EUR && isWorking == true)
                    {
                        EUR -= summconvert;
                        USD += coursEurToUsd * summconvert;
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("У вас не достаточно средств");
                        Console.ReadLine();
                    }
                }                                
            }
        }
    }
}
