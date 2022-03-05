using System;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfGrandmoms;
            int hour = 60;
            int timeOfReception = 10;
            int waitingHours;
            int waitingMinutes;
            Console.WriteLine("Вы заходите в поликлинику и видите огромную очередь из старушек, укажите сколько их:  ");
            countOfGrandmoms = Convert.ToInt32(Console.ReadLine());
            waitingHours = (countOfGrandmoms * timeOfReception) / hour;
            waitingMinutes = (countOfGrandmoms * timeOfReception) - (waitingHours * hour);
            Console.WriteLine($"Вы должны отстоять в очереди {waitingHours} часа и {waitingMinutes} минут");
        }
    }
}
