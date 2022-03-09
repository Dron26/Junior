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
            string userInput1;
            string nikтame = null;
            bool isPasswordCorrect = false;
            bool isWorkingMenu = true;
            string name = null;
            int countInput = 0;
            int horizontalBorder = 100;
            int verticalBorder = 21;

            while (isPasswordCorrect == false)
            {
                Console.SetCursorPosition(3, 1);
                Console.WriteLine("Вход в программу\n   Введите пароль: \n\n");
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < horizontalBorder; i++)
                {
                    Console.Write("-");
                }
                positionX = Console.CursorLeft;
                Console.WriteLine("");
                positionY = Console.CursorTop;
                Console.SetCursorPosition(0, 21);

                for (int i = 0; i < horizontalBorder; i++)
                {
                    Console.Write("-");
                }
                Console.SetCursorPosition(positionX - 1, positionY + 1);

                for (int i = 0; i < verticalBorder; i++)
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
                    isPasswordCorrect = true;
                }
            }

            while (isWorkingMenu)
            {
                isPasswordCorrect = false;
                Console.Clear();
                for (int i = 0; i < horizontalBorder; i++)
                {
                    Console.Write("-");
                }
                positionX = Console.CursorLeft;
                Console.WriteLine("");
                positionY = Console.CursorTop;
                Console.SetCursorPosition(0, 21);

                for (int i = 0; i < horizontalBorder; i++)
                {
                    Console.Write("-");
                }
                Console.SetCursorPosition(positionX - 1, positionY + 1);

                for (int i = 0; i < verticalBorder; i++)
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

                else if (userInput == "1" | userInput == "SetName")
                {
                    Console.Clear();

                    for (int i = 0; i < horizontalBorder; i++)
                    {
                        Console.Write("-");
                    }
                    positionX = Console.CursorLeft;
                    Console.WriteLine("");
                    positionY = Console.CursorTop;
                    Console.SetCursorPosition(0, 21);

                    for (int i = 0; i < horizontalBorder; i++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(positionX - 1, positionY + 1);

                    for (int i = 0; i < verticalBorder; i++)
                    {
                        Console.WriteLine("|");
                        Console.SetCursorPosition(positionX - 1, positionY + i);
                    }
                    Console.SetCursorPosition(3, 1);
                    Console.WriteLine("Введите имя:");
                    name = Console.ReadLine();
                    Console.WriteLine("Имя сохранено");
                }

                else if (userInput == "2" | userInput == "SetNikName")
                {
                    Console.Clear();

                    for (int i = 0; i < horizontalBorder; i++)
                    {
                        Console.Write("-");
                    }
                    positionX = Console.CursorLeft;
                    Console.WriteLine("");
                    positionY = Console.CursorTop;
                    Console.SetCursorPosition(0, 21);

                    for (int i = 0; i < horizontalBorder; i++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(positionX - 1, positionY + 1);

                    for (int i = 0; i < verticalBorder; i++)
                    {
                        Console.WriteLine("|");
                        Console.SetCursorPosition(positionX - 1, positionY + i);
                    }
                    Console.SetCursorPosition(3, 1);
                    Console.WriteLine("Введите Никнейм:");
                    nikтame = Console.ReadLine();
                    Console.WriteLine("Никнейм сохранен");
                }

                else if (userInput == "3" | userInput == "ChangeConsoleColor")
                {
                    Console.Clear();

                    for (int i = 0; i < horizontalBorder; i++)
                    {
                        Console.Write("-");
                    }
                    positionX = Console.CursorLeft;
                    Console.WriteLine("");
                    positionY = Console.CursorTop;
                    Console.SetCursorPosition(0, 21);

                    for (int i = 0; i < horizontalBorder; i++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(positionX - 1, positionY + 1);

                    for (int i = 0; i < verticalBorder; i++)
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

                else if (userInput == "4" | userInput == "WriteName")
                {
                    Console.Clear();

                    for (int i = 0; i < horizontalBorder; i++)
                    {
                        Console.Write("-");
                    }
                    positionX = Console.CursorLeft;
                    Console.WriteLine("");
                    positionY = Console.CursorTop;
                    Console.SetCursorPosition(0, 21);

                    for (int i = 0; i < horizontalBorder; i++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(positionX - 1, positionY + 1);

                    for (int i = 0; i < verticalBorder; i++)
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

                else if (userInput == "5" | userInput == "WriteNikName")
                {
                    Console.Clear();

                    for (int i = 0; i < horizontalBorder; i++)
                    {
                        Console.Write("-");
                    }
                    positionX = Console.CursorLeft;
                    Console.WriteLine("");
                    positionY = Console.CursorTop;
                    Console.SetCursorPosition(0, 21);

                    for (int i = 0; i < horizontalBorder; i++)
                    {
                        Console.Write("-");
                    }
                    Console.SetCursorPosition(positionX - 1, positionY + 1);

                    for (int i = 0; i < verticalBorder; i++)
                    {
                        Console.WriteLine("|");
                        Console.SetCursorPosition(positionX - 1, positionY + i);
                    }
                    Console.SetCursorPosition(3, 2);
                    if (nikтame != null)
                    {
                        Console.WriteLine(nikтame);
                    }

                    else
                    {
                        Console.WriteLine("Сначала необходимо задать Никнейм");
                    }
                }

                else if (userInput == "6" | userInput == "SetPassword")
                {
                    while (countInput < 3 && isPasswordCorrect == false)
                    {
                        Console.Clear();

                        for (int i = 0; i < horizontalBorder; i++)
                        {
                            Console.Write("-");
                        }
                        positionX = Console.CursorLeft;
                        Console.WriteLine("");
                        positionY = Console.CursorTop;
                        Console.SetCursorPosition(0, 21);

                        for (int i = 0; i < horizontalBorder; i++)
                        {
                            Console.Write("-");
                        }
                        Console.SetCursorPosition(positionX - 1, positionY + 1);

                        for (int i = 0; i < verticalBorder; i++)
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
                            Console.ReadLine();
                            countInput++;
                        }

                        else
                        {
                            countInput = 0;
                            Console.WriteLine("Введите новый пароль:");
                            userInput = Console.ReadLine();
                            Console.WriteLine("Повторите новый пароль:");
                            userInput1 = Console.ReadLine();
                            if (userInput != userInput1)
                            {
                                Console.WriteLine("Пароль не верен.Повторите ввод.");
                                Console.ReadLine();
                            }

                            else
                            {
                                password = userInput1;
                                Console.WriteLine("Пароль изменен");
                                isPasswordCorrect = true;
                            }
                        }
                    }
                }

                //поставил тут if тк в других меню нет остановки и при сохранении никнейма или  
                //имени, консоль пробегает без остановки и непонятно что произошло, чтобы в каждом меню не ставить Console.ReadLine();
                //поставил 1 здесь на все меню(кроме 6 го, (там необходимо предупреждение вывести до очистки консоли и выхода из меню) 
                //если не делать if и countPut будет непонятная реакция -необходимо два раза enter нажимать пропуская Console.ReadLine();
                if (countInput != 3)
                {
                    Console.ReadLine();
                }
                countInput = 0;
            }
        }
    }
}
