
    
using System;

namespace converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minNumber = 1;
            int maxNumber = 27;
            int maxValue = 999;
            int minValue = 99;
            Random random = new Random();
            int countNumber = 0;
            int number = random.Next(minNumber, maxNumber);
            int upNumber=number;
            bool isWorking = true;

            while (isWorking)
            {
                upNumber+=number;

                if (upNumber >= maxValue)
                {
                    isWorking = false;
                }

                else if ( upNumber>minValue )
                {
                    countNumber++;                    
                }
            }
            Console.WriteLine($"{countNumber} трехзначных чисел кратны {number}" ) ;            
        }
    }
}