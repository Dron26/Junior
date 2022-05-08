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
        private int idPlayer = 0;

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
                        UnBlockPlayer();
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
            string name = null;
            string nickname = null;
            int level = 0;
            bool isPlayerBlock = false;
            string userInput;
            string valueNameNickname;
            int valeuLevel;

            Console.Clear();
            Console.WriteLine("Введите имя игрока");
            userInput = Console.ReadLine();

            if (IsEnteredValueContainName(userInput, minLeghtName, maxLengthName, listSymbolBlock, out valueNameNickname) == true)
            {
                name = valueNameNickname;
            }
            else
            {
                Console.WriteLine("Вы ввели неверные данные");
            }

            Console.WriteLine("Введите никнейм игрока");
            userInput = Console.ReadLine();

            if (IsEnteredValueContainName(userInput, minLeghtName, maxLengthName, listSymbolBlock, out valueNameNickname) == true)
            {
                nickname = valueNameNickname;
            }
            else
            {
                Console.WriteLine("Вы ввели неверные данные");
            }

            Console.WriteLine("Введите уровень игрока");
            userInput = Console.ReadLine();

            if (IsEnteredValueContainLevel(userInput, minLevel, maxLevel, out valeuLevel) == true)
            {
                level = valeuLevel;
            }
            else
            {
                Console.WriteLine("Вы ввели неверные данные");
            }

            _players.Add(new Player(name, nickname, level, isPlayerBlock, idPlayer));
            idPlayer++;

            Console.Clear();
            Console.WriteLine($"  Имя - { name }\n  Ник - {nickname}\n  Уровень - {level}");
            Console.WriteLine("Данные сохранены");
            Console.ReadLine();
            Console.Clear();
        }

        private bool IsEnteredValueContainName(string userInput, int minLeghtName, int maxLengthName, List<string> blockSymbol, out string value)
        {
            bool isTrue = false;
            value = null;

            while (isTrue == false)
            {
                if (int.TryParse(userInput, out int result) == true)
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

            return isTrue;
        }

        private bool IsEnteredValueContainLevel(string userinput, int minLevel, int maxLevel, out int value)
        {
            bool isTrue = false;
            value = 0;

            while (isTrue == false)
            {
                if (int.TryParse(userinput, out int result) == false)
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

            return isTrue;
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
                int number = _players.IndexOf(player);

                if (_players[number].Name.Contains(userInput))
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
                    int index = _players.IndexOf(player);
                    _players[index].ShowParametr();
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
            bool isUserInputTrue;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");

            userInput = Console.ReadLine();
            isUserInputTrue = int.TryParse(userInput, out int number);

            if (isUserInputTrue & TryGetPlayer(number, out Player player))
            {
                player.ShowParametr();

                if (player.IsPlayerBlock == true)
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
                        player.BlockPlayer(true);
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

        private void UnBlockPlayer()
        {
            string userInput;
            string userInput2;
            bool isActionCompleted = false;
            bool isActionCancell = false;
            bool isUserInputTrue;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");
            userInput = Console.ReadLine();
            isUserInputTrue = int.TryParse(userInput, out int number);

            if (isUserInputTrue & TryGetPlayer(number, out Player player))
            {
                player.ShowParametr();

                if (player.IsPlayerBlock == false)
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
                        player.BlockPlayer(false);
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
            bool isUserInputTrue;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");
            userInput = Console.ReadLine();
            isUserInputTrue = int.TryParse(userInput, out int number);

            if (isUserInputTrue & TryGetPlayer(number, out Player player))
            {
                player.ShowParametr();
                Console.WriteLine($" Подтвердите удаление (Y/N)");
                userInput2 = Console.ReadLine();

                if (userInput2.ToLower() == "y")
                {
                    _players.RemoveAt(number);
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

        private bool TryGetPlayer(int number, out Player truePlayer)
        {
            truePlayer = null;

            foreach (Player player in _players)
            {
                if (player.Id == number)
                {
                    truePlayer = player;
                    return true;
                }
            }

            return false;
        }
    }

    class Player
    {
        public string Name { get; }
        public string Nickname { get; }
        public bool IsPlayerBlock { get; private set; }
        public int Level { get; }
        public int Id { get; }

        public Player(string name, string nickname, int level, bool isPlayerBlock, int id)
        {
            Name = name;
            Nickname = nickname;
            Level = level;
            IsPlayerBlock = isPlayerBlock;
            Id = id;
        }

        public void BlockPlayer(bool action)
        {
            IsPlayerBlock = action;
        }

        public void UnblockPlayer(bool action)
        {
            IsPlayerBlock = action;
        }

        public void ShowParametr()
        {
            Console.WriteLine($"Имя: {Name}, Ник: {Nickname}, Уровень: {Level}, Уникальный номер: {Id}, Статус блокировки : { IsPlayerBlock}");
        }
    }
}
