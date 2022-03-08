using System;

namespace converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            float USD=rnd.Next(50,100);
            float RUB = rnd.Next(5000, 10000);
            float EUR = rnd.Next(50, 100);
            bool isWorking = true;
            int positionX;
            int positionY;
            int firstSelection;
            int secondSelection;
            int number;
            string checkInPut;
            float coursSellUSD = 105.81f;
            float coursEurToUsd = 0.9152f;
            float coursUsdToEur = 1.0927f;
            float coursSellEUR = 116.53f;

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

                if (checkInPut=="E"| checkInPut == "exite"| checkInPut == "Exite")
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
                        USD += (1 / coursSellUSD) * number;
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

                        EUR += (1 / coursSellEUR) * number;
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
                        RUB += (coursSellUSD / 1) * number;
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
                        RUB += coursSellEUR * number;
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
                        USD += (coursEurToUsd / 1) * number;
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
