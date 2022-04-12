using System;
using System.IO;

namespace DrawUsingAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int pacManPositionX, pacManPositionY;
            int pacManDirectionX = 0, pacManDirectionY = 1;
            int widthWindow = 44;
            int heightWindow = 18;
            char symbolPlayer = '@';
            bool isPlaying = true;
            Console.CursorVisible = false;
            ConsoleKeyInfo key;

            SetWindowSize(widthWindow, heightWindow);

            char[,] map = ReadMap("Map1", symbolPlayer, out pacManPositionX, out pacManPositionY);

            DrawMap(map);

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        isPlaying = false;
                    }
                    else
                    {
                        ChangeDirection(key, ref pacManDirectionX, ref pacManDirectionY);
                    }

                }
                else if (map[pacManPositionX + pacManDirectionX, pacManPositionY + pacManDirectionY] != '#')
                {
                    Move(map, '@', ref pacManPositionX, ref pacManPositionY, pacManDirectionX, pacManDirectionY);
                }

                System.Threading.Thread.Sleep(100);
            }

        }

        static char[,] ReadMap(string mapName, char symbolPlayer, out int pacManX, out int pacManY)
        {
            pacManX = 0;
            pacManY = 0;
            string[] newFile = File.ReadAllLines($"{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == symbolPlayer)
                    {
                        pacManX = i;
                        pacManY = j;
                    }
                }
            }

            return map;
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }

        }

        static void Move(char[,] map, char symbolPlayer, ref int pacManPositionX, ref int pacManPositionY, int pacManDirectionX, int pacManDirectionY)
        {
            Console.SetCursorPosition(pacManPositionY, pacManPositionX);
            map[pacManPositionX, pacManPositionY] = ' ';
            Console.Write(map[pacManPositionX, pacManPositionY]);
            pacManPositionX += pacManDirectionX;
            pacManPositionY += pacManDirectionY;
            Console.SetCursorPosition(pacManPositionY, pacManPositionX);
            Console.Write(symbolPlayer);
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int pacManDirectionX, ref int pacManDirectionY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    pacManDirectionX = -1; pacManDirectionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    pacManDirectionX = 1; pacManDirectionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    pacManDirectionX = 0; pacManDirectionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    pacManDirectionX = 0; pacManDirectionY = 1;
                    break;
            }

        }

        public static void SetWindowSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }
    }
}
