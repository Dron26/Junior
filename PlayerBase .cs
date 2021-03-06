using System;
using System.Collections.Generic;
using System.Linq;

namespace Player_Base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database playerBase = new();
            playerBase.Work();
        }
    }

    class Database
    {
        private List<Player> _players = new();
        private int _idPlayer = 0;

        public void Work()
        {
            string userInput;
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine(" База Данных Игроков  \n  1 - Добавить игрока \n  2 - Поиск игрока \n  3 - Весь список игроков \n  4 - Блокировка Игрока \n  5 - Разлокировка Игрока  \n  6 - Удаление игрока\n  7 - Выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreatePlayer();
                        break;
                    case "2":
                        FindPlayer();
                        break;
                    case "3":
                        ShowAllPlayer();
                        break;
                    case "4":
                        BlockPlayer();
                        break;
                    case "5":
                        UnblockPlayer();
                        break;
                    case "6":
                        DeletePlayer();
                        break;
                    case "7":
                        isWorking = false;
                        break;
                }
            }
        }

        private void CreatePlayer()
        {
            int maxLengthName = 20;
            int minLeghtName = 1;
            int minLevel = 1;
            int maxLevel = 100;
            List<string> listSymbolBlock = new List<string> { "~", "!", "@", "#", "$", "%", "^", "&" };
            string name;
            string nickname;
            int level;
            bool isPlayerBlock = false;
            string userInput;

            Console.Clear();
            Console.WriteLine("Введите имя игрока");
            userInput = Console.ReadLine();
            name = ReadName(userInput, minLeghtName, maxLengthName, listSymbolBlock);

            Console.WriteLine("Введите никнейм игрока");
            userInput = Console.ReadLine();
            nickname = ReadName(userInput, minLeghtName, maxLengthName, listSymbolBlock);

            Console.WriteLine("Введите уровень игрока");
            userInput = Console.ReadLine();
            level = ReadLevel(userInput, minLevel, maxLevel);
            _players.Add(new Player(name, nickname, level, isPlayerBlock, _idPlayer));
            _idPlayer++;

            Console.Clear();
            Console.WriteLine($"  Имя - { name }\n  Ник - {nickname}\n  Уровень - {level}");
            Console.WriteLine("Данные сохранены");
            Console.ReadLine();
            Console.Clear();
        }

        private string ReadName(string userInput, int minLeghtName, int maxLengthName, List<string> blockSymbol)
        {
            bool isTrue = false;
            string value = null;

            while (isTrue == false)
            {
                if (int.TryParse(userInput, out int result) == false)
                {
                    if (userInput.Length >= minLeghtName & userInput.Length <= maxLengthName & (blockSymbol.Any(symbol => symbol != userInput)))
                    {
                        isTrue = true;
                        value = userInput;
                    }
                    else
                    {
                        Console.WriteLine($"  Имя или ник должны содержать от {minLeghtName} до {maxLengthName} символов\n  Повторите ввод:");
                        userInput = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine($"  Имя или ник должны содержать от {minLeghtName} до {maxLengthName} символов\n  Повторите ввод:");
                    userInput = Console.ReadLine();
                }
            }

            return value;
        }

        private int ReadLevel(string userinput, int minLevel, int maxLevel)
        {
            bool isTrue = false;
            int value = 0;

            while (isTrue == false)
            {
                if (int.TryParse(userinput, out int result) == true)
                {
                    value = Convert.ToInt32(userinput);

                    if (minLevel <= value & value <= maxLevel)
                    {
                        isTrue = true;
                    }
                    else
                    {
                        Console.WriteLine($"  Уровень должен быть в диапазоне от {minLevel} до {maxLevel}\n  Повторите ввод:");
                        userinput = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine($"  Уровень должен быть в диапазоне от {minLevel} до {maxLevel}\n  Повторите ввод:");
                    userinput = Console.ReadLine();
                }
            }

            return value;
        }

        private void FindPlayer()
        {
            string userInput;
            bool isFinded = false;

            Console.Clear();
            Console.WriteLine("  Введите имя игрока:");
            userInput = Console.ReadLine();

            foreach (Player player in _players)
            {
                if (player.Name.Contains(userInput))
                {
                    player.ShowParametr();
                    Console.ReadLine();
                    isFinded = true;
                }
            }

            if (isFinded == false)
            {
                Console.WriteLine(" Игрок не найден!");
                Console.ReadLine();
            }

            Console.Clear();
        }

        private void ShowAllPlayer()
        {
            Console.Clear();

            if (_players.Count == 0)
            {
                Console.WriteLine(" Список игровок пуст");
            }
            else
            {
                foreach (Player player in _players)
                {
                    player.ShowParametr();
                }
            }

            Console.ReadLine();
            Console.Clear();
        }

        private void BlockPlayer()
        {
            string userInput;
            string userInput2;
            bool isActionCompleted = false;
            bool isActionCancell = false;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");

            userInput = Console.ReadLine();

            if (TryGetPlayer(userInput, out Player player))
            {
                player.ShowParametr();

                if (player.IsBlock == true)
                {
                    Console.WriteLine($"Аккаунт уже заблокирован");
                    isActionCancell = true;
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine($" Подтвердите блокировку (Y/N)");
                    userInput2 = Console.ReadLine();

                    if (userInput2.ToLower() == "y")
                    {
                        player.Block();
                        Console.WriteLine($" Игрок блокирован!");
                        isActionCompleted = true;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"Отмена ");
                        isActionCancell = true;
                        Console.ReadLine();
                    }
                }

                if (isActionCompleted == false & isActionCancell == false)
                {
                    Console.WriteLine(" Игрок не найден");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не верные данные");
                Console.ReadLine();
            }

            Console.Clear();
        }

        private void UnblockPlayer()
        {
            string userInput;
            string userInput2;
            bool isActionCompleted = false;
            bool isActionCancell = false;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");
            userInput = Console.ReadLine();

            if (TryGetPlayer(userInput, out Player player))
            {
                player.ShowParametr();

                if (player.IsBlock == false)
                {
                    Console.WriteLine($"Аккаунт уже разблокирован");
                    isActionCancell = true;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($" Подтвердите разблокировку (Y/N)");
                    userInput2 = Console.ReadLine();

                    if (userInput2.ToLower() == "y")
                    {
                        player.Unblock();
                        Console.WriteLine($" Игрок  разблокирован!");
                        isActionCompleted = true;
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine($"Отмена ");
                        isActionCancell = true;
                        Console.ReadLine();
                    }
                }

                if (isActionCompleted == false & isActionCancell == false)
                {
                    Console.WriteLine(" Игрок не найден");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не верные данные");
            }

            Console.Clear();
        }

        private void DeletePlayer()
        {
            string userInput;
            string userInput2;
            bool isActionCompleted = false;
            bool isActionCancell = false;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");
            userInput = Console.ReadLine();

            if (TryGetPlayer(userInput, out Player player))
            {
                player.ShowParametr();
                Console.WriteLine($" Подтвердите удаление (Y/N)");
                userInput2 = Console.ReadLine();

                if (userInput2.ToLower() == "y")
                {
                    _players.Remove(player);
                    Console.WriteLine($" Игрок  удален!");
                    isActionCompleted = true;
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Отмена ");
                    isActionCancell = true;
                    Console.ReadLine();
                }

                if (isActionCompleted == false & isActionCancell == false)
                {
                    Console.WriteLine(" Игрок не найден");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не верные данные,возможно игрок удален");
                Console.ReadLine();
            }

            Console.Clear();
        }

        private bool TryGetPlayer(string userInput, out Player truePlayer)
        {
            truePlayer = null;
            bool isGetPlayer = false;

            if (int.TryParse(userInput, out int number) == true)
            {
                foreach (Player player in _players)
                {
                    if (player.Id == number)
                    {
                        truePlayer = player;
                        isGetPlayer = true;
                        return isGetPlayer;
                    }
                }
            }

            return isGetPlayer;
        }
    }

    class Player
    {
        public string Name { get; }
        public string Nickname { get; }
        public bool IsBlock { get; private set; }
        public int Level { get; }
        public int Id { get; }

        public Player(string name, string nickname, int level, bool isPlayerBlock, int id)
        {
            Name = name;
            Nickname = nickname;
            Level = level;
            IsBlock = isPlayerBlock;
            Id = id;
        }

        public void Block()
        {
            IsBlock = true;
        }

        public void Unblock()
        {
            IsBlock = false;
        }

        public void ShowParametr()
        {
            Console.WriteLine($"Имя: {Name}, Ник: {Nickname}, Уровень: {Level}, Уникальный номер: {Id}, Статус блокировки : { IsBlock}");
        }
    }
}
