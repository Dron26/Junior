using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int count;
       Console.WriteLine("Введите количество повторений: ");
          count= Convert.ToInt32(Console.ReadLine());
          for (int i=0;i<count;i++)
          {
              Console.WriteLine($"Повтор № {i+1}");
          }                            
        }
    }
}