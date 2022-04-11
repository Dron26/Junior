using System;

namespace TryPars
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("\n  Введите число для преобразования:   ");
                userInput = Console.ReadLine();

                isWorking = TryParse(userInput);
            }
        }

        static bool TryParse(string userInput)
        {
            bool isWorking;
            bool result = int.TryParse(userInput.ToString(), out int number);
            if (result)
            {
                Console.WriteLine($"  Введено число:    {number} \n  Преобразование удалось");
                Console.ReadLine();
                return isWorking = false;
            }
            else
            {
                Console.WriteLine("  Вы ввели не число! \n  Повторите");
                Console.ReadLine();
                return isWorking = true;
            }
        }
    }
}
