using System;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pictures = 52;
            int maxRows = 3;
            int totalRows = pictures / maxRows;
            int overPictures = pictures - (totalRows * maxRows);
            Console.WriteLine($"Количество: \n  картинок в альбоме - {pictures} \n  рядов картинок - {maxRows} \n  " +
                $"целых рядов - {totalRows} \n  картинок сверх альбома - {overPictures}");
        }
    }
}
