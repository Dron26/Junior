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
        private List<Player> _accountRegistry = new();
        private int identificationNumber = 0;

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

        private void CreateAccount()
        {
            int maxLengthName = 20;
            int minLeghtName = 1;
            int minLevel = 1;
            int maxLevel = 100;
            List<string> listSymbolBlock = new List<string> { "~", "!", "@", "#", "$", "%", "^", "&" };
            string name = null;
            string nickname = null;
            int level = 0;
            bool isAccountBlock = false;
            string userInput;
            string valueNameNickname;
            int valeuLevel;

            Console.Clear();
            Console.WriteLine("Введите имя игрока");
            userInput = Console.ReadLine();

            if (CheckInputNameNickname(userInput, minLeghtName, maxLengthName, listSymbolBlock, out valueNameNickname) == true)
            {
                name = valueNameNickname;
            }
            else
            {
                Console.WriteLine("Вы ввели неверные данные");
            }

            Console.WriteLine("Введите никнейм игрока");
            userInput = Console.ReadLine();

            if (CheckInputNameNickname(userInput, minLeghtName, maxLengthName, listSymbolBlock, out valueNameNickname) == true)
            {
                nickname = valueNameNickname;
            }
            else
            {
                Console.WriteLine("Вы ввели неверные данные");
            }

            Console.WriteLine("Введите уровень игрока");
            userInput = Console.ReadLine();

            if (CheckInputLevel(userInput, minLevel, maxLevel, out valeuLevel) == true)
            {
                level = valeuLevel;
            }
            else
            {
                Console.WriteLine("Вы ввели неверные данные");
            }

            _accountRegistry.Add(new Player(name, nickname, level, isAccountBlock, identificationNumber));
            identificationNumber++;

            Console.Clear();
            Console.WriteLine($"  Имя - { name }\n  Ник - {nickname}\n  Уровень - {level}");
            Console.WriteLine("Данные сохранены");
            Console.ReadLine();
            Console.Clear();
        }

        private bool CheckInputNameNickname(string userInput, int minLeghtName, int maxLengthName, List<string> blockSymbol, out string value)
        {
            bool isTrue = false;
            value = null;

            while (isTrue == false)
            {
                if (IsInputText(userInput) == true)
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

        private bool CheckInputLevel(string userinput, int minLevel, int maxLevel, out int value)
        {
            bool isTrue = false;
            value = 0;

            while (isTrue == false)
            {
                if (IsInputText(userinput) == false)
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

        private bool IsInputText(string value)
        {
            bool isInputTrue;

            if (int.TryParse(value, out int result) == true)
            {
                return isInputTrue = false;
            }
            else
            {
                return isInputTrue = true;
            }
        }

        private void FindAccount()
        {
            string userInput;
            bool isFinded = false;

            Console.Clear();
            Console.WriteLine("  Введите имя игрока:");
            userInput = Console.ReadLine();

            foreach (Player player in _accountRegistry)
            {
                int number = _accountRegistry.IndexOf(player);

                if (_accountRegistry[number].TakeName.Contains(userInput))
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

        private void ShowAllAccount()
        {
            Console.Clear();

            if (_accountRegistry.Count == 0)
            {
                Console.WriteLine(" Список игровок пуст");
            }
            else
            {
                foreach (Player account in _accountRegistry)
                {
                    int index = _accountRegistry.IndexOf(account);
                    _accountRegistry[index].ShowParametr();
                }
            }

            Console.ReadLine();
            Console.Clear();
        }

        private void BlockPlayerAccount()
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

            if (isUserInputTrue)
            {
                TryGetPlayer(number, out Player player);
                player.ShowParametr();

                if (player.IsAccountBlock == true)
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
                        player.BlockAccount(true);
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

        private void UnBlockPlayerAccount()
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

            if (isUserInputTrue)
            {
                TryGetPlayer(number, out Player player);
                player.ShowParametr();

                if (player.IsAccountBlock == false)
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
                        player.BlockAccount(false);
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

        private void DeletePlayerAccount()
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

            if (isUserInputTrue)
            {
                TryGetPlayer(number, out Player player);
                player.ShowParametr();
                Console.WriteLine($" Подтвердите удаление (Y/N)");
                userInput2 = Console.ReadLine();

                if (userInput2.ToLower() == "y")
                {
                    _accountRegistry.RemoveAt(number);
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

        private bool TryGetPlayer(int number, out Player player)
        {
            player = null;

            foreach (Player account in _accountRegistry)
            {
                if (account.Id == number)
                {
                    player = account;
                    return true;
                }

            }

            return false;
        }
    }

    class Player
    {
        private readonly string _name;
        private readonly string _nickname;
        private readonly int _level;
        private readonly int _id;
        private bool _isAccountBlock;
        public string TakeName => _name;
        public bool IsAccountBlock => _isAccountBlock;
        public int Id => _id;

        public Player(string name, string nickname, int level, bool isAccountBlock, int id)
        {
            _name = name;
            _nickname = nickname;
            _level = level;
            _isAccountBlock = isAccountBlock;
            _id = id;
        }

        public void BlockAccount(bool action)
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
