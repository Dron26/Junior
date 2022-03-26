using System;

namespace ArrayText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Дана строка с текстом, используя метод строки String.Split() получить массив слов, которые разделены пробелом в тексте и вывести массив, каждое слово с новой строки.";
            string [] content = text.Split(" ");

            foreach (var part in content)
            {
                Console.WriteLine(part);
            }            
        }
    }
}
