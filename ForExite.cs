using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
          float count;
          float count2=0;
          string selectInMenu;
          
          Console.WriteLine("Помогите провести эксперемент, необходимо   складывать числа, пока мы не достигнем математического предела ");
          while(true)
          {            
            Console.WriteLine("Введите число для сложения: ");
            selectInMenu=Console.ReadLine();
            
            if(selectInMenu=="exite")  
          {
            break;
          } 
            count=Convert.ToInt32(selectInMenu);
            count2+=count;            
            Console.WriteLine($"Сумма :{count2}");
          }                                  
        }
    }
}