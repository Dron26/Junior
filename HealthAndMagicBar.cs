using System;

namespace HealthBar
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int lengthStatusBar = 100;
            int maxValue = 100;
            int health = random.Next(0, maxValue);
            int mana = random.Next(0, maxValue);
            int userInput;

            while (health > 0 & mana > 0)
            {
                DrawBar(lengthStatusBar, health, maxValue, ConsoleColor.Red, 0, '_');
                DrawBar(lengthStatusBar, mana, maxValue, ConsoleColor.Blue, 1, '_');

                Console.SetCursorPosition(0, 5);
                Console.Write("Введите число, на которое изменится жизни: ");
                userInput = Convert.ToInt32(Console.ReadLine());
                userInput = CheckUserInput(userInput, maxValue, health);
                health += userInput;
                Console.Write("Введите число, на которое изменится мана: ");
                userInput = Convert.ToInt32(Console.ReadLine());
                userInput = CheckUserInput(userInput, maxValue, mana);
                mana += userInput;
                Console.Clear();
            }
        }

        static void DrawBar(int lengthStatusBar, int value, int maxValue, ConsoleColor color, int position, char symbol)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string statusBar = "";
            int percentageRatio = value * lengthStatusBar / maxValue;

            for (int i = 0; i < percentageRatio; i++)
            {
                statusBar += ' ';
            }
            Console.SetCursorPosition(0, position);
            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(statusBar);
            Console.BackgroundColor = defaultColor;
            statusBar = "";

            for (int i = percentageRatio; i < lengthStatusBar; i++)
            {
                statusBar += symbol;
            }
            Console.Write(statusBar + ']');
        }

        static int CheckUserInput(int userInput, int maxValue, int value)
        {
            if (0 <= userInput + value & userInput + value <= maxValue)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Введены некорректные данные ");
                userInput = 0;
                return userInput;
                
            }
        }
    }
}
