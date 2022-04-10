using System;

namespace TryPars
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int number;
            bool isWorking=true;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("\n  Введите число для преобразования:   ");
                userInput = Console.ReadLine();
                bool result = int.TryParse(userInput.ToString(), out number);
                if (result)
                {
                    Console.WriteLine($"  Введено число\n   {number} \n  Преобразование удалось");
                    isWorking = false;  
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("  Вы ввели не число! \n  Повторите");
                    Console.ReadLine(); 
                }
            }
        }
    }
}
