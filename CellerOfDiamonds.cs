using System;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gold;
            int diamondsCount;
            int priceDiamond = 45;
            
            Console.WriteLine("Вы собираетесь посетить магазин и преобрести кристалы");
            Console.WriteLine("Введите количество золота которое возьмете с собой:");
            gold = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Поздравляю! В ваш кошелек успешно добавлено {gold} золотых монет");
            Console.WriteLine("Теперь пора навестить магазин!");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Вы заходите в магазин и вас приветствует (П)родавец \n  " +
                $"(П):  Добрый день! В нашем магазине самые качественные кристалы, сколько вы хотели бы приобрести кристалов? \n    Предупрежу 1 аристал стоит:  {priceDiamond} золотых монет");
            Console.WriteLine("Введите количество кристалов к покупке: ");
            diamondsCount = Convert.ToInt32(Console.ReadLine());            
            gold -= priceDiamond * diamondsCount;
            Console.WriteLine($"Поздравляю! Вы успешно приобрели кристалы в количестве {diamondsCount}шт и у вас еще осталось {gold} золотых монет!");
        }
    }
}
