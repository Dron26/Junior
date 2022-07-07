using System;
using System.Collections.Generic;

namespace FightClub
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BattleArena battleArena = new();
            battleArena.ShowMenu();

            if (battleArena.ChoiceLaunch())
            {
                battleArena.SelectFighter();
                battleArena.CreateFigters();
                battleArena.StartBattel();
            }
        }
    }

    class BattleArena
    {
        List<string> GroupNameTypes = new();
        bool isSelectGame = false;

        private readonly List<Fighter> fighters = new();
        private readonly List<int> selectNumbers = new();

        public BattleArena()
        {
            FillGroupNameTypes();
        }

        public void ShowMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Добро пожаловать в бойцовский клуб");
            Console.WriteLine("1 - Играть");
            Console.WriteLine("Другое - Выход");
        }

        public bool ChoiceLaunch()
        {
            string userInput;
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    isSelectGame = true;
                    break;
            }

            Console.Clear();
            return isSelectGame;
        }

        public void SelectFighter()
        {
            string userInput;
            int figtherNumber;
            int countFighters = 2;
            int count = 0;

            Console.Clear();
            Console.WriteLine($"Выбирите двух бойцов для битвы");

            while (count != countFighters)
            {
                Console.WriteLine($"Выбирите бойца");
                ShowList(GroupNameTypes);
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out figtherNumber) & figtherNumber <= GroupNameTypes.Count)
                {

                    selectNumbers.Add(figtherNumber);
                    count++;
                }
                else
                {
                    Console.WriteLine("Вы допустили ошибку в выборе! попробуйте повторить.");
                    Console.ReadLine();
                }

                Console.Clear();
            }
        }

        public void CreateFigters()
        {
            Random random = new();
            List<string> namePlayers = new()
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
            int randomName;

            foreach (int number in selectNumbers)
            {
                randomName = random.Next(0, namePlayers.Count - 1);

                switch (number)
                {
                    case 1:
                        fighters.Add(new Barbarian(namePlayers[randomName]));
                        break;
                    case 2:
                        fighters.Add(new Monk(namePlayers[randomName]));
                        break;
                    case 3:
                        fighters.Add(new Magician(namePlayers[randomName]));
                        break;
                    case 4:
                        fighters.Add(new Sorcerer(namePlayers[randomName]));
                        break;
                    case 5:
                        fighters.Add(new Hunter(namePlayers[randomName]));
                        break;
                }
            }
        }

        public void StartBattel()
        {
            Random random = new();
            bool isTakeDamage;
            int first = 0;
            int second = 1;
            int damageFighter;
            Fighter firstFighter = fighters[first];
            Fighter secondFighter = fighters[second];
            Fighter tempFighter;
            int healthFirstFighter = firstFighter.Health;
            int healthSecondFighter = secondFighter.Health;
            int sleepTimeStep=1500;
            int sleepTimeDead = 2000;

            Console.Clear();
            first = random.Next(fighters.Count);

            Console.WriteLine("Атакует");
            if (first == 0)
            {
                Console.WriteLine($"{firstFighter.NameType} : {firstFighter.Name}");
                Console.WriteLine($" {firstFighter.Health}hp");
            }
            else
            {
                firstFighter = fighters[second];
                Console.WriteLine($"{firstFighter.NameType} : {firstFighter.Name}");
                Console.WriteLine($" {firstFighter.Health}hp");
                first = 0;
                secondFighter = fighters[first];
            }

            while (healthFirstFighter > 0 & healthSecondFighter > 0)
            {
                firstFighter.ChoiceAttack();
                firstFighter.ShowAttakText();
                damageFighter = fighters[first].Damage;

                secondFighter.TakeDamage(damageFighter, out isTakeDamage);

                firstFighter.TakeAdditionalAbility(isTakeDamage);

                tempFighter = firstFighter;
                firstFighter = secondFighter;
                secondFighter = tempFighter;
                healthFirstFighter = firstFighter.Health;
                healthSecondFighter = secondFighter.Health;

                System.Threading.Thread.Sleep(sleepTimeStep);
                Console.Clear();

                if (firstFighter.Health <= 0)
                {
                    Console.WriteLine($"{firstFighter.NameType} :{firstFighter.Name} Погиб!");
                    System.Threading.Thread.Sleep(sleepTimeDead);
                    Console.Clear();
                    Console.WriteLine($"{secondFighter.NameType} :{secondFighter.Name} Победил!");
                    System.Threading.Thread.Sleep(sleepTimeDead);
                }
                else if (secondFighter.Health <= 0)
                {
                    Console.WriteLine($"{secondFighter.NameType} :{secondFighter.Name} Погиб!");
                    System.Threading.Thread.Sleep(sleepTimeDead);
                    Console.Clear();
                    Console.WriteLine($"{firstFighter.NameType} :{firstFighter.Name} Победил!");
                    System.Threading.Thread.Sleep(sleepTimeDead);
                }
                else
                {
                    Console.WriteLine("Атакует");
                    Console.WriteLine($"{firstFighter.NameType} : {firstFighter.Name}");
                    Console.WriteLine($" {firstFighter.Health}hp");
                }
            }

            Console.Clear();
            Console.WriteLine("Битва окончена");
        }

        private static void ShowList(List<string> texts)
        {
            int i = 1;
            foreach (string line in texts)
            {
                Console.WriteLine($"{i} - {line}");
                System.Threading.Thread.Sleep(20);
                i++;
            }
        }

        private void FillGroupNameTypes()
        {
            List<string> groupTypes = new()
            {
                "Варвар",
                "Монах",
                "Колдун",
                "Чародей",
                "Охотник"
            };

            foreach (string type in groupTypes)
            {
                GroupNameTypes.Add(type);
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
        public int AdditionalAbility { get; protected set; }
        public int MaxValueAdditionalAbility { get; protected set; }
        public int MinValueAdditionalAbility { get; protected set; }
        public int DamageMaxRatio { get; protected set; }
        public int DamageMinRatio { get; protected set; }
        public int HealthMaxRatio { get; protected set; }
        public int ArmorMaxRatio { get; protected set; }
        public int CountTakeDamage { get; protected set; }
        public int MaxCountTakeDamage { get; protected set; }
        public int TypeAttack { get; protected set; }
        public int NumberAttack { get; protected set; }

        public string NameType { get; protected set; }

        public Fighter(string name)
        {
            Health = 400;
            Damage = 10;
            Armor = 0;
            Name = name;
            CountTakeDamage = 0;
            MaxCountTakeDamage = 3;
        }

        public void ChoiceAttack()
        {
            TypeAttack = GetChance();
            NumberAttack = GetChance();

            if (TypeAttack == 0)
            {
                BaseAttack();
            }
            else
            {
                AdditionalAction();
            }
        }
        public void BaseAttack()
        {
            Random random = new();
            Damage = random.Next(DamageMinRatio, DamageMaxRatio);
        }

        public virtual void AdditionalAction()
        {
            Random random = new();
            Damage = random.Next(DamageMinRatio, DamageMaxRatio + (AdditionalAbility / 2));
            AdditionalAbility -= (AdditionalAbility / 2);
        }

        public void TakeDamage(int damage, out bool isTakeDamage)
        {
            isTakeDamage = false;

            if (Health > damage)
            {
                if (damage == 0)
                {
                    isTakeDamage = false;
                }
                else
                {
                    Health -= damage;
                    isTakeDamage = true;
                }
            }
            else
            {
                Health = 0;
            }
        }

        public virtual void ShowAttakText()
        {

        }

        public void TakeAdditionalAbility(bool isTakeDamage)
        {
            if (isTakeDamage == true)
            {
                if (CountTakeDamage == MaxCountTakeDamage)
                {
                    if (AdditionalAbility + MinValueAdditionalAbility * MaxCountTakeDamage >= MaxValueAdditionalAbility)
                    {
                        AdditionalAbility = MaxValueAdditionalAbility;
                    }
                    else
                    {
                        AdditionalAbility += MinValueAdditionalAbility * MaxCountTakeDamage;
                    }

                    CountTakeDamage = 0;
                }
                else
                {
                    if (AdditionalAbility + MinValueAdditionalAbility >= MaxValueAdditionalAbility)
                    {
                        AdditionalAbility = MaxValueAdditionalAbility;
                    }
                    else
                    {
                        AdditionalAbility += MinValueAdditionalAbility;
                    }

                    CountTakeDamage++;
                }
            }
        }

        protected void FillAttacksLists(Dictionary<int, string> primary, Dictionary<int, string> additional)
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
    }

    class Barbarian : Fighter
    {
        private readonly int Rage = 80;
        private readonly int MaxRage = 100;
        private readonly int MinRage = 10;

        public Barbarian(string name) : base(name)
        {
            Random random = new();
            DamageMaxRatio = 80;
            DamageMinRatio = 30;
            HealthMaxRatio = 80;
            ArmorMaxRatio = 30;
            int HealthRatio = random.Next(0, HealthMaxRatio);
            int ArmorRatio = random.Next(0, ArmorMaxRatio);
            NameType = "Варвар";

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
            AdditionalAbility = Rage;
            MaxValueAdditionalAbility = MaxRage;
            MinValueAdditionalAbility = MinRage;

            FillAttacksLists(baseAttackName, additionalAttackName);
        }

        public override void ShowAttakText()
        {
            if (TypeAttack == 0)
            {
                Console.WriteLine($"Нанес: {baseAttack[NumberAttack]}");
            }
            else
            {
                Console.WriteLine($"Нанес: {additionalAttack[NumberAttack]}");
            }

            Console.WriteLine($" - { Damage}hp");
        }
        public void GetRage(bool isTakeDamage)
        {
            TakeAdditionalAbility(isTakeDamage);
        }
    }

    class Monk : Fighter
    {
        private readonly int Spirit = 80;
        private readonly int MaxSpirit = 100;
        private readonly int MinSpirit = 20;
        private readonly int MaxSpiritExpenses = 60;
        private readonly int MinSpiritExpenses = 40;
        private int ExpensesAdditionalAbility;
        private bool isAction = false;
        private readonly Random random = new();

        public Monk(string name) : base(name)
        {
            DamageMaxRatio = 70;
            DamageMinRatio = 25;
            CountTakeDamage = 2;
            HealthMaxRatio = 50;
            ArmorMaxRatio = 50;
            int HealthRatio = random.Next(0, HealthMaxRatio);
            int ArmorRatio = random.Next(0, ArmorMaxRatio);
            NameType = "Монах";

            Dictionary<int, string> baseAttackName = new()
            {
                { 0, "Точный удар посохом" },
                { 1, "Апперкот зачарованным кастетом" },
            };

            Dictionary<int, string> additionalAttackName = new()
            {
                { 0, "Сила предков" },
                { 1, "Магическая мантра" },
            };

            Health += HealthRatio;
            Armor += ArmorRatio;
            AdditionalAbility = Spirit;
            MaxValueAdditionalAbility = MaxSpirit;
            MinValueAdditionalAbility = MinSpirit;

            FillAttacksLists(baseAttackName, additionalAttackName);
        }

        public void GetSpirit(bool isTakeDamage)
        {
            TakeAdditionalAbility(isTakeDamage);
        }

        public override void ShowAttakText()
        {
            if (TypeAttack == 0)
            {
                Console.WriteLine($"Нанес: {baseAttack[NumberAttack]}");
                Console.WriteLine($" - { Damage}hp");
            }
            else
            {
                Console.WriteLine($"Нанес: {additionalAttack[NumberAttack]}");
                if (isAction == true)
                {
                    Console.WriteLine($" + {ExpensesAdditionalAbility}hp");
                }
            }
        }

        public override void AdditionalAction()
        {
            Damage = 0;
            ExpensesAdditionalAbility = random.Next(MinSpiritExpenses, MaxSpiritExpenses);

            if (AdditionalAbility >= ExpensesAdditionalAbility & Health > 0)
            {
                Health += ExpensesAdditionalAbility;
                AdditionalAbility -= ExpensesAdditionalAbility;
                isAction = true;
            }
            else if (ExpensesAdditionalAbility > AdditionalAbility)
            {
                Console.WriteLine("Недостаточно сил");
                isAction = false;
            }
        }
    }

    class Magician : Fighter
    {
        private readonly int Mana = 50;
        private readonly int MaxMana = 100;
        private readonly int MinMana = 20;
        private readonly Random random = new();

        public Magician(string name) : base(name)
        {
            DamageMaxRatio = 75;
            DamageMinRatio = 35;
            HealthMaxRatio = 50;
            ArmorMaxRatio = 50;
            int HealthRatio = random.Next(0, HealthMaxRatio);
            int ArmorRatio = random.Next(0, ArmorMaxRatio);
            NameType = "Колдун";

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
            AdditionalAbility = Mana;
            MaxValueAdditionalAbility = MaxMana;
            MinValueAdditionalAbility = MinMana;

            FillAttacksLists(baseAttackName, additionalAttackName);
        }

        public override void ShowAttakText()
        {
            if (TypeAttack == 0)
            {
                Console.WriteLine($"Нанес: {baseAttack[NumberAttack]}");
            }
            else
            {
                Console.WriteLine($"Нанес: {additionalAttack[NumberAttack]}");
            }

            Console.WriteLine($" - { Damage}");
        }

        public void GetMana(bool isTakeDamage)
        {
            TakeAdditionalAbility(isTakeDamage);
        }
    }

    class Sorcerer : Fighter
    {
        private readonly int MagicalEnergy = 80;
        private readonly int MaxMagicalEnergy = 100;
        private readonly int MinMagicalEnergy = 20;
        private readonly Random random = new();

        public Sorcerer(string name) : base(name)
        {
            DamageMaxRatio = 75;
            DamageMinRatio = 35;
            HealthMaxRatio = 40;
            ArmorMaxRatio = 40;
            int HealthRatio = random.Next(0, HealthMaxRatio);
            int ArmorRatio = random.Next(0, ArmorMaxRatio);
            NameType = "Чародей";

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
            AdditionalAbility = MagicalEnergy;
            MaxValueAdditionalAbility = MaxMagicalEnergy;
            MinValueAdditionalAbility = MinMagicalEnergy;

            FillAttacksLists(baseAttackName, additionalAttackName);
        }

        public override void ShowAttakText()
        {
            if (TypeAttack == 0)
            {
                Console.WriteLine($"Нанес: {baseAttack[NumberAttack]}");
            }
            else
            {
                Console.WriteLine($"Нанес: {additionalAttack[NumberAttack]}");
            }

            Console.WriteLine($" - { Damage}");
        }

        public void GetMagicalEnergy(bool isTakeDamage)
        {
            TakeAdditionalAbility(isTakeDamage);
        }
    }

    class Hunter : Fighter
    {
        private readonly int Hate = 80;
        private readonly int MaxHate = 100;
        private readonly int MinHate = 30;
        private readonly int MaxHateExpenses = 60;
        private readonly int MinHateExpenses = 40;
        private int ExpensesAdditionalAbility;
        private bool isAction = false;
        private readonly Random random = new();

        public Hunter(string name) : base(name)
        {
            DamageMaxRatio = 80;
            DamageMinRatio = 40;
            HealthMaxRatio = 80;
            ArmorMaxRatio = 20;
            int HealthRatio = random.Next(0, HealthMaxRatio);
            int ArmorRatio = random.Next(0, ArmorMaxRatio);
            NameType = "Охотник";

            Dictionary<int, string> baseAttackName = new()
            {
                { 0, "Арбалетный залп" },
                { 1, "Лоссо смерти" },
            };

            Dictionary<int, string> additionalAttackName = new()
            {
                { 0, "Зачарованные кровь" },
                { 1, "Черное знахарство" },
            };

            Health += HealthRatio;
            Armor += ArmorRatio;
            AdditionalAbility = Hate;
            MaxValueAdditionalAbility = MaxHate;
            MinValueAdditionalAbility = MinHate;

            FillAttacksLists(baseAttackName, additionalAttackName);
        }

        public override void ShowAttakText()
        {
            if (TypeAttack == 0)
            {
                Console.WriteLine($"Нанес: {baseAttack[NumberAttack]}");
                Console.WriteLine($" - { Damage}hp");
            }
            else
            {
                Console.WriteLine($"Нанес: {additionalAttack[NumberAttack]}");
                if (isAction == true)
                {
                    Console.WriteLine($" + {ExpensesAdditionalAbility}hp");
                }
            }
        }

        public void GetSpirit(bool isTakeDamage)
        {
            TakeAdditionalAbility(isTakeDamage);
        }

        public override void AdditionalAction()
        {
            Damage = 0;
            ExpensesAdditionalAbility = random.Next(MinHateExpenses, MaxHateExpenses);

            if (AdditionalAbility >= ExpensesAdditionalAbility & Health > 0)
            {
                Health += ExpensesAdditionalAbility;
                AdditionalAbility -= ExpensesAdditionalAbility;
                isAction = true;
            }
            else if (ExpensesAdditionalAbility > AdditionalAbility)
            {
                Console.WriteLine("Недостаточно сил");
                isAction = false;
            }
        }
    }
}
