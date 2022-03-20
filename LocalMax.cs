using System;

namespace Massivi_zadanij
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxElements = 30;
            int[] localArray = new int[maxElements];
            int localMax = 0;
            int LocalRange = 1;
            int[] localM = new int[localArray.Length];

            for (int i = 0; i < localArray.Length; i++)
            {
                localArray[i] = random.Next(0, 9);
                Console.Write(localArray[i] + " ");
            }
            Console.WriteLine("\n список локальных максимумов:");

            for (int i = 0; i < localArray.Length; i++)
            {

                if (i == 0)
                {
                    if (localArray[i] > localArray[i + LocalRange])
                    {
                        localMax = localArray[i];
                        Console.Write(localMax);
                    }
                }
                else if (i > 0 && i < localArray.Length - 1)
                {
                    if (localArray[i - LocalRange] <= localArray[i] && localArray[i] >= localArray[i + LocalRange])
                    {
                        localMax = localArray[i];
                        Console.Write($" {localMax} ");
                    }
                }
                else
                {
                    if (localArray[i - LocalRange] <= localArray[i])
                    {
                        localMax = localArray[i];
                        Console.Write(localMax);
                    }
                }
            }
        }
    }
}
