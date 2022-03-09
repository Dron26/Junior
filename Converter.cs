using System;

namespace converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            float USD= random.Next(50,100);
            float RUB = random.Next(5000, 10000);
            float EUR = random.Next(50, 100);
            bool isWorking = true;
            int positionX;
            int positionY;
            int firstSelection;
            int secondSelection;
            int number;
            string checkInPut;
            float coursRubToUSD = 0.0095f;
            float coursRubToEUR = 0.0086f;
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
                Console.WriteLine("Выберете валюту которую хотите обменять \n\n  1 - Рубли - RUB\n  2 - Доллары - USD\n  3 - Евро - EUR");
                checkInPut = Console.ReadLine();

                if (checkInPut=="E"| checkInPut == "exite"| checkInPut == "Exite"| checkInPut == "e")
                {
                    isWorking = false;
                    break;
                }
                firstSelection = Convert.ToInt32(checkInPut);               
                Console.WriteLine("Выберете валюту на какую хотите обменять \n\n  1 - Рубли - RUB\n  2 - Доллары - USD\n  3 - Евро - EUR");
                checkInPut = Console.ReadLine();

                if (checkInPut == "E" | checkInPut == "exite" | checkInPut == "Exite")
                {
                    isWorking = false;
                    break;
                }
                secondSelection = Convert.ToInt32(checkInPut);
                Console.WriteLine("Введите сумму для обмена: ");
                checkInPut = Console.ReadLine();

                if (checkInPut == "E" | checkInPut == "exite" | checkInPut == "Exite")
                {
                    isWorking = false;
                    break;
                }
                number = Convert.ToInt32(checkInPut);

                if (firstSelection == 1 && secondSelection == 2)
                {
                    if (number <= RUB)
                    {
                        RUB -= number;
                        USD += coursRubToUSD * number;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("У вас не достаточно средств");
                        Console.ReadLine();
                    }                       
                }

                if (firstSelection == 1 && secondSelection == 3)
                {
                    if (number <= RUB)
                    {
                        RUB -= number;

                        EUR += coursRubToEUR * number;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("У вас не достаточно средств");
                        Console.ReadLine();
                    }
                }

                if (firstSelection == 2 && secondSelection == 1)
                {
                    if (number <= USD)
                    {
                        USD -= number;
                        RUB += coursUsdToRub * number;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("У вас не достаточно средств");
                        Console.ReadLine();
                    }
                }

                if (firstSelection == 2 && secondSelection == 3)
                {
                    if (number <= USD)
                    {
                        USD -= number;
                        EUR += coursUsdToEur * number;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("У вас не достаточно средств");
                        Console.ReadLine();
                    }
                }

                if (firstSelection == 3 && secondSelection == 1)
                {
                    if (number <= EUR)
                    {
                        EUR -= number;
                        RUB += coursEurToRub * number;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("У вас не достаточно средств");
                        Console.ReadLine();
                    }

                }

                if (firstSelection == 3 && secondSelection == 2)
                {
                    if (number <= EUR)
                    {
                        EUR -= number;
                        USD += coursEurToUsd * number;
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
