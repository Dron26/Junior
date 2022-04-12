using System;
using System.Collections.Generic;

namespace Динамический_массив
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            List<int> countNumber = new List<int>();
            bool isWorking = true;
            bool isNumber=false;

            while (isWorking)
            {
                Console.WriteLine("\n  sum - сумма введеных чисел \n  exit - выход из программы \n\n  Введите число:  \n");
                userInput = Console.ReadLine();
                isNumber = TryParse(userInput);

                if (userInput == "sum")
                {
                    SumNumber(countNumber);
                }
                else if (userInput == "exit")
                {
                    isWorking = false;
                }
                else if (isNumber==true)
                {
                    countNumber.Add(Convert.ToInt32(userInput));
                }
                else
                {
                    Console.WriteLine("  Вы ввели не число! \n  Повторите");
                    Console.ReadLine();
                }

                Console.Clear();
            }

        }

        static bool TryParse(string userInput)
        {
            bool result = int.TryParse(userInput, out int number);

            if (result == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        static void SumNumber(List<int> countNumber)
        {
            int sum = 0;

            for (int i = 0; i < countNumber.Count; i++)
            {
                sum += countNumber[i];
            }

            Console.WriteLine($"Сумма всех чисел: {sum} \n");
            Console.ReadLine();
        }

    }

}
