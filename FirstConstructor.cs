using System;

namespace FirstConstructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(19, 99, "Андрей");
            player.ShowInfo();
        }
    }

    class Player
    {
        int Age;
        int Level;
        string Name; 


        public Player(int age,int level,string name)
        {
            Age = age;
            Level = level;
            Name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($" Имя - {Name}, Возраст - {Age}, Уровень - {Level}");
        }
    }        
}
