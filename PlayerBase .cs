using System;
using System.Collections.Generic;
using System.Linq;

namespace Player_Base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerBase playerBase = new();
            playerBase.ShowMenu();
        }
    }

    class PlayerBase
    {
        private List<Player> AccountRegistry = new();
        int id = 0;
        public void ShowMenu()
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
                        CreateAccount();
                        break;
                    case "2":
                        FindAccount();
                        break;
                    case "3":
                        ShowAllAccount();
                        break;
                    case "4":
                        BlockPlayerAccount();
                        break;
                    case "5":
                        UnBlockPlayerAccount();
                        break;
                    case "6":
                        DeletePlayerAccount();
                        break;
                    case "7":
                        isWorking = false;
                        break;
                }
            }
        }

        public void CreateAccount()
        {
            int maxLengthName = 20;
            int minLeghtName = 1;
            int minLevel = 1;
            int maxLevel = 100;
            List<string> listSymbolBlock = new List<string> { "~", "!", "@", "#", "$", "%", "^", "&" };
            string name;
            string nickname;
            int level;
            bool isAccountBlock = false;

            Console.Clear();
            Console.WriteLine("Введите имя игрока");
            name = CheckInputNameNickname(Console.ReadLine(), minLeghtName, maxLengthName, listSymbolBlock);
            Console.WriteLine("Введите никнейм игрока");
            nickname = CheckInputNameNickname(Console.ReadLine(), minLeghtName, maxLengthName, listSymbolBlock);
            Console.WriteLine("Введите уровень игрока");
            level = CheckInputLevel(Convert.ToInt32(Console.ReadLine()), minLevel, maxLevel);
            AccountRegistry.Add(new Player(name, nickname, level, isAccountBlock, id));
            id++;
            Console.Clear();
            Console.WriteLine($"  Имя - { name }\n  Ник - {nickname}\n  Уровень - {level}");
            Console.WriteLine("Данные сохранены");
            Console.ReadLine();
            Console.Clear();
        }

        public string CheckInputNameNickname(string value, int minLeghtName, int maxLengthName, List<string> blockSymbol)
        {
            bool isTrue = false;

            while (isTrue == false)
            {
                if (value.Length >= minLeghtName & value.Length <= maxLengthName & (blockSymbol.Any(symbol => symbol != value)))
                {
                    isTrue = true;
                }
                else
                {
                    Console.WriteLine($"  Имя или ник должны содержать от {minLeghtName} до {maxLengthName} символов\n  Повторите ввод:");
                    value = Console.ReadLine();
                }
            }

            return value;
        }

        public int CheckInputLevel(int value, int minLevel, int maxLevel)
        {
            bool isTrue = false;

            if (value.GetType() == typeof(int))
            {
                while (isTrue == false)
                {
                    if (minLevel <= value & value <= maxLevel)
                    {
                        isTrue = true;
                    }
                    else
                    {
                        Console.WriteLine($"  Уровень должен быть в диапазоне от {minLevel} до {maxLevel}\n  Повторите ввод:");
                        value = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }

            return value;
        }

        public void FindAccount()
        {
            string userInput;
            bool isFinded = false;

            Console.Clear();
            Console.WriteLine("  Введите имя игрока:");
            userInput = Console.ReadLine();

            foreach (Player account in AccountRegistry)
            {
                int number = AccountRegistry.IndexOf(account);

                if (AccountRegistry[number].TakeName.Contains(userInput))
                {
                    AccountRegistry[number].ShowParametr();
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

        public void ShowAllAccount()
        {
            Console.Clear();

            if (AccountRegistry.Count == 0)
            {
                Console.WriteLine(" Список игровок пуст");
            }
            else
            {
                foreach (Player account in AccountRegistry)
                {
                    int index = AccountRegistry.IndexOf(account);

                    AccountRegistry[index].ShowParametr();

                }
            }

            Console.ReadLine();
            Console.Clear();
        }

        public void BlockPlayerAccount()
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

            foreach (Player account in AccountRegistry)
            {
                if (account.Id == number)
                {
                    isUserInputTrue = true;
                    break;
                }
                else
                {
                    isUserInputTrue = false;
                }
            }

            if (isUserInputTrue)
            {
                AccountRegistry[number].ShowParametr();

                if (AccountRegistry[number].IsAccountBlock == true)
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
                        AccountRegistry[number].BlockUnblockAccount(true);
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
            }

            Console.Clear();
        }

        public void UnBlockPlayerAccount()
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

            foreach (Player account in AccountRegistry)
            {
                if (account.Id == number)
                {
                    isUserInputTrue = true;
                    break;
                }
                else
                {
                    isUserInputTrue = false;
                }
            }

            if (isUserInputTrue)
            {
                AccountRegistry[number].ShowParametr();

                if (AccountRegistry[number].IsAccountBlock == false)
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
                        AccountRegistry[number].BlockUnblockAccount(false);
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

        public void DeletePlayerAccount()
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

            foreach (Player account in AccountRegistry)
            {
                if (account.Id == number)
                {
                    isUserInputTrue = true;
                    break;
                }
                else
                {
                    isUserInputTrue = false;
                }
            }

            if (isUserInputTrue)
            {
                AccountRegistry[number].ShowParametr();
                Console.WriteLine($" Подтвердите удаление (Y/N)");
                userInput2 = Console.ReadLine();

                if (userInput2.ToLower() == "y")
                {
                    AccountRegistry.RemoveAt(number);
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
    }

    class Player
    {
        private readonly string _name;
        private readonly string _nickname;
        private readonly int _level;
        private bool _isAccountBlock;
        private readonly int _id;

        public Player(string name, string nickname, int level, bool isAccountBlock, int id)
        {
            _name = name;
            _nickname = nickname;
            _level = level;
            _isAccountBlock = isAccountBlock;
            _id = id;
        }

        public string TakeName => _name;

        public bool IsAccountBlock => _isAccountBlock;

        public int Id => _id;

        public void BlockUnblockAccount(bool action)
        {
            _isAccountBlock = action;
        }

        public void UnblockAccount(bool action)
        {
            _isAccountBlock = action;
        }

        public void ShowParametr()
        {
            Console.WriteLine($"Имя: {_name}, Ник: {_nickname}, Уровень: {_level}, Уникальный номер: {_id}, Статус блокировки : { _isAccountBlock}");
        }
    }
}
