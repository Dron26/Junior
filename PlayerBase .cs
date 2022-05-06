using System;
using System.Collections.Generic;
using System.Linq;

namespace Player_Base
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerBase playerBase = new PlayerBase();
            playerBase.ShowMenu();
        }

    }

    class PlayerBase
    {
        List<Player> AccountRegistry = new List<Player>();

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
            string name = null;
            string nickname;
            int level;
            bool isAccountBlock = false;
            bool isLevel;

            Console.Clear();
            Console.WriteLine("Введите имя игрока");
            name = CheckInput(Console.ReadLine(), minLeghtName, maxLengthName, listSymbolBlock, minLevel, maxLevel, isLevel = false);
            Console.WriteLine("Введите ник игрока");
            nickname = CheckInput(Console.ReadLine(), minLeghtName, maxLengthName, listSymbolBlock, minLevel, maxLevel, isLevel = false);
            Console.WriteLine("Введите уровень игрока");
            level = Convert.ToInt32(CheckInput(Console.ReadLine(), minLeghtName, maxLengthName, listSymbolBlock, minLevel, maxLevel, isLevel = true));
            AccountRegistry.Add(new Player(name, nickname, level, isAccountBlock));
            Console.Clear();
            Console.WriteLine($"  Имя - { name }\n  Ник - {nickname}\n  Уровень - {level}");
            Console.WriteLine("Данные сохранены");
            Console.ReadLine();
            Console.Clear();
        }

        public string CheckInput(string value, int minLeghtName, int maxLengthName, List<string> blockSymbol, int minLevel, int maxLevel, bool isLevel)
        {
            bool isTrue = false;

            while (isTrue == false)
            {
                if (isLevel == false)
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
                else
                {
                    bool isLevelInt = int.TryParse(value, out int number);

                    if (isLevelInt)
                    {
                        if (minLevel <= number & number <= maxLevel)
                        {
                            isTrue = true;
                        }
                        else
                        {
                            Console.WriteLine($"  Уровень должен быть в диапазоне от {minLevel} до {maxLevel}\n  Повторите ввод:");
                            value = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"  Уровень должен быть в диапазоне от {minLevel} до {maxLevel}\n  Повторите ввод:");
                        value = Console.ReadLine();
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
                int id = AccountRegistry.IndexOf(account);

                if (AccountRegistry[id].TakeName().Contains(userInput))
                {
                    AccountRegistry[id].ShowParametr(id);
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
                    int id = AccountRegistry.IndexOf(account);

                    AccountRegistry[id].ShowParametr(id);

                }

            }

            Console.ReadLine();
            Console.Clear();
        }

        public void BlockPlayerAccount()
        {
            int id;
            string userInput;
            string userInput2;
            bool isActionCompleted = false;
            bool isActionCancell = false;
            bool isUserInputTrue = false;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");
            userInput = Console.ReadLine();
            isUserInputTrue = int.TryParse(userInput, out int number);

            foreach (Player account in AccountRegistry)
            {
                id = AccountRegistry.IndexOf(account);

                if (id == number)
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
                AccountRegistry[number].ShowParametr(number);

                if (AccountRegistry[number].IsAccountBlock() == true)
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
            int id;
            string userInput;
            string userInput2;
            bool isActionCompleted = false;
            bool isActionCancell = false;
            bool isUserInputTrue = false;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");
            userInput = Console.ReadLine();
            isUserInputTrue = int.TryParse(userInput, out int number);


            foreach (Player account in AccountRegistry)
            {
                id = AccountRegistry.IndexOf(account);

                if (id == number)
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
                AccountRegistry[number].ShowParametr(number);

                if (AccountRegistry[number].IsAccountBlock() == false)
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
            int id;
            string userInput;
            string userInput2;
            bool isActionCompleted = false;
            bool isActionCancell = false;
            bool isUserInputTrue = false;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");
            userInput = Console.ReadLine();
            isUserInputTrue = int.TryParse(userInput, out int number);

            foreach (Player account in AccountRegistry)
            {
                id = AccountRegistry.IndexOf(account);

                if (id == number)
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
                AccountRegistry[number].ShowParametr(number);

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
        private string _name { get; set; }
        private string _nickname { get; set; }
        private int _level { get; set; }
        private bool _isAccountBlock { get; set; }

        public Player(string name, string nickname, int level, bool isAccountBlock)
        {
            _name = name;
            _nickname = nickname;
            _level = level;
            _isAccountBlock = isAccountBlock;
        }

        public string TakeName()
        {
            return _name;
        }

        public bool IsAccountBlock()
        {
            return _isAccountBlock;
        }

        public void BlockUnblockAccount(bool action)
        {
            _isAccountBlock = action;
        }

        public void ShowParametr(int id)
        {
            Console.WriteLine($"Имя: {_name}, Ник: {_nickname}, Уровень: {_level}, Уникальный номер: {id}, Статус блокировки : { _isAccountBlock}");
        }

    }
}
