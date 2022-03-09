using System;


namespace СимволыВокругТекста
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, symbol;
            int nameLenght;
            string lineSymbols=null;

            Console.WriteLine("Введите имя");
            name = Console.ReadLine();
            nameLenght = name.Length;
            Console.WriteLine("Введите символ");
            symbol = Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < nameLenght+2; i++)
            {
                lineSymbols += symbol;
            }
            Console.Write(lineSymbols+"\n"+symbol+name+symbol+"\n"+lineSymbols);         
        }
    }
}
