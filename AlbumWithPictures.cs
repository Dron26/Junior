using System;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityPictures = 52;
            int quantityColumns = 3;
            int numbersColumns = quantityPictures / quantityColumns;
            int overColumnsQuantity = quantityPictures - (numbersColumns * quantityColumns);
            Console.WriteLine($"Количество: \n  картинок в альбоме - {quantityPictures} \n  рядов картинок - {quantityColumns} \n  " +
                $"целых рядов - {numbersColumns} \n  картинок сверх альбома - {overColumnsQuantity}");
        }
    }
}
