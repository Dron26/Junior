using System;

namespace LocalMax
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxElements = 30;
            int[] array = new int[maxElements];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 9);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\n список локальных максимумов:");

            if (array[0] > array[1])
            {
                Console.Write(array[0]);
            }

            for (int i = 1; i < array.GetUpperBound(0); i++)
            {
                
                    if (array[i - 1] <= array[i] && array[i] >= array[i + 1])
                    {
                        Console.Write($" {array[i]} ");
                    }
               
            }

            if (array[array.GetUpperBound(0)] > array[array.GetUpperBound(0) - 1])
            {
                Console.Write(array[array.GetUpperBound(0)]);
            }
        }
    }
