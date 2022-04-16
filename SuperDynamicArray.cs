using System;
using System.Collections.Generic;

namespace SuperDynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            List<int> numbers = new List<int>();
            bool isWorking = true;
            bool isNumber = false;

            while (isWorking)
            {
                Console.WriteLine("\n  sum - сумма введеных чисел \n  exit - выход из программы \n\n  Введите число:  \n");
                userInput = Console.ReadLine();
                isNumber = int.TryParse(userInput, out int number);

                if (userInput == "sum")
                {
                    ShowSum(numbers);
                }
                else if (userInput == "exit")
                {
                    isWorking = false;
                }
                else if (isNumber == true)
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine("  Вы ввели не число! \n  Повторите");
                    Console.ReadLine();
                }

                Console.Clear();
            }

        }

        static void ShowSum(List<int> countNumber)
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
