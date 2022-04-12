using System;

namespace Shuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            Shuffle(chars);

        }

        static char[] Shuffle(char[] chars)
        {
            Random random = new Random();

            for (int i = 0; i < chars.Length; i++)
            {
                int number = random.Next(0, 9);
                char tempNumber = chars[i];
                chars[i] = chars[number];
                chars[number] = tempNumber;
            }

            return chars;
        }
    }
}
