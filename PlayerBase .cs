using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayerBase
{
    class PlayerBase
    {
        Player player = new Player();
        public void PlayersBase()
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

        public void CreateAccount(ref int idAccount)
        {
            int maxLengthName = 20;
            int minLevel = 1;
            int maxLevel = 100;
            List<string> listSymbolBlock = new List<string> { "~", "!", "@", "#", "$", "%", "^", "&" };
            string name = null;
            string nickname;
            int level;
            bool isAccountBlock;

                Console.Clear();
                Console.WriteLine("Введите имя игрока");
                name = CheckInput(Console.ReadLine(), maxLengthName, listSymbolBlock, minLevel, maxLevel);
                Console.WriteLine("Введите ник игрока");
                nickname = CheckInput(Console.ReadLine(), maxLengthName, listSymbolBlock, minLevel, maxLevel);
                Console.WriteLine("Введите уровень игрока");
                level = Convert.ToInt32(CheckInput(Console.ReadLine(), maxLengthName, listSymbolBlock, minLevel, maxLevel));
                isAccountBlock = false;
                player.AddPlayerInfo(idAccount, name, nickname, level, isAccountBlock);
                Console.Clear();
                Console.WriteLine($"  Имя - { name }\n  Ник - {nickname}\n  Уровень - {level}");
                Console.WriteLine("Данные сохранены");
                idAccount++;
                Console.ReadLine();
                Console.Clear();
        }

        public string CheckInput(string value, int maxLengthName, List<string> blockSymbol, int minLevel, int maxLevel)
        {
           bool isTrue = false;

            while (isTrue == false)
            {
                bool result = int.TryParse(value, out int number);

                if (result == false & value.Length > 0 & value.Length < maxLengthName)
                {
                    if (blockSymbol.Any(symbol => symbol == value))
                    {
                        Console.WriteLine("  Имя или ник должны содержать от 1 до 20 символов\n  Повторите ввод:");
                        value = Console.ReadLine();
                    }
                    else
                    {
                        isTrue = true;
                    }
                }
                else
                {
                    if (minLevel < Convert.ToInt32(value) || Convert.ToInt32(value) < maxLevel)
                    {
                        isTrue = true;
                    }
                    else
                    {
                        Console.WriteLine("  Уровень должен быть в диапазоне от 1 до 100\n  Повторите ввод:");
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
            Console.WriteLine("  По какому критерию будет осуществляться поиск?\n  1 - По Имени\n  2 - По Нику");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.Clear();
                Console.WriteLine("Ведите Имя");
                userInput = Console.ReadLine();

                for (int i = 0; i < player.AccountRegistry.Count; i++)
                {
                    if (player.AccountRegistry[i].Name.Contains(userInput))
                    {
                        Console.WriteLine($"  Имя: {player.AccountRegistry[i].Name}, Ник: {player.AccountRegistry[i].Nickname}, Уровень: {player.AccountRegistry[i].Level}, Уникальный номер: {player.AccountRegistry[i].Id}, Статус блокировки : {player.AccountRegistry[i].IsAccountBlock}");
                        Console.ReadLine();
                        isFinded = true;
                    }

                }

                if (isFinded == false)
                {
                    Console.WriteLine(" Игрок не найден!");
                    Console.ReadLine();
                }

            }

            else if (userInput == "2")
            {
                Console.Clear();
                Console.WriteLine("Ведите Ник");
                userInput = Console.ReadLine();

                for (int i = 0; i < player.AccountRegistry.Count; i++)
                {
                    if (player.AccountRegistry[i].Nickname.Contains(userInput))
                    {
                        Console.WriteLine($"  Имя: {player.AccountRegistry[i].Name}, Ник: {player.AccountRegistry[i].Nickname}, Уровень: {player.AccountRegistry[i].Level}, Уникальный номер: {player.AccountRegistry[i].Id}, Статус блокировки : {player.AccountRegistry[i].IsAccountBlock}");
                        Console.ReadLine();
                        isFinded = true;
                    }

                }

                if (isFinded == false)
                {
                    Console.WriteLine(" Игрок не найден!");
                    Console.ReadLine();
                }

            }

            Console.Clear();
        }

        public void ShowAllAccount()
        {
            Console.Clear();

            for (int i = 0; i < player.AccountRegistry.Count; i++)
            {
                Console.WriteLine($"  Имя: {player.AccountRegistry[i].Name}, Ник: {player.AccountRegistry[i].Nickname}, Уровень: {player.AccountRegistry[i].Level}, Уникальный номер: {player.AccountRegistry[i]}, Статус блокировки : {player.AccountRegistry[i].IsAccountBlock}");
            }

            Console.ReadLine();
            Console.Clear();
        }

        public void ActionOnPlayerAccount(int change)
        {
            string[] action = { "блокировку", "заблокирован", "разблокировку", "разблокирован", "удаление", "удален" };
            bool isActionCompleted = false;
            bool isActionCancell = false;
            string userInput;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");
            userInput = Console.ReadLine();

            for (int i = 0; i < player.AccountRegistry.Count; i++)
            {

                if (player.AccountRegistry[i].Id.Equals(Convert.ToInt32(userInput)))
                {
                    Console.WriteLine($"  Имя: {player.AccountRegistry[i].Name}, Ник: {player.AccountRegistry[i].Nickname}, Уровень: {player.AccountRegistry[i].Level}, Уникальный номер: {player.AccountRegistry[i]}, Статус блокировки : {player.AccountRegistry[i].IsAccountBlock}");

                    if (change == 1)
                    {
                        if (player.AccountRegistry[i].IsAccountBlock == true)
                        {
                            Console.WriteLine($"Аккаунт уже заблокирован");
                            isActionCancell = true;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine($" Подтвердите {action[0]} (Y/N)");
                            userInput = Console.ReadLine();

                            if (userInput.ToLower() == "y")
                            {
                                player.BlockAccount(i);
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
                        if (player.AccountRegistry[i].IsAccountBlock == false)
                        {
                            Console.WriteLine($"Аккаунт уже разблокирован");
                            isActionCancell = true;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine($" Подтвердите {action[2]} (Y/N)");
                            userInput = Console.ReadLine();

                            if (userInput.ToLower() == "y")
                            {
                                player.UnBlockAccount(i);
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
                        userInput = Console.ReadLine();

                        if (userInput.ToLower() == "y")
                        {
                            player.RemoveAccount(i);
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

            }

            if (isActionCompleted == false & isActionCancell == false)
            {
                Console.WriteLine(" Игрок не найден");
                Console.ReadLine();
            }

            Console.Clear();
        }

    }

    public class Player
    {
        private string _name { get; set; }
        private string _nickname { get; set; }
        private int _level { get; set; }
        private bool _isAccountBlock { get { return _isAccountBlock; } set { _isAccountBlock = value; } }
        private int _id { get; set; }
        public string Name { get { return _name; } }
        public string Nickname { get { return _nickname; } }
        public int Level { get { return _level; } }
        public bool IsAccountBlock { get { return _isAccountBlock; } }
        public int Id { get { return _id; } }
        private Dictionary<int, Player> _accountRegistry = new Dictionary<int, Player>();

        public Dictionary<int, Player> AccountRegistry
        {
            get { return _accountRegistry; }
        }

        public void AddPlayerInfo(int idAccount, string name, string nickname, int level, bool isAccountBlock)
        {
            _accountRegistry.Add(idAccount, new Player { _name = name, _nickname = nickname, _level = level, _isAccountBlock = isAccountBlock, _id = idAccount });
        }

        public void RemoveAccount(int idAccount)
        {
            _accountRegistry.Remove(idAccount);
        }

        public void BlockAccount(int idAccount)
        {
            _accountRegistry[idAccount]._isAccountBlock = true;
        }

        public void UnBlockAccount(int idAccount)
        {
            _accountRegistry[idAccount]._isAccountBlock = false;
        }

    }

}
