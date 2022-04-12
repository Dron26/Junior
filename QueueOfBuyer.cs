using System;
using System.Collections.Generic;

namespace QueueOfBuyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int cashSum=0;
            Queue<int> clientsCash;
            clientsCash = FillQueueClients();

            while (clientsCash.Count > 0)
            {
                MakePurchase(clientsCash, ref cashSum);
            }

            Console.WriteLine("Все клиенты ушли с покупками!");
            Console.ReadKey();
        }

        static Queue<int> FillQueueClients()
        {
            Random random = new Random();
            int minAmountMoney = 200;
            int maxAmountMoney = 5000;
            int minLength = 20;
            int maxLength = 40;
            int randomLength = random.Next(minLength, maxLength);
            Queue<int> tempClientsCash = new Queue<int>(randomLength);

            for (int i = 0; i < randomLength; i++)
            {
                tempClientsCash.Enqueue(random.Next(minAmountMoney, maxAmountMoney));
            }

            return tempClientsCash;
        }

        static void MakePurchase(Queue<int> clientsCash, ref int cashSum)
        {
            Console.Clear();
            Console.WriteLine($"  Всего в очереди : {clientsCash.Count}  клиент(ов)");
            Console.WriteLine($"\n  Сумма в кассе:  {cashSum}");
            Console.WriteLine($"\n  Нажмите любую клавишу чтобы совершить покупку на сумму: {clientsCash.Peek()}");
            Console.ReadKey();
            cashSum += clientsCash.Dequeue();
            Console.Clear();
        }

    }

}