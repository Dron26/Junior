using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
          float number;
          float summ=0;
          string selectInMenu=null;
          int count=0;
          
          Console.WriteLine("Помогите провести эксперемент, необходимо   складывать числа, пока мы не достигнем математического предела ");
            
          while(selectInMenu!="exite")
          {         
            Console.WriteLine("Введите число для сложения: ");
            selectInMenu=Console.ReadLine();                    number=Convert.ToInt32(selectInMenu);
            summ+=number;
            Console.WriteLine($"Сумма :{summ}");
          }                                  
        }
    }
}
