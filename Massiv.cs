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
                { 2, 3, 5, 2 } };
            int summ = 0;
            int productColumn=1;
            int line = 2;
            int column = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i,j]);
                }
                Console.WriteLine();
            }

            for (int i = 1; i < line; i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    summ += array[i, j];
                }
            }
          
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j == column; j++)
                {
                    productColumn *= array[i, j];
                }
            }
            Console.WriteLine($"Сумма второй строки {summ}, произведение первого столбца {productColumn}");
        }
    }
}





