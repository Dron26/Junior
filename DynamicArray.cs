using System;

namespace Динамический_массив
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int[] array = new int[0];
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("\n sum - сумма введеных чисел \n exit - выход из программы" +
                    "\n  или\n" +
                    "Введите число:  \n");
                userInput = Console.ReadLine();

                if (userInput == "sum")
                {
                    int arraySum = 0;

                    for (int i = 0; i < array.Length; i++)
                    {
                        arraySum += array[i];
                    }
                    Console.WriteLine("Сумма всех чисел:  " + arraySum + "\n");
                    Console.ReadLine();
                }
                else if (userInput == "exit")
                {
                    isWorking = false;
                }
                else
                {
                    int[] tempArrow = new int[array.Length + 1];

                    for (int i = 0; i < array.Length; i++)
                    {
                        tempArrow[i] = array[i];
                    }
                    tempArrow[tempArrow.Length - 1] = Convert.ToInt32(userInput);
                    array = tempArrow;
                }
                Console.Clear();
            }
        }
    }
}
