using System;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityMyGold;
            int quantityMyDiamonds;
            int priceDiamond = 45;
            int quantityBoughtDiamonds;
            Console.WriteLine("Вы собираетесь посетить магазин и преобрести кристалы");
            Console.WriteLine("Введите количество золота которое возьмете с собой:");
            quantityMyGold = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Поздравляю! В ваш кошелек успешно добавлено {quantityMyGold} золотых монет");
            Console.WriteLine("Теперь пора навестить магазин!");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Вы заходите в магазин и вас приветствует (П)родавец \n  " +
                $"(П):  Добрый день! В нашем магазине самые качественные кристалы, сколько вы хотели бы приобрести кристалов? \n    Предупрежу 1 аристал стоит:  {priceDiamond} золотых монет");
            Console.WriteLine("Введите количество кристалов к покупке: ");
            quantityBoughtDiamonds = Convert.ToInt32(Console.ReadLine());
            quantityMyDiamonds = quantityMyGold - (priceDiamond * quantityBoughtDiamonds);
            quantityMyGold -= priceDiamond * quantityBoughtDiamonds;
            Console.WriteLine($"Поздравляю! Вы успешно приобрели {quantityBoughtDiamonds} и у вас еще осталось {quantityMyGold} золотых монет!");
        }
    }
}
