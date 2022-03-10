using System;

namespace TwoVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name= "Chetnikov";
            string surname= "Andrey";

            Console.WriteLine($"{name}  {surname}");
            (name, surname) = (surname, name);
            Console.WriteLine($"{name}  {surname}");
        }
    }
}
