using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
          int count;
          string text;
          Console.WriteLine("Введите количество повторений: ");
          count= Convert.ToInt32(Console.ReadLine());
          Console.WriteLine("Введите текст повторения: ");
          text=Console.ReadLine();
          for (int i=0;i<count;i++)
          {
              Console.WriteLine(text);
          }                            
        }
    }
}
