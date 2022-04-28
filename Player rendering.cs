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
        private int _positionX;
        private int _positionY;
        public int PositionX { get { return _positionX; } }
        public int PositionY { get { return _positionY;} }

        public Player(int positionX,int positionY)
        {
            _positionX=positionX;
            _positionY=positionY;                    
        }

    }

    class Rendering
    {
        public void Draw(int X,int Y, char playerSymbol)
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(playerSymbol);
        }

    }
}
