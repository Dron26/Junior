using System;

namespace Player_rendering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char playerSymbol = '@';

            Player player = new Player(5,5);
            Rendering rendering = new Rendering();
            rendering.Draw(player.PositionX,player.PositionY, playerSymbol);
        }
    }

    class Player
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public Player(int positionX,int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;                    
        }
    }

    class Rendering
    {
        public void Draw(int positionX,int positionY, char playerSymbol)
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.WriteLine(playerSymbol);
        }
    }
}
