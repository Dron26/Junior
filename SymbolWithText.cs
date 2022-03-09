using System;


namespace СимволыВокругТекста
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, symbol;
            int nameLenght;

            Console.WriteLine("Введите имя");
            name = Console.ReadLine();
            nameLenght = name.Length;
            Console.WriteLine("Введите символ");
            symbol = Console.ReadLine();
            Console.Clear();

            for
                (int i = 0; i <= nameLenght + 1; i++)
            {
                Console.Write(symbol);
            }
            Console.WriteLine("");
            Console.Write(symbol + name + symbol);
            Console.WriteLine("");

            for
                (int i = 0; i <= nameLenght + 1; i++)
            {
                Console.Write(symbol);
            }
            Console.ReadLine();
        }
    }
}