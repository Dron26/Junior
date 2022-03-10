using System;

namespace TwoVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            int summ = 0;

            for (int i = 0; i < number; i++)
            {
                if (i % 3 == 0 | i % 5 == 0)
                {
                    summ = summ + i;
                }
            }
            Console.WriteLine(summ);
        }
    }
}