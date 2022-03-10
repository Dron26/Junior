using System;

namespace TwoVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Chetnikov";
            string surname = "Andrey";
            string temporaryVariabl = null;
            Console.WriteLine($"{name}  {surname}");
            temporaryVariabl = name;
            name = surname;
            surname = temporaryVariabl;
            Console.WriteLine($"{name}  {surname}");
        }
    }
}
