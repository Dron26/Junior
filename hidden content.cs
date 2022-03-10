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
            int maxIncorrectInput =3;
            int attemptCount=2;

            while (isWorker&&inputCount<maxIncorrectInput)
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
                    Console.WriteLine($"  Введен неверный пароль!\n  Осталось {attemptCount-inputCount} попыток ввода ");
                    inputCount++;
                    Console.ReadLine();
                    Console.Clear();
                }
            }           
        }
    }
}

