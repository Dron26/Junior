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
            playerBase.Menu();
        }

    }
    class PlayerBase
    {
        private Dictionary<int, Player> _accountRegistry = new Dictionary<int, Player>();

        public Dictionary<int, Player> AccountRegistry
        {
            get { return _accountRegistry; }
        }

        public void Menu()
        {
            int idAccount = 0;
            string userInput;
            bool isWorking = true;
            int changeAction;

            while (isWorking)
            {
                Console.WriteLine(" База Данных Игроков  \n  1 - Добавить игрока \n  2 - Поиск игрока \n  3 - Весь список игроков \n  4 - Блокировка Игрока \n  5 - Разлокировка Игрока  \n  6 - Удаление игрока\n  7 - Выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateAccount(ref idAccount);
                        break;
                    case "2":
                        FindAccount();
                        break;
                    case "3":
                        ShowAllAccount();
                        break;
                    case "4":
                        ActionOnPlayerAccount(changeAction = 1);
                        break;
                    case "5":
                        ActionOnPlayerAccount(changeAction = 2);
                        break;
                    case "6":
                        ActionOnPlayerAccount(changeAction = 3);
                        break;
                    case "7":
                        isWorking = false;
                        break;
                }

            }

        }

        public void AddPlayerInfo(int idAccount, string name, string nickname, int level)
        {
            _accountRegistry.Add(idAccount, new Player { Name = name, Nickname = nickname, Level = level, IsAccountBlock = false, Id = idAccount });
        }

        public void CreateAccount(ref int idAccount)
        {
            int maxLengthName = 20;
            int minLeghtName = 1;
            int minLevel = 1;
            int maxLevel = 100;
            List<string> listSymbolBlock = new List<string> { "~", "!", "@", "#", "$", "%", "^", "&" };
            string name = null;
            string nickname;
            int level;
            bool isAccountBlock;
            bool isLevel;

            Console.Clear();
            Console.WriteLine("Введите имя игрока");
            name = CheckInput(Console.ReadLine(), minLeghtName, maxLengthName, listSymbolBlock, minLevel, maxLevel, isLevel = false);
            Console.WriteLine("Введите ник игрока");
            nickname = CheckInput(Console.ReadLine(), minLeghtName, maxLengthName, listSymbolBlock, minLevel, maxLevel, isLevel = false);
            Console.WriteLine("Введите уровень игрока");
            level = Convert.ToInt32(CheckInput(Console.ReadLine(), minLeghtName, maxLengthName, listSymbolBlock, minLevel, maxLevel, isLevel = true));
            AddPlayerInfo(idAccount, name, nickname, level);
            Console.Clear();
            Console.WriteLine($"  Имя - { name }\n  Ник - {nickname}\n  Уровень - {level}");
            Console.WriteLine("Данные сохранены");
            idAccount++;
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

            for (int i = 0; i < AccountRegistry.Count; i++)
            {
                if (AccountRegistry[i].Name.Contains(userInput))
                {
                    Console.WriteLine($"  Имя: {AccountRegistry[i].Name}, Ник: {AccountRegistry[i].Nickname}, Уровень: {AccountRegistry[i].Level}, Уникальный номер: {AccountRegistry[i].Id}, Статус блокировки : {AccountRegistry[i].IsAccountBlock}");
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
                for (int i = 0; i <= AccountRegistry.Count; i++)
                {
                    if (AccountRegistry.ContainsKey(i))
                    {
                        Console.WriteLine($"  Имя: {AccountRegistry[i].Name}, Ник: {AccountRegistry[i].Nickname}, Уровень: {AccountRegistry[i].Level}, Уникальный номер: {AccountRegistry[i].Id}, Статус блокировки : {AccountRegistry[i].IsAccountBlock}");
                    }
                }
            }


            Console.ReadLine();
            Console.Clear();
        }

        public void ActionOnPlayerAccount(int change)
        {
            string[] action = { "блокировку", "заблокирован", "разблокировку", "разблокирован", "удаление", "удален" };
            bool isActionCompleted = false;
            bool isActionCancell = false;
            bool isUserInputTrue = false;
            string userInput;
            string userInput2;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");
            userInput = Console.ReadLine();
            isUserInputTrue = int.TryParse(userInput, out int number);

            if (isUserInputTrue)
            {
                if (AccountRegistry.ContainsKey(number))
                {
                    Console.WriteLine($"  Имя: {AccountRegistry[number].Name}, Ник: {AccountRegistry[number].Nickname}, Уровень: {AccountRegistry[number].Level}, Уникальный номер: {AccountRegistry[number]}, Статус блокировки : {AccountRegistry[number].IsAccountBlock}");

                    if (change == 1)
                    {
                        if (AccountRegistry[number].IsAccountBlock == true)
                        {
                            Console.WriteLine($"Аккаунт уже заблокирован");
                            isActionCancell = true;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine($" Подтвердите {action[0]} (Y/N)");
                            userInput2 = Console.ReadLine();

                            if (userInput2.ToLower() == "y")
                            {
                                AccountRegistry[number].IsAccountBlock = true;
                                Console.WriteLine($" Игрок  {action[1]}!");
                                isActionCompleted = true;
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"Отменена ");
                                isActionCancell = true;
                                Console.ReadLine();
                            }

                        }

                    }

                    else if (change == 2)
                    {
                        if (AccountRegistry[number].IsAccountBlock == false)
                        {
                            Console.WriteLine($"Аккаунт уже разблокирован");
                            isActionCancell = true;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine($" Подтвердите {action[2]} (Y/N)");
                            userInput2 = Console.ReadLine();

                            if (userInput2.ToLower() == "y")
                            {
                                AccountRegistry[number].IsAccountBlock = false;
                                Console.WriteLine($" Игрок  {action[3]}!");
                                isActionCompleted = true;
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"Отменена ");
                                isActionCancell = true;
                                Console.ReadLine();
                            }

                        }

                    }

                    else if (change == 3)
                    {
                        Console.WriteLine($" Подтвердите {action[4]} (Y/N)");
                        userInput2 = Console.ReadLine();

                        if (userInput2.ToLower() == "y")
                        {
                            AccountRegistry.Remove(number);
                            Console.WriteLine($" Игрок  {action[5]}!");
                            isActionCompleted = true;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine($"Отменена ");
                            isActionCancell = true;
                            Console.ReadLine();
                        }

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

    }

    public class Player
    {
        private string _name { get; set; }
        private string _nickname { get; set; }
        private int _level { get; set; }
        private bool _isAccountBlock { get; set; }
        private int _id { get; set; }
        public string Name { get { return _name; } set { _name = value; } }
        public string Nickname { get { return _nickname; } set { _nickname = value; } }
        public int Level { get { return _level; } set { _level = value; } }
        public bool IsAccountBlock { get { return _isAccountBlock; } set { _isAccountBlock = value; } }
        public int Id { get { return _id; } set { _id = value; } }
    }
