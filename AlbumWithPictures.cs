using System;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pictures = 55;
            int picturesInRow = 3;
            int totalRows = pictures / picturesInRow;
            int overPictures = pictures % picturesInRow;
            Console.WriteLine($"Количество: \n  картинок в альбоме - {pictures} \n  картинок в ряду - {picturesInRow} \n  " +
            $"целых рядов - {totalRows} \n  картинок сверх альбома - {overPictures}");
        }
    }
}
