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
            int firstNumber = 3;
            int secondNumber = 5;

            for (int i = 0; i < number; i++)
            {
                if (i % firstNumber == 0 | i % secondNumber == 0)
                {
                    summ = summ + i;
                }
            }
            Console.WriteLine(summ);
        }
    }
}
