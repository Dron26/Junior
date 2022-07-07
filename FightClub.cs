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
                battleArena.CreateFigters();
                battleArena.SelectFighter();
                battleArena.StartBattle();
                battleArena.ProcessBattle();
            }
        }
    }

    class BattleArena
    {
        private List<Fighter> _allFighters = new();
        private List<Fighter> _selectfighters = new();
        private List<string> _groupNameTypes = new();
        private bool _isSelectGame = false;
        private Fighter firstFighter;
        private Fighter secondFighter;
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
                    _isSelectGame = true;
                    break;
            }

            Console.Clear();
            return _isSelectGame;
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

                ShowGroupNames();
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out figtherNumber) & figtherNumber <= _groupNameTypes.Count-1)
                {

                    _selectfighters.Add(_allFighters[figtherNumber]);
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
            int countFighters=5;
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

            for (int i = 1; i <= countFighters; i++)
            {
                randomName = random.Next(0, namePlayers.Count);

                switch (i)
                {
                    case 1:
                        _allFighters.Add(new Barbarian(namePlayers[randomName]));
                        break;
                    case 2:
                        _allFighters.Add(new Monk(namePlayers[randomName]));
                        break;
                    case 3:
                        _allFighters.Add(new Magician(namePlayers[randomName]));
                        break;
                    case 4:
                        _allFighters.Add(new Sorcerer(namePlayers[randomName]));
                        break;
                    case 5:
                        _allFighters.Add(new Hunter(namePlayers[randomName]));
                        break;
                }
            }
        }

        public void StartBattle()
        {
            Random random = new();
            int first = 0;
            int second = 1;

            firstFighter = _allFighters[first];
            secondFighter = _allFighters[second];

            Console.Clear();
            first = random.Next(_allFighters.Count);

            Console.WriteLine("Атакует");
            if (first == 0)
            {
                Console.WriteLine($"{firstFighter.NameType} : {firstFighter.Name}");
                Console.WriteLine($" {firstFighter.Health}hp");
            }
            else
            {
                firstFighter = _allFighters[second];
                Console.WriteLine($"{firstFighter.NameType} : {firstFighter.Name}");
                Console.WriteLine($" {firstFighter.Health}hp");
                first = 0;
                secondFighter = _allFighters[first];
            }
        }

        public void ProcessBattle()
        {
            int damageFighter;
            Fighter tempFighter;
            int sleepTimeStep = 1500;
            int healthFirstFighter = firstFighter.Health;
            int healthSecondFighter = secondFighter.Health;
            bool isTakeDamage;

            while (healthFirstFighter > 0 & healthSecondFighter > 0)
            {
                firstFighter.ChoiceAttack();
                firstFighter.ShowAttakText();
                damageFighter = firstFighter.Damage;

                secondFighter.TakeDamage(damageFighter, out isTakeDamage);

                firstFighter.TakeAdditionalAbility(isTakeDamage);

                tempFighter = firstFighter;
                firstFighter = secondFighter;
                secondFighter = tempFighter;
                healthFirstFighter = firstFighter.Health;
                healthSecondFighter = secondFighter.Health;

                System.Threading.Thread.Sleep(sleepTimeStep);
                Console.Clear();
                if (firstFighter.Health == 0 | secondFighter.Health == 0)
                {
                    FinishBattle();
                }
                else
                {
                    Console.WriteLine("Атакует");
                    Console.WriteLine($"{firstFighter.NameType} : {firstFighter.Name}");
                    Console.WriteLine($" {firstFighter.Health}hp");
                }
            }

        }

        public void FinishBattle()
        {
            int sleepTimeDead = 2000;


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

            Console.Clear();
            Console.WriteLine("Битва окончена");
        }

        private void ShowGroupNames()
        {
            for (int i = 0; i < _allFighters.Count; i++)
            {
                Console.WriteLine($"{i} - {_allFighters[i].NameType}");
                System.Threading.Thread.Sleep(20);
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
                _groupNameTypes.Add(type);
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
            public int AbilityExpenseValue { get; protected set; }
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
                AbilityExpenseValue = 2;
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
                Damage = random.Next(DamageMinRatio, DamageMaxRatio + (AdditionalAbility / AbilityExpenseValue));
                AdditionalAbility -= (AdditionalAbility / AbilityExpenseValue);
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
            private readonly int _rage = 80;
            private readonly int _maxRage = 100;
            private readonly int _minRage = 10;

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
                AdditionalAbility = _rage;
                MaxValueAdditionalAbility = _maxRage;
                MinValueAdditionalAbility = _minRage;

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
        }

        class Monk : Fighter
        {
            private readonly int _spirit = 80;
            private readonly int _maxSpirit = 100;
            private readonly int _minSpirit = 20;
            private readonly int _maxSpiritExpenses = 60;
            private readonly int _minSpiritExpenses = 40;
            private readonly Random _random = new();
            private int _expensesAdditionalAbility;
            private bool _isAction = false;

            public Monk(string name) : base(name)
            {
                DamageMaxRatio = 70;
                DamageMinRatio = 25;
                CountTakeDamage = 2;
                HealthMaxRatio = 50;
                ArmorMaxRatio = 50;
                int HealthRatio = _random.Next(0, HealthMaxRatio);
                int ArmorRatio = _random.Next(0, ArmorMaxRatio);
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
                AdditionalAbility = _spirit;
                MaxValueAdditionalAbility = _maxSpirit;
                MinValueAdditionalAbility = _minSpirit;

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
                    if (_isAction == true)
                    {
                        Console.WriteLine($" + {_expensesAdditionalAbility}hp");
                    }
                }
            }

            public override void AdditionalAction()
            {
                Damage = 0;
                _expensesAdditionalAbility = _random.Next(_minSpiritExpenses, _maxSpiritExpenses);

                if (AdditionalAbility >= _expensesAdditionalAbility & Health > 0)
                {
                    Health += _expensesAdditionalAbility;
                    AdditionalAbility -= _expensesAdditionalAbility;
                    _isAction = true;
                }
                else if (_expensesAdditionalAbility > AdditionalAbility)
                {
                    Console.WriteLine("Недостаточно сил");
                    _isAction = false;
                }
            }
        }

        class Magician : Fighter
        {
            private readonly int _mana = 50;
            private readonly int maxMana = 100;
            private readonly int _minMana = 20;
            private readonly Random _random = new();

            public Magician(string name) : base(name)
            {
                DamageMaxRatio = 75;
                DamageMinRatio = 35;
                HealthMaxRatio = 50;
                ArmorMaxRatio = 50;
                int HealthRatio = _random.Next(0, HealthMaxRatio);
                int ArmorRatio = _random.Next(0, ArmorMaxRatio);
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
                AdditionalAbility = _mana;
                MaxValueAdditionalAbility = maxMana;
                MinValueAdditionalAbility = _minMana;

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
        }

        class Sorcerer : Fighter
        {
            private readonly int _magicalEnergy = 80;
            private readonly int _maxMagicalEnergy = 100;
            private readonly int _minMagicalEnergy = 20;
            private readonly Random _random = new();

            public Sorcerer(string name) : base(name)
            {
                DamageMaxRatio = 75;
                DamageMinRatio = 35;
                HealthMaxRatio = 40;
                ArmorMaxRatio = 40;
                int HealthRatio = _random.Next(0, HealthMaxRatio);
                int ArmorRatio = _random.Next(0, ArmorMaxRatio);
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
                AdditionalAbility = _magicalEnergy;
                MaxValueAdditionalAbility = _maxMagicalEnergy;
                MinValueAdditionalAbility = _minMagicalEnergy;

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
        }

        class Hunter : Fighter
        {
            private readonly int _hate = 80;
            private readonly int _maxHate = 100;
            private readonly int _minHate = 30;
            private readonly int _maxHateExpenses = 60;
            private readonly int _minHateExpenses = 40;
            private readonly Random _random = new();
            private int _expensesAdditionalAbility;
            private bool _isAction = false;

            public Hunter(string name) : base(name)
            {
                DamageMaxRatio = 80;
                DamageMinRatio = 40;
                HealthMaxRatio = 80;
                ArmorMaxRatio = 20;
                int HealthRatio = _random.Next(0, HealthMaxRatio);
                int ArmorRatio = _random.Next(0, ArmorMaxRatio);
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
                AdditionalAbility = _hate;
                MaxValueAdditionalAbility = _maxHate;
                MinValueAdditionalAbility = _minHate;

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
                    if (_isAction == true)
                    {
                        Console.WriteLine($" + {_expensesAdditionalAbility}hp");
                    }
                }
            }

            public override void AdditionalAction()
            {
                Damage = 0;
                _expensesAdditionalAbility = _random.Next(_minHateExpenses, _maxHateExpenses);

                if (AdditionalAbility >= _expensesAdditionalAbility & Health > 0)
                {
                    Health += _expensesAdditionalAbility;
                    AdditionalAbility -= _expensesAdditionalAbility;
                    _isAction = true;
                }
                else if (_expensesAdditionalAbility > AdditionalAbility)
                {
                    Console.WriteLine("Недостаточно сил");
                    _isAction = false;
                }
            }
        }
    }
}
