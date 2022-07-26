using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.PlayerBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database playerBase = new Database();
            playerBase.Work();
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();
        public Database()
        {
            Random random = new Random();
            int numberName;
            int counPlayer = 15;
            int maxLevel = 100;
            int level = 0;
            int maxPower = 100;
            int power = 0;

            List<string> names = new List<string>()
            {
                "Александр",
                "Михаил",
                "Даниил",
                "Матвей",
                "Иван",
                "Кирилл",
                "Егор",
                "Дмитрий",
                "Роман",
                "Артем",
                "Тимофей",
                "Виктор",
                "Владимир",
                "Илья",
                "Максим",
                "Алексей",
                "Евгений",
                "Денис",
                "Ярослав",
                "Арсений",
                "Платон",
                "Никита",
                "Сергей",
                "Лев",
                "Степан",
                "Константин",
                "Мирон",
                "Богдан",
                "Федор",
                "Андрей",
            };

            for (int i = 0; i < counPlayer; i++)
            {
                numberName = random.Next(names.Count);
                level = random.Next(maxLevel);
                power = random.Next(maxPower);

                _players.Add(new Player(names[numberName], level, power));
            }
        }

        public void Work()
        {
            ShowPlayer(SortByLevel());
            ShowPlayer(SortByPower());
            Console.Clear();
        }

        private void ShowPlayer(List<Player> players)
        {
            Console.Clear();

            if (players != null & players.Count > 0)
            {
                foreach (Player player in players)
                {

                    Console.WriteLine($"\n  Name: {player.Name}  Level: {player.Level} Power: {player.Power} ");
                }
            }
            else
            {
                Console.WriteLine($"Client was not found");
            }

            Console.ReadLine();
        }

        private List<Player> SortByLevel()
        {
            int countTopPlayer = 3;

            var sortPlayersByLevel = _players.OrderByDescending(p => p.Level).Take(countTopPlayer).ToList();

            return sortPlayersByLevel.ToList();
        }
        private List<Player> SortByPower()
        {
            int countTopPlayer = 3;

            var sortPlayersByPower = _players.OrderByDescending(p => p.Power).Take(countTopPlayer).ToList();

            return sortPlayersByPower.ToList();
        }
    }
    
    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }
    }
}