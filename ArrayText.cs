using System;

namespace ArrayText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Дана строка с текстом, используя метод строки String.Split() получить массив слов, которые разделены пробелом в тексте и вывести массив, каждое слово с новой строки.";
            string [] emptySpace = text.Split(" ");

            foreach (var empety in emptySpace)
            {
                Console.WriteLine(empety);
            }            
        }
    }
}
