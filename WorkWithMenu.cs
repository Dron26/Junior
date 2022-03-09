using System;

namespace WorkWithMenu
{
    //Пардон без методов такая борода)))
    internal class Program
    {
        static void Main(string[] args)
        {
            int positionX;
            int positionY;
            string password = "1";
            string userInput;
            string nikName = null;
            bool isPasswordCorrect = true;
            bool isWorkingMenu = true;
            string name = null;
            int countInput = 0;

            while (isPasswordCorrect)
            {
                Console.SetCursorPosition(3, 1);
                Console.WriteLine("Вход в программу\n   Введите пароль: \n\n");
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("-");
                }
                positionX = Console.CursorLeft;
                Console.WriteLine("");
                positionY = Console.CursorTop;
                Console.SetCursorPosition(0, 21);

                for (int i = 0; i < 100; i++)
                {
                    Console.Write("-");
                }
                Console.SetCursorPosition(positionX - 1, positionY + 1);

                for (int i = 0; i < 21; i++)
                {
                    Console.WriteLine("|");
                    Console.SetCursorPosition(positionX - 1, positionY + i);
                }
                Console.SetCursorPosition(3, 4);
                userInput = Console.ReadLine();

                if (userInput != password)
                {
                    Console.WriteLine("Пароль не верен.Повторите ввод.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    isPasswordCorrect = false;
                }
            }

            while (isWorkingMenu)
            {
                Console.Clear();
                for (int i = 0; i < 100; i++)
                {
                    Console.Write("-");
                }
                positionX = Console.CursorLeft;
                Console.WriteLine("");
                positionY = Console.CursorTop;
                Console.SetCursorPosition(0, 21);

                for (int i = 0; i < 100; i++)
                {
                    Console.Write("-");
                }
                Console.SetCursorPosition(positionX - 1, positionY + 1);

                for (int i = 0; i < 21; i++)
                {
                    Console.WriteLine("|");
                    Console.SetCursorPosition(positionX - 1, positionY + i);

                }
                Console.SetCursorPosition(3, 1);
                Console.WriteLine(" Основное меню  \n\n  1 - SetName\n\n  2 - SetNikName\n\n  3 - ChangeConsoleColor\n\n  4 - WriteName\n\n  5 - WriteNikName\n\n  6 - SetPassword");
                userInput = Console.ReadLine();


                if (userInput == "E" | userInput == "exite" | userInput == "Exite")
                {
                    isWorkingMenu = false;
                    break;
                }

                if (userInput == "1" | userInput == "SetName")
                {
                    Console.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    positionX = Console.CursorLeft;
                    Console.WriteLine("");
                    positionY = Console.CursorTop;
                    Console.SetCursorPosition(0, 21);

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(positionX - 1, positionY + 1);

                    for (int i = 0; i < 21; i++)
                    {
                        Console.WriteLine("|");
                        Console.SetCursorPosition(positionX - 1, positionY + i);
                    }
                    Console.SetCursorPosition(3, 1);
                    Console.WriteLine("Введите имя:");
                    name = Console.ReadLine();
                    Console.WriteLine("Имя сохранено");
                }

                if (userInput == "2" | userInput == "SetNikName")
                {
                    Console.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    positionX = Console.CursorLeft;
                    Console.WriteLine("");
                    positionY = Console.CursorTop;
                    Console.SetCursorPosition(0, 21);

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(positionX - 1, positionY + 1);

                    for (int i = 0; i < 21; i++)
                    {
                        Console.WriteLine("|");
                        Console.SetCursorPosition(positionX - 1, positionY + i);
                    }
                    Console.SetCursorPosition(3, 1);
                    Console.WriteLine("Введите Никнейм:");
                    nikName = Console.ReadLine();
                    Console.WriteLine("Никнейм сохранен");
                }

                if (userInput == "3" | userInput == "ChangeConsoleColor")
                {
                    Console.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    positionX = Console.CursorLeft;
                    Console.WriteLine("");
                    positionY = Console.CursorTop;
                    Console.SetCursorPosition(0, 21);

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(positionX - 1, positionY + 1);

                    for (int i = 0; i < 21; i++)
                    {
                        Console.WriteLine("|");
                        Console.SetCursorPosition(positionX - 1, positionY + i);

                    }
                    Console.SetCursorPosition(3, 1);
                    Console.WriteLine("Выберете цвет шрифта: \n  1 - Red \n  2 - Green\n  3 - Yellow\n  4 - White");
                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case "2":
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case "3":

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case "4":
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("Цвет изменен.");
                }

                if (userInput == "4" | userInput == "WriteName")
                {
                    Console.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    positionX = Console.CursorLeft;
                    Console.WriteLine("");
                    positionY = Console.CursorTop;
                    Console.SetCursorPosition(0, 21);

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(positionX - 1, positionY + 1);

                    for (int i = 0; i < 21; i++)
                    {
                        Console.WriteLine("|");
                        Console.SetCursorPosition(positionX - 1, positionY + i);
                    }
                    Console.SetCursorPosition(3, 2);
                    if (name != null)
                    {
                        Console.WriteLine(name);
                    }
                    else
                    {
                        Console.WriteLine("Сначала необходимо задать Имя");
                    }

                }

                if (userInput == "5" | userInput == "WriteNikName")
                {
                    Console.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    positionX = Console.CursorLeft;
                    Console.WriteLine("");
                    positionY = Console.CursorTop;
                    Console.SetCursorPosition(0, 21);

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(positionX - 1, positionY + 1);

                    for (int i = 0; i < 21; i++)
                    {
                        Console.WriteLine("|");
                        Console.SetCursorPosition(positionX - 1, positionY + i);
                    }
                    Console.SetCursorPosition(3, 2);
                    if (nikName != null)
                    {
                        Console.WriteLine(nikName);
                    }

                    else
                    {
                        Console.WriteLine("Сначала необходимо задать Никнейм");
                    }
                }

                if (userInput == "6" | userInput == "SetPassword")
                {

                    Console.Clear();

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    positionX = Console.CursorLeft;
                    Console.WriteLine("");
                    positionY = Console.CursorTop;
                    Console.SetCursorPosition(0, 21);

                    for (int i = 0; i < 100; i++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(positionX - 1, positionY + 1);

                    for (int i = 0; i < 21; i++)
                    {
                        Console.WriteLine("|");
                        Console.SetCursorPosition(positionX - 1, positionY + i);
                    }
                    Console.SetCursorPosition(3, 1);

                    while (countInput < 3)
                    {
                        Console.Clear();

                        for (int i = 0; i < 100; i++)
                        {
                            Console.Write("-");
                        }
                        positionX = Console.CursorLeft;
                        Console.WriteLine("");
                        positionY = Console.CursorTop;
                        Console.SetCursorPosition(0, 21);

                        for (int i = 0; i < 100; i++)
                        {
                            Console.Write("-");
                        }
                        Console.SetCursorPosition(positionX - 1, positionY + 1);

                        for (int i = 0; i < 21; i++)
                        {
                            Console.WriteLine("|");
                            Console.SetCursorPosition(positionX - 1, positionY + i);
                        }
                        Console.SetCursorPosition(3, 1);
                        Console.WriteLine("Введите старый пароль:");
                        userInput = Console.ReadLine();

                        if (userInput != password)
                        {
                            Console.WriteLine("Пароль не верен.Повторите ввод.");
                            Console.WriteLine($"Плпыток ввода {2 - countInput}");
                            countInput++;
                            Console.ReadLine();
                        }

                        else
                        {
                            countInput = 0;
                            Console.WriteLine("Введите новый пароль:");
                            userInput = Console.ReadLine();
                            Console.WriteLine("Повторите новый пароль:");

                            if (userInput != Console.ReadLine())
                            {
                                Console.WriteLine("Пароль не верен.Повторите ввод.");
                            }

                            if (userInput == Console.ReadLine())
                            {
                                password = Console.ReadLine();
                                Console.WriteLine("Пароль изменен");
                            }
                        }
                    }
                }

                if (countInput != 3)
                {
                    Console.ReadLine();
                }
                countInput = 0;
            }
        }
    }
}