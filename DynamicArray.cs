using System;

namespace Динамический_массив
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int indexUpArray = 1;
            int[] arrayTest = new int[0];
            int arraySum = 0;
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("\n sum - сумма введеных чисел \n exit - выход из программы" +
                    "\n  или\n" +
                    "Введите число:  \n");
                userInput = Console.ReadLine();

                if (userInput == "sum")
                {
                    for (int i = 0; i < arrayTest.Length; i++)
                    {
                        arraySum += arrayTest[i];
                    }
                    Console.WriteLine("Сумма всех чисел:  " + arraySum + "\n");
                    Console.ReadLine();
                    arraySum = 0;
                }
                else if (userInput == "exit")
                {
                    isWorking = false;
                }
                else
                {
                    int[] tempArrow = new int[arrayTest.Length + indexUpArray];

                    for (int i = 0; i < arrayTest.Length; i++)
                    {
                        tempArrow[i] = arrayTest[i];
                    }
                    tempArrow[tempArrow.Length - indexUpArray] = Convert.ToInt32(userInput);
                    arrayTest = tempArrow;
                }
                Console.Clear();
            }
        }
    }
}

