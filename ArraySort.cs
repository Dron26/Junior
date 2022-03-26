using System;

namespace SortArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxElements = 10;
            int[] array = new int[maxElements];
            int countNumberInternalCycles = 0;
            int countNumberExternalCycles = 0;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10);
                Console.Write(array[i] + " ");
            }
            Console.Write("\n\n");

            while (countNumberExternalCycles + 1 < array.Length)
            {
                for (int i = countNumberExternalCycles + 1; i < array.Length; i++)
                {
                    int numberSearchable = array[countNumberInternalCycles];
                    int number = array[i];

                    if (numberSearchable > number)
                    {
                        array[countNumberExternalCycles] = number;
                        array[i] = numberSearchable;
                    }
                }
                countNumberExternalCycles++;
                countNumberInternalCycles = countNumberExternalCycles;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
