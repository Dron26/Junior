using System;

namespace arrayShift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxElements = 10;
            int[] array = new int[maxElements];
            int userInput;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10);
                Console.Write(array[i] + " ");
            }
            Console.Write("\n\n");
            Console.WriteLine("Введите значение сдвига");
            userInput = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n\n");

            for (int i = 0; i < userInput; i++)
            {
                int number = array[0];
                for (int j = 0; j < array.GetLength(0); j++)
                {                 
                    if (j != array.GetLength(0)-1)
                    {
                        array[j] = array[j + 1];
                    }
                    else
                    {
                        array[j] = number;
                    }                   
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}

