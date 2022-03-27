ing System;

namespace SortArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxElements = 10;
            int[] array = new int[maxElements];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10);
                Console.Write(array[i] + " ");
            }
            Console.Write("\n\n");

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int number = array[i];
                        array[i] = array[j];
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
