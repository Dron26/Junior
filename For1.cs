using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int repeat;
          string text;
          Console.WriteLine("Введите количество повторений: ");
          repeat= Convert.ToInt32(Console.ReadLine());
          Console.WriteLine("Введите текст повторения: ");
          text=Console.ReadLine();
          for (int i=0;i<repeat;i++)
          {
              Console.WriteLine(text);
          }                            
        }
    }
}
