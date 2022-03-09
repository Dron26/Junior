using System;

namespace sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxValue = 98;
            int minValue = 7;
            
            for (int i = minValue; i<maxValue;)
            {
                i = i + minValue;
                Console.Write($" {i} ");
            }
        }
    }
}
