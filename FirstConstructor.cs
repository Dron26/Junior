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
       private int _age;
       private int _level;
       private string _name; 


        public Player(int age,int level,string name)
        {
            _age = age;
            _level = level;
            _name = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($" Имя - {_name}, Возраст - {_age}, Уровень - {_level}");
        }       
    }        
}
