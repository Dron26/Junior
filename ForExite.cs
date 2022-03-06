using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
          float number;
          float summ=0;
          string selectInMenu;
          int count=0;
          
          Console.WriteLine("Помогите провести эксперемент, необходимо   складывать числа, пока мы не достигнем математического предела ");
          while(count<20)
          {         
            Console.WriteLine("Введите число для сложения: ");
            selectInMenu=Console.ReadLine();                    if(selectInMenu=="exite")  
          {
            break;
          } 
            number=Convert.ToInt32(selectInMenu);
            summ+=number;
            Console.WriteLine($"Сумма :{summ}");
            count++;
          }                                  
        }
    }
}
