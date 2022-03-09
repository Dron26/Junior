using System;

namespace converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "Admin";
            string inputUser;
            bool isWorker =true;
            int inputCount=0;

            while (isWorker&&inputCount<3)
            {
                Console.WriteLine("Введите пароль для доступа к почте: ");
                inputUser = Console.ReadLine();
                if (inputUser == password)
                {
                    Console.WriteLine("  Пароль верен\n  Секректное сообщение: Нычка в системнике, проверь");
                    Console.ReadLine();
                    isWorker = false;
                }

                else if (inputUser != password)
                {
                    Console.WriteLine($"  Введен неверный пароль!\n  Осталось {2-inputCount} попыток ввода ");
                    inputCount++;
                    Console.ReadLine();
                    Console.Clear();
                }
            }           
        }
    }
}

