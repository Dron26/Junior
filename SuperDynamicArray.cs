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
            int sum;

            while (isWorking)
            {
                Console.WriteLine("\n  sum - сумма введеных чисел \n  exit - выход из программы \n\n  Введите число:  \n");                   
                userInput = Console.ReadLine();

                if (userInput=="sum"| userInput == "exit")
                {
                    if (userInput == "sum")
                    {
                        sum = SumNumber(countNumber);
                       
                    }
                    else 
                    {
                        isWorking = false;
                    }
                }
                else if (TryParse(userInput))
                {
                    countNumber.Add(Convert.ToInt32(userInput));
                }

                Console.Clear();  
            }

        }

        static bool TryParse(string userInput)
        {
            bool result = int.TryParse(userInput.ToString(), out int number);

            if (result == false)
            {
                Console.WriteLine("  Вы ввели не число! \n  Повторите");
                Console.ReadLine();
                return false;
            }
            else
            {
                return true;
            }

        }

        static int SumNumber(List<int> countNumber)
        {
            int sum = 0;

            for (int i = 0; i < countNumber.Count; i++)
            {
                sum += countNumber[i];
            }

            Console.WriteLine($"Сумма всех чисел: {sum} \n");
            Console.ReadLine();
            return sum;
        }

    }

}
