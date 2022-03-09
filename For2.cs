using System;

namespace sequence
{
    internal class Program
    {
        //выбрал цикл for так как есть условия по счетчику, просто и удобно.
        static void Main(string[] args)
        {
            int maxValue = 98;
            int j = 0;
            for (int i = 0;j<maxValue; i++)
            {               
                j =j+ 7;
                Console.Write($" {j} ");
            }            
        }
    }
}
