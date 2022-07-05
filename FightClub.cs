using System;
using System.Collections.Generic;

namespace FightClub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayWindow playWindow = new();
            BattleArena battlearena = new();
            playWindow.ShowMenu(out bool isStarted);

            if (isStarted == true)
            {
                battlearena.ShowArena(playWindow.CreateFigter());
            }
        }
    }

    class PlayWindow
    {
        private readonly List<string> _types = new();
        private readonly int _countFighters;

        public PlayWindow()
        {
            int width = 145;
            int height = 50;
            _countFighters = 2;
            Console.SetWindowSize(width, height);
            GetTextForType();
        }

        public void ShowMenu(out bool isStarted)
        {
            PrintMenu(out isStarted);
        }

        public List<Fighter> CreateFigter()
        {
            List<string> NamePlayer = new()
            {
                "Джоли Бьорн",
                "Донат Троллебой",
                "Дуротан",
                "Забытый",
                "Зул'джин",
                "Зулухед Пришибленный",
                "Иллидан Ярость Бури",
                "Ирод",
                "Изера",
                "К'тун",
                "Каргат Острорук",
                "Кел'Тузед",
                "Кель'тас Солнечный скиталец",
                "Кенарий",
                "Кэрн Кровавое Копыто",
                "Кил'джеден",
                "Килрогг, Мёртвый, Глаз",
                "Корагг",
                "Кориалстраз",
                "Король Ллан Ринн, I",
                "Король Теренас Менетил, II",
                "Ксавий",
                "Кси'ри",
                "Леди Вайш",
                "Лор'темар Терон",
                "Магтеридон",
                "Магна Эгвинн",
                "Магни Бронзобород",
                "Мал'Ганис",
                "Малигос",
                "Малфурион Ярость Бури",
                "Маннорот",
                "Медив",
                "Мефистрот",
                "Морган Ладимор(Мор'Ладим)",
                "Мурадин Бронзобород",
                "Майев Песнь Теней",
                "Наз'грел",
                "Наиша(Ная)",
                "Нек'рош Череподробитель",
                "Некрос Череподробитель(старший)",
                "Нелтарион",
                "Нер'зул",
                "Нефариан",
                "Нилас Аран",
                "Нобундо",
                "Ноздорму",
                "Омен Неудержимый",
                "Ониксия",
                "Оргримм Молот Рока",
                "Пророк Скерам",
                "Псения Кобчак",
                "Райво из Пандарии",
                "Рексар",
                "Рено Могрэйн",
                "Рокхан",
                "Ронин",
                "Саргерас",
                "Соридорми",
                "Сапфирон",
                "Сен'джин",
                "Сикко Термоштепсель",
                "Сильвана Ветрокрылая",
                "Сталван Мистмантл",
                "Тагар Спайнбрейкер",
                "Тандред Праудмур",
                "Тарета Фокстон",
                "Тауриссан",
                "Терокк",
                "Терон Горфинд",
                "Тиранастраз",
                "Тиранда Шелест Ветра",
                "Тирион Фордринг",
                "Тихондрий",
                "Тоскан",
                "Тралл",
                "Туралион",
                "Утер Светоносный",
                "Фалстад Драгонривер",
                "Финналл Голденсорд",
                "Кадгар",
                "Хаккар Свежеватель, Душ",
                "Халдурон, Яркокрылый",
                "Хамуул Рунный тотем",
                "Хелькулар",
                "Хеминг Эрнестуэй",
                "Хьюго",
                "Чо'галл",
                "Шандрис Фезермун",
                "Эдвин ван, Клиф",
                "Эделас Блэкмур",
                "Элуна",
                "Эранику",

            };
            List<Fighter> _fighter = new();
            int selectFighter = 1;

            Console.WriteLine($"Выбирите двух бойцов для битвы");

            while (_fighter.Count != _countFighters)
            {
                Random random = new();
                int randomName = random.Next(0, NamePlayer.Count - 1);

                Console.WriteLine($"Выбирите {selectFighter} бойца");
                ShowList(_types);
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        _fighter.Add(new Barbarian(NamePlayer[randomName]));
                        break;
                    case "2":
                        _fighter.Add(new Monk(NamePlayer[randomName]));
                        break;
                    case "3":
                        _fighter.Add(new Magician(NamePlayer[randomName]));
                        break;
                    case "4":
                        _fighter.Add(new Sorcerer(NamePlayer[randomName]));
                        break;
                    case "5":
                        _fighter.Add(new Hunter(NamePlayer[randomName]));
                        break;
                }

                Console.Clear();
                selectFighter++;
            }

            return _fighter;
        }

        private static void ShowList(List<string> text)
        {
            foreach (string line in text)
            {
                Console.WriteLine(line);
                System.Threading.Thread.Sleep(20);
            }
        }

        private static void ChoiceColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        private void GetTextForType()
        {
            List<string> NameTypes = new()
            {
                "1 - Варвар",
                "2 - Монах",
                "3 - Колдун",
                "4 - Чародей",
                "5 - Охотник"
            };
            foreach (string line in NameTypes)
            {
                _types.Add(line);
            }
        }

        private void PrintMenu(out bool isStarted)
        {
            isStarted = false;
            bool isWork = true;
            int cursorPositionMenuStart = 18;
            int cursorPositionLogo = 4;
            int cursorPositionX = 0;
            ConsoleColor color;

            List<string> logo = new()
            {
                "##   ##                      ##                       #######    ##              ##         ##                ####    ###              ##",
                "##   ##                                               ##                         ##         ##               ##  ##    ##              ##",
                "### ###   ######   ######  ####      #####            ##       ####      ######  ######   ######            ##         ##     ##   ##  ######",
                "## # ##  ##   ##  ##   ##    ##     ##                #####      ##     ##   ##  ##   ##    ##              ##         ##     ##   ##  ##   ##",
                "## # ##  ##   ##  ##   ##    ##     ##                ##         ##     ##   ##  ##   ##    ##              ##         ##     ##   ##  ##   ##",
                "##   ##  ##  ###   ######    ##     ##                ##         ##      ######  ##   ##    ##               ##  ##    ##     ##  ###  ##   ##",
                "##   ##   ### ##       ##  ######    #####            ##       ######        ##  ##   ##     ###              ####    ####     ### ##  ######",
                "                    #####                                                 #####"
            };

            List<string> start = new()
            {
                "   ##                                ######   ####       ##     ##  ##          ",
                "  ###                                 ##  ##   ##       ####    ##  ##          ",
                "   ##                                 ##  ##   ##      ##  ##   ##  ##          ",
                "   ##              ######             #####    ##      ##  ##    ####           ",
                "   ##                                 ##       ##   #  ######     ##            ",
                "   ##                                 ##       ##  ##  ##  ##     ##            ",
                " ######                              ####     #######  ##  ##    ####           ",
                "",
                "",
            };

            List<string> exite = new()
            {
                "",
                " ####                               #######  ##  ##    ####    ######   ####### ",
                "##  ##                               ##      ##  ##     ##     # ## #    ##     ",
                "    ##                               ##       ####      ##       ##      ##     ",
                "  ###             ######             ####      ##       ##       ##      ####   ",
                " ##                                  ##       ####      ##       ##      ##     ",
                "##  ##                               ##      ##  ##     ##       ##      ##     ",
                "######                              #######  ##  ##    ####     ####    ####### ",
            };


            ChoiceColor(ConsoleColor.Yellow);

            while (isWork == true)
            {
                Console.SetCursorPosition(cursorPositionX, cursorPositionMenuStart);
                ShowList(start);
                ShowList(exite);
                ChoiceColor(color = ConsoleColor.Red);

                while (Console.KeyAvailable == false)
                {
                    Console.ForegroundColor = color;
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(cursorPositionX, cursorPositionLogo);

                    ShowList(logo);

                    if (color == ConsoleColor.Red)
                    {
                        color = ConsoleColor.Blue;
                    }
                    else
                    {
                        color = ConsoleColor.Red;
                    }
                }

                ChoiceColor(ConsoleColor.DarkGray);
                Console.SetCursorPosition(cursorPositionX, cursorPositionLogo);
                ShowList(logo);

                ConsoleKeyInfo key = Console.ReadKey();
                Console.SetCursorPosition(cursorPositionX, cursorPositionMenuStart);

                if (key.Key == ConsoleKey.NumPad1)
                {
                    ChoiceColor(ConsoleColor.DarkGreen);
                    ShowList(start);
                    ChoiceColor(ConsoleColor.DarkGray);
                    ShowList(exite);

                    System.Threading.Thread.Sleep(200);

                    isWork = false;
                    isStarted = true;

                    ChoiceColor(ConsoleColor.Yellow);
                }
                else if (key.Key == ConsoleKey.NumPad2)
                {
                    ChoiceColor(ConsoleColor.DarkGray);
                    ShowList(start);
                    ChoiceColor(ConsoleColor.DarkGreen);
                    ShowList(exite);

                    isWork = false;
                }
                else
                {
                    ChoiceColor(ConsoleColor.Yellow);
                }
            }

            Console.Clear();
            Console.CursorVisible = true;
        }

    }

    class BattleArena
    {
        private readonly List<string> _textOfMenu = new();

        public BattleArena()
        {
            GetTextForMenu();
        }

        public void ShowArena(List<Fighter> fighters)
        {
            Random random = new();
            int first;
            int second = 0;
            int tempNumber;
            int damage;
            int type;
            int number;
            int win;
            int loser;

            Console.Clear();
            ShowTextOfMenu(0);
            first = random.Next(fighters.Count);

            if (first == 0)
            {
                Console.WriteLine($"{fighters[0].Type} : {fighters[0].Name}");
                Console.WriteLine($" {fighters[0].Health}hp");
                second = 1;
            }
            else
            {
                Console.WriteLine($"{fighters[1].Type} : {fighters[1].Name}");
                Console.WriteLine($" {fighters[1].Health}hp");
            }

            damage = fighters[first].Attack(number = GetChance(), type = GetChance());
            fighters[first].ShowAttakText(number, type);
            fighters[second].TakeDamage(damage);

            while (fighters[0].Health > 0 & fighters[1].Health > 0)
            {
                Console.WriteLine($"- {damage}hp");

                System.Threading.Thread.Sleep(1500);
                Console.Clear();

                damage = fighters[first].Attack(number = GetChance(), type = GetChance());
                fighters[second].TakeDamage(damage);

                tempNumber = first;
                first = second;
                second = tempNumber;

                if (fighters[0].Health > 0 & fighters[1].Health > 0)
                {
                    ShowTextOfMenu(1);
                    Console.WriteLine($"{fighters[first].Type} : {fighters[first].Name}");
                    Console.WriteLine($" {fighters[first].Health}hp");
                    fighters[first].ShowAttakText(number, type);
                }
                else
                {
                    Console.Clear();

                    if (fighters[0].Health > 0)
                    {
                        win = 0;
                        loser = 1;

                    }
                    else
                    {
                        win = 1;
                        loser = 0;
                    }
                    Console.WriteLine($"{fighters[loser].Type} :{fighters[loser].Name} Погиб!");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine($"{fighters[win].Type} :{fighters[win].Name} Победил!");
                    System.Threading.Thread.Sleep(2000);
                }
            }

            Console.Clear();
            ShowTextOfMenu(2);
        }

        private static int GetChance()
        {
            Random random = new();
            int maxPerecentChance = 100;
            int halfChance = maxPerecentChance / 2;
            int chance = random.Next(maxPerecentChance);
            int type;

            if (chance < halfChance)
            {
                type = 0;
            }
            else
            {
                type = 1;
            }

            return type;
        }

        private void ShowTextOfMenu(int topic)
        {
            ConsoleColor color = ConsoleColor.Green;
            Console.ForegroundColor = color;
            Console.WriteLine($"    {_textOfMenu[topic]}");
            Console.ResetColor();
        }

        private void GetTextForMenu()
        {
            List<string> Menuline = new()
            {
                "Первый удар наносит:",
                "Удар наносит",
                "Игра окончена",
            };

            foreach (string line in Menuline)
            {
                _textOfMenu.Add(line);
            }
        }
    }

    class Fighter
    {
        protected Dictionary<int, string> baseAttack = new();

        protected Dictionary<int, string> additionalAttack = new();

        public string Name { get; private set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }
        public int DamageMaxRatio { get; protected set; }
        public int HealthMaxRatio { get; protected set; }
        public int ArmorMaxRatio { get; protected set; }
        public int CountTakeDamage { get; protected set; }
        public int MaxCountTakeDamage { get; protected set; }
        public string Type { get; protected set; }
       
        public Fighter(string name)
        {
            Health = 400;
            Damage = 10;
            Armor = 0;
            Name = name;
            CountTakeDamage = 0;
            MaxCountTakeDamage = 3;
        }

        public int Attack(int number, int type)
        {
            Random random = new();
            int damage = 0;

            if (number == 0 & type == 0 | number == 1 & type == 0)
            {
                damage = random.Next(Damage * DamageMaxRatio / 4, Damage * DamageMaxRatio);
            }
            else if (number == 0 & type == 1 | number == 1 & type == 1)
            {
                damage = random.Next(Damage * DamageMaxRatio / 2, Damage * DamageMaxRatio);
            }

            return damage;
        }

        public void TakeDamage(int damage)
        {
            if (Health > damage)
            {
                Health -= damage;
            }
            else
            {
                Health = 0;
            }
        }

        public void ShowAttakText(int number, int type)
        {
            if (type == 0)
            {
                Console.WriteLine(baseAttack[number]);
            }
            else
            {
                Console.WriteLine(additionalAttack[number]);
            }
        }

        protected void FillAttackLists(Dictionary<int, string> primary, Dictionary<int, string> additional)
        {
            foreach (var attak in primary)
            {
                baseAttack.Add(attak.Key, attak.Value);
            }

            foreach (var attak in additional)
            {
                additionalAttack.Add(attak.Key, attak.Value);
            }
        }

    }

    class Barbarian : Fighter
    {
        public Barbarian(string name) : base(name)
        {
            Random random = new();
            DamageMaxRatio = 10;
            HealthMaxRatio = 80;
            ArmorMaxRatio = 30;
            int HealthRatio = random.Next(0, HealthMaxRatio);
            int ArmorRatio = random.Next(0, ArmorMaxRatio);
            Type = "Варвар";

            Dictionary<int, string> baseAttackName = new()
            {
                { 0, "Жесткий удар секирой" },
                { 1, "Тяжелый таран корпусом" },
            };

            Dictionary<int, string> additionalAttackName = new()
            {
                { 0, "Удар двумя секирами с прыжка" },
                { 1, "Разрушительный удар Яростной секирой" },
            };

            Health += HealthRatio;
            Armor += ArmorRatio;

            FillAttackLists(baseAttackName, additionalAttackName);
        }
    }

    class Monk : Fighter
    {
        public Monk(string name) : base(name)
        {
            Random random = new();
            DamageMaxRatio = 7;
            CountTakeDamage = 2;
            HealthMaxRatio = 50;
            ArmorMaxRatio = 50;
            int HealthRatio = random.Next(0, HealthMaxRatio);
            int ArmorRatio = random.Next(0, ArmorMaxRatio);
            Type = "Монах";

            Dictionary<int, string> baseAttackName = new()
            {
                { 0, "Точный удар посохом" },
                { 1, "Апперкот зачарованным кастетом" },
            };

            Dictionary<int, string> additionalAttackName = new()
            {
                { 0, "Разряд земляных молний " },
                { 1, "Магическая мантра" },
            };

            Health += HealthRatio;
            Armor += ArmorRatio;

            FillAttackLists(baseAttackName, additionalAttackName);
        }
    }

    class Magician : Fighter
    {
        public Magician(string name) : base(name)
        {
            Random random = new();
            DamageMaxRatio = 5;
            HealthMaxRatio = 50;
            ArmorMaxRatio = 50;
            int HealthRatio = random.Next(0, HealthMaxRatio);
            int ArmorRatio = random.Next(0, ArmorMaxRatio);
            Type = "Колдун";

            Dictionary<int, string> baseAttackName = new()
            {
                { 0, "Удар жезлом" },
                { 1, "Роковое пламя" },
            };

            Dictionary<int, string> additionalAttackName = new()
            {
                { 0, "Изьятие жизни" },
                { 1, "Портал миров" },
            };

            Health += HealthRatio;
            Armor += ArmorRatio;
            FillAttackLists(baseAttackName, additionalAttackName);
        }
    }

    class Sorcerer : Fighter
    {
        public Sorcerer(string name) : base(name)
        {
            Random random = new();
            DamageMaxRatio = 7;
            HealthMaxRatio = 40;
            ArmorMaxRatio = 40;
            int HealthRatio = random.Next(0, HealthMaxRatio);
            int ArmorRatio = random.Next(0, ArmorMaxRatio);
            Type = "Чародей";

            Dictionary<int, string> baseAttackName = new()
            {
                { 0, "Огненый шар" },
                { 1, "Разряд молнией" },
            };

            Dictionary<int, string> additionalAttackName = new()
            {
                { 0, "Многократный грозовой разряд молний" },
                { 1, "Проклятие души" },
            };

            Health += HealthRatio;
            Armor += ArmorRatio;

            FillAttackLists(baseAttackName, additionalAttackName);
        }
    }

    class Hunter : Fighter
    {
        public Hunter(string name) : base(name)
        {
            Random random = new();
            DamageMaxRatio = 8;
            HealthMaxRatio = 80;
            ArmorMaxRatio = 20;
            int HealthRatio = random.Next(0, HealthMaxRatio);
            int ArmorRatio = random.Next(0, ArmorMaxRatio);
            Type = "Охотник";

            Dictionary<int, string> baseAttackName = new()
            {
                { 0, "Арбалетный залп" },
                { 1, "Лоссо смерти" },
            };

            Dictionary<int, string> additionalAttackName = new()
            {
                { 0, "Зачарованные стрелы" },
                { 1, "Черное знахарство" },
            };
            Health += HealthRatio;
            Armor += ArmorRatio;

            FillAttackLists(baseAttackName, additionalAttackName);
        }
    }

}
