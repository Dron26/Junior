

using System;

namespace converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Number = 2;
            int maxNumber = 27;
            int degree = 0;
            Random random = new Random();
            int number = random.Next(Number, maxNumber);
            int upDegree = 1;
            bool isWorking = true;

            while (isWorking)
            {               
                if (upDegree > number)
                {
                    isWorking = false;
                }

                else if (upDegree < number)
                {
                    upDegree = upDegree * Number;
                    degree++;
                }
            }
            Console.WriteLine($"{upDegree} - это результат возведения числа {Number}  в степень {degree}");
        }
    }
}