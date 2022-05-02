using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayerBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            int idAccount = 0;
            Dictionary<int, ServiceDictionaryPlayersInfo> AccountRegistry = new Dictionary<int, ServiceDictionaryPlayersInfo>();
            Player player = new Player();
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
                        player.CreateAccount(ref idAccount, AccountRegistry);
                        break;
                    case "2":
                        service.FindAccount(AccountRegistry);
                        break;
                    case "3":
                        service.ShowAllAccount(AccountRegistry);
                        break;
                    case "4":
                        service.ActionOnPlayerAccount(AccountRegistry, changeAction = 1);
                        break;
                    case "5":
                        service.ActionOnPlayerAccount(AccountRegistry, changeAction = 2);
                        break;
                    case "6":
                        service.ActionOnPlayerAccount(AccountRegistry, changeAction = 3);
                        break;
                    case "7":
                        isWorking = false;
                        break;
                }

            }

        }

    }

    class Player
    {
        private int maxLengthName = 20;
        private int minLevel = 1;
        private int maxLevel = 100;

        public void CreateAccount(ref int idAccount, Dictionary<int, ServiceDictionaryPlayersInfo> AccountRegistry)
        {
            Service service = new Service();
            List<string> listSymbolBlock = new List<string> { "~", "!", "@", "#", "$", "%", "^", "&" };
            string name = null;
            string nickname;
            int level;
            bool isAccountBlock;
            bool isTrue = false;

            while (isTrue == false)
            {
                Console.Clear();
                Console.WriteLine("Введите имя игрока");
                name = service.CheckInput(Console.ReadLine(), maxLengthName, listSymbolBlock, minLevel, maxLevel, out isTrue);
                Console.WriteLine("Введите ник игрока");
                nickname = service.CheckInput(Console.ReadLine(), maxLengthName, listSymbolBlock, minLevel, maxLevel, out isTrue);
                Console.WriteLine("Введите уровень игрока");
                level = Convert.ToInt32(service.CheckInput(Console.ReadLine(), maxLengthName, listSymbolBlock, minLevel, maxLevel, out isTrue));
                isAccountBlock = false;
                AccountRegistry.Add(idAccount, new ServiceDictionaryPlayersInfo { Name = name, Nickname = nickname, Level = level, StatusAccountBlock = isAccountBlock, Id = idAccount });
                Console.Clear();
                Console.WriteLine($"  Имя - { name }\n  Ник - {nickname}\n  Уровень - {level}");
                Console.WriteLine("Данные сохранены");
                idAccount++;
                Console.ReadLine();
                Console.Clear();
            }

        }

    }

    class Service
    {
        public string CheckInput(string value, int maxLengthName, List<string> blockSymbol, int minLevel, int maxLevel, out bool isTrue)
        {
            isTrue = false;

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

        public void FindAccount(Dictionary<int, ServiceDictionaryPlayersInfo> AccountRegistry)
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

                for (int i = 0; i < AccountRegistry.Count; i++)
                {
                    if (AccountRegistry[i].Name.Contains(userInput))
                    {
                        Console.WriteLine($"  Имя: {AccountRegistry[i].Name}, Ник: {AccountRegistry[i].Nickname}, Уровень: {AccountRegistry[i].Level}, Уникальный номер: {AccountRegistry[i].Id}, Статус блокировки : {AccountRegistry[i].StatusAccountBlock}");
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

                for (int i = 0; i < AccountRegistry.Count; i++)
                {
                    if (AccountRegistry[i].Nickname.Contains(userInput))
                    {
                        Console.WriteLine($"  Имя: {AccountRegistry[i].Name}, Ник: {AccountRegistry[i].Nickname}, Уровень: {AccountRegistry[i].Level}, Уникальный номер: {AccountRegistry[i].Id}, Статус разблокировки : {AccountRegistry[i].StatusAccountBlock}");
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

        public void ShowAllAccount(Dictionary<int, ServiceDictionaryPlayersInfo> AccountRegistry)
        {
            Console.Clear();

            for (int i = 0; i < AccountRegistry.Count; i++)
            {
                Console.WriteLine($"  Имя: {AccountRegistry[i].Name}, Ник: {AccountRegistry[i].Nickname}, Уровень: {AccountRegistry[i].Level}, Уникальный номер: {AccountRegistry[i].Id}, Статус блокировки : {AccountRegistry[i].StatusAccountBlock}");
            }

            Console.ReadLine();
            Console.Clear();
        }

        public void ActionOnPlayerAccount(Dictionary<int, ServiceDictionaryPlayersInfo> AccountRegistry, int change)
        {
            string[] action = { "блокировку", "заблокирован", "разблокировку", "разблокирован", "удаление", "удален" };
            bool isActionCompleted = false;
            bool isActionCancell = false;
            string userInput;

            Console.Clear();
            Console.WriteLine(" Ввдите уникальный номер/Id игрока : ");
            userInput = Console.ReadLine();

            for (int i = 0; i < AccountRegistry.Count; i++)
            {
                int z = AccountRegistry[i].Id;

                if (AccountRegistry[i].Id.Equals(Convert.ToInt32(userInput)))
                {
                    Console.WriteLine($"  Имя: {AccountRegistry[i].Name}, Ник: {AccountRegistry[i].Nickname}, Уровень: {AccountRegistry[i].Level}, Уникальный номер: {AccountRegistry[i].Id}, Статус блокировки : {AccountRegistry[i].StatusAccountBlock}");

                    if (change == 1)
                    {
                        if (AccountRegistry[i].StatusAccountBlock == true)
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
                                AccountRegistry[i].StatusAccountBlock = true;
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
                        if (AccountRegistry[i].StatusAccountBlock == false)
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
                                AccountRegistry[i].StatusAccountBlock = false;
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
                            AccountRegistry.Remove(i);
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

    class ServiceDictionaryPlayersInfo
    {
        public string Name;
        public string Nickname;
        public int Level;
        public bool StatusAccountBlock;
        public int Id;
    }

}
