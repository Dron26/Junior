using System;

namespace Massiv
{
    class Programs
    {
        static void Main(string[] args)
        {
            int[,] array = {
                { 2, 1, 2, 3 },
                { 2, 1, 5, 7 },
                { 2, 3, 5, 2 },
                { 1, 7, 3, 5 }};
            int sumLine = 0;
            int productColumn = 1;
            int line = 2;
            int column = 1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {                
                sumLine += array[line, i];                
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                productColumn *= array[i, column];
            }
            Console.WriteLine($"Сумма второй строки {sumLine}, произведение первого столбца {productColumn}");
        }
    }
}
}
