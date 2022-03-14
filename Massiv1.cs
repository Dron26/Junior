using System;

namespace Massiv
{
    class Programs
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int setValue = 0;
            int maxValue = 0;
            int maxX = 10;
            int maxY = 10;
            int[,] arrayA = new int [10,10];
            Console.WriteLine("\n\n  Созданный массив\n\n");

            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    arrayA[i, j] = random.Next(0,1000);
                    Console.Write($"{ arrayA[i, j]}   ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    setValue = arrayA[i, j];
                    if (maxValue < setValue)
                    {
                        maxValue = setValue;
                    }
                }
            }
            Console.WriteLine($"\n\nНаибольшее значение в массиве {maxValue}\n\n");
            Console.WriteLine("\n\n  Измененный массив\n\n");

            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    if (maxValue== arrayA[i, j])
                    {
                        arrayA[i, j] = 0;
                    }
                    Console.Write($"{ arrayA[i, j]}   ");
                }
                Console.WriteLine();
            }
        }
    }
}





