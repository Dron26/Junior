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
          bool isWorking=true;
          
          Console.WriteLine("Помогите провести эксперемент, необходимо   складывать числа, пока мы не достигнем математического предела ");
          
          while(isOn)
          {         
            Console.WriteLine("Введите число для сложения: ");            
            selectInMenu=Console.ReadLine(); 
            
            if(selectInMenu !="exite")
            {
              number=Convert.ToInt32(selectInMenu);
              summ+=number;
              Console.WriteLine($"Сумма :{summ}");
            }
            
            else
            {
              isWorking=false;                
            }
          } 
          Console.WriteLine("Закрытие программы");
        }
    }
}
