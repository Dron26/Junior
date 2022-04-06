using System;

namespace HealthBar
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxValue = 100;
            int health = random.Next(0, maxValue); 
            int mana = random.Next(0, maxValue);
            int userInput;
            while (health>0  & mana>0)
            {
                DrawBar(health, maxValue, ConsoleColor.Red, 0, '_');
                DrawBar(mana, maxValue, ConsoleColor.Blue, 1, '_');

                Console.SetCursorPosition(0, 5);
                Console.Write("Введите число, на которое изменится жизни: ");
                userInput = Convert.ToInt32(Console.ReadLine());
                CheckError(userInput, maxValue,ref health);
                Console.Write("Введите число, на которое изменится мана: ");
                userInput = Convert.ToInt32(Console.ReadLine());
                CheckError(userInput, maxValue, ref mana);
                Console.Clear();
            }
        }

        static void DrawBar(int value, int maxValue,ConsoleColor color, int position, char symbol)
        {
            if (0<=value & value<=maxValue)
            {
                ConsoleColor defaultColor = Console.BackgroundColor;
                string statusBar = "";

                for (int i = 0; i < value; i++)
                {
                    statusBar += ' ';

                }
                Console.SetCursorPosition(0, position);
                Console.Write('[');
                Console.BackgroundColor = color;
                Console.Write(statusBar);
                Console.BackgroundColor = defaultColor;
                statusBar = "";

                for (int i = value; i < maxValue; i++)
                {
                    statusBar += symbol;

                }
                Console.Write(statusBar + ']');
            }

            else 
            Console.Write("Введены некорректные данные ");
        }
        static void CheckError(int userInput,int maxValue,ref int value)
        {
            if (0 <= userInput & userInput <= maxValue)
            {
                value = userInput;
            }
            else
            {
                Console.WriteLine("Введены некорректные данные ");
            }
        }
    }
}
