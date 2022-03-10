using System;

namespace converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "Admin";
            string inputUser;
            bool isWorker = true;
            int attemptCount = 3;

            while (isWorker && attemptCount >0)
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
                    attemptCount--;
                    Console.WriteLine($"  Введен неверный пароль!\n  Осталось {attemptCount} попыток ввода ");
                    Console.ReadLine();
                    Console.Clear();
                }
            }           
        }
    }
}

