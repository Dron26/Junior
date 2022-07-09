using System;
using System.Collections.Generic;

namespace ThePlatoonWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Battlefield battlefield = new();
            battlefield.Work();
        }
    }

    class Battlefield
    {
        private List<Country> _countries = new();

        public int CountCountiesForBattle { get; private set; }
        public int CountPlatoomInCountries { get; private set; }
        public int CountSoldierInPlatoon { get; private set; }
        public bool IsBattleContinue { get; private set; }

        public Battlefield()
        {
            CountCountiesForBattle = 2;
            CountPlatoomInCountries = 1;
            CountSoldierInPlatoon = 1;
            IsBattleContinue = true;
        }

        public void Work()
        {
            Country firstCounty = null;
            Country secondCountry = null;

            ShowMenu();

            if (ChoiceLaunch())
            {
                for (int i = 0; i < CountCountiesForBattle; i++)
                {
                    if (i == 0)
                    {
                        firstCounty = CreateCountry(i);
                    }
                    else
                    {
                        secondCountry = CreateCountry(i);
                    }
                }

                while (IsBattleContinue == true)
                {
                    Battle(firstCounty, secondCountry);
                    TryBattleEnd(firstCounty, secondCountry);
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("  Добро пожаловать на поле битвы\n\n");
            Console.WriteLine($"  Перед вами {CountCountiesForBattle} воюющих страны\n");
            Console.WriteLine("  Нажмите: ");
            Console.WriteLine("  1 - Если хотите увидеть битву\n");
            Console.WriteLine("  Другое - Выход");
        }

        private bool ChoiceLaunch()
        {
            string userInput;
            userInput = Console.ReadLine();

            Console.Clear();
            return userInput == "1";
        }

        private void Battle(Country firstCounty, Country secondCountry)
        {
            Platoon platoonFirstCounty = null;
            Platoon platoonSecondCounty = null;

            Soldier soldierFirstCountyPlatoon = new();
            Soldier soldierSecondCountyPlatoony = new();

            Soldier attackSoldier = new();
            Soldier defenderSolider = new();

            int numberPlatoonCounty = 0;
            int sleepTimeStep = 800;
            int healthAttackSoldier = 0;
            int healthDefenderSoldier = 0;
            bool isSoldierChange = false;

            platoonFirstCounty = firstCounty.GetPlatoon(numberPlatoonCounty);
            platoonSecondCounty = secondCountry.GetPlatoon(numberPlatoonCounty);
            GetCountSoldierInPlatoon(platoonFirstCounty, platoonSecondCounty);

            while (platoonFirstCounty.CountSoldiers > 0 & platoonSecondCounty.CountSoldiers > 0)
            {
                for (int i = 0; i < CountSoldierInPlatoon; i++)
                {
                    for (int j = 0; j < CountCountiesForBattle; j++)
                    {

                        soldierFirstCountyPlatoon = platoonFirstCounty.GetSoldiers(i);
                        soldierSecondCountyPlatoony = platoonSecondCounty.GetSoldiers(i);
                        healthAttackSoldier = soldierFirstCountyPlatoon.Health;
                        healthDefenderSoldier = soldierSecondCountyPlatoony.Health;

                        if (platoonFirstCounty.CountSoldiers != 0 & platoonSecondCounty.CountSoldiers != 0)
                        {
                            if (healthAttackSoldier > 0 & healthDefenderSoldier > 0)
                            {
                                ReplaeAttacker(ref attackSoldier, ref defenderSolider, ref soldierFirstCountyPlatoon, ref soldierSecondCountyPlatoony, j, ref isSoldierChange, ref healthAttackSoldier, ref healthDefenderSoldier);
                                ShowInfoBelligerentsSoldiers(firstCounty, secondCountry, attackSoldier, defenderSolider, numberPlatoonCounty);

                                attackSoldier.Attack();
                                defenderSolider.TakeDamage(attackSoldier.Damage);
                            }
                        }
                    }

                    RemoveSoldiers(platoonFirstCounty, platoonSecondCounty, attackSoldier, defenderSolider, isSoldierChange);
                    System.Threading.Thread.Sleep(sleepTimeStep);
                    Console.Clear();
                    GetCountSoldierInPlatoon(platoonFirstCounty, platoonSecondCounty);
                }
            }
            if (CountSoldierInPlatoon == 0)
            {
                IsBattleContinue = true;
            }
        }

        private void ShowInfoBelligerentsSoldiers(Country firstCounty, Country secondCountry, Soldier attackSoldier, Soldier defenderSolider, int number)
        {
            Console.WriteLine($"{attackSoldier.NameType}  из Взвода номер {number} {firstCounty.Name}");
            Console.WriteLine($"{attackSoldier.Health} hp");
            Console.WriteLine($"Атакует\n");
            Console.WriteLine($"{defenderSolider.NameType}  из Взвода номер {number} {secondCountry.Name}");
            Console.WriteLine($"{defenderSolider.Health} hp");
        }

        private Country CreateCountry(int count)
        {
            List<string> countriesNames = new()
            {
                "Северная страна",
                "Южная страна",
            };

            return new Country(countriesNames[count], CountPlatoomInCountries, CountSoldierInPlatoon);
        }

        private void TryBattleEnd(Country firstCounty, Country secondCountry)
        {
            int fightingPlatoon = 0;
            int counWinnerPlatoonFirstCountry = 0;
            int counWinnerPlatoonSecondCountry = 0;

            if (firstCounty.GetPlatoon(fightingPlatoon).CountSoldiersInReserv == 0 & firstCounty.GetPlatoon(fightingPlatoon).CountSoldiers == 0)
            {
                counWinnerPlatoonSecondCountry++;
                firstCounty.AddToListOfDead(firstCounty.GetPlatoon(fightingPlatoon));
                Console.WriteLine($"Взвод страны {firstCounty.Name} уничтожен!");
                secondCountry.ReservingPlatoon(secondCountry.GetPlatoon(fightingPlatoon));

                TryGetWinner(secondCountry, firstCounty, counWinnerPlatoonSecondCountry, counWinnerPlatoonFirstCountry, firstCounty.CountBasePlatoom, firstCounty.CountReservingPlatoom);
            }
            else if (secondCountry.GetPlatoon(fightingPlatoon).CountSoldiersInReserv == 0 & secondCountry.GetPlatoon(fightingPlatoon).CountSoldiers == 0)
            {
                counWinnerPlatoonFirstCountry++;
                firstCounty.ReservingPlatoon(firstCounty.GetPlatoon(fightingPlatoon));
                Console.WriteLine($"Взвод страны {secondCountry.Name} уничтожен!");
                secondCountry.AddToListOfDead(secondCountry.GetPlatoon(fightingPlatoon));

                TryGetWinner(firstCounty,secondCountry, counWinnerPlatoonFirstCountry, counWinnerPlatoonSecondCountry, secondCountry.CountBasePlatoom, secondCountry.CountReservingPlatoom);
            }
            else
            {
                firstCounty.GetPlatoon(fightingPlatoon).ReturnReserve();
                secondCountry.GetPlatoon(fightingPlatoon).ReturnReserve();
                IsBattleContinue = true;
            }

            if (IsBattleContinue == true)
            {
                Console.WriteLine("У войск остались резервы, битва продолжается!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void RemoveSoldiers(Platoon platoonFirstCounty, Platoon platoonSecondCounty, Soldier attackSoldier, Soldier defenderSolider, bool isSoldierChange)
        {
            if (defenderSolider.Health == 0 & isSoldierChange)
            {
                platoonFirstCounty.AddToListOfDead(defenderSolider);
                platoonSecondCounty.ReservingSolder(attackSoldier);
            }
            else if (defenderSolider.Health == 0)
            {
                platoonSecondCounty.AddToListOfDead(defenderSolider);
                platoonFirstCounty.ReservingSolder(attackSoldier);
            }
        }

        private void RemovePlatoon(Country firstCounty, Country secondCountry)
        {
            if (firstCounty.CountReservingPlatoom != 0)
            {
                firstCounty.ReturnPlatoon();
            }
            else if (secondCountry.CountReservingPlatoom != 0)
            {
                secondCountry.ReturnPlatoon();
            }
        }

        private void ReplaeAttacker(ref Soldier attackSoldier, ref Soldier defenderSolider, ref Soldier soldierFirstCountyPlatoon, ref Soldier soldierSecondCountyPlatoony, int number, ref bool isSoldierChange, ref int healthAttackSoldier, ref int healthDefenderSoldier)
        {
            if (number == 0)
            {
                attackSoldier = soldierFirstCountyPlatoon;
                defenderSolider = soldierSecondCountyPlatoony;
                isSoldierChange = false;
            }
            else
            {
                attackSoldier = soldierSecondCountyPlatoony;
                defenderSolider = soldierFirstCountyPlatoon;
                isSoldierChange = true;
            }

            healthAttackSoldier = attackSoldier.Health;
            healthDefenderSoldier = defenderSolider.Health;
        }

        private void GetCountSoldierInPlatoon(Platoon platoonFirstCounty, Platoon platoonSecondCounty)
        {
            if (platoonFirstCounty.CountSoldiers > platoonSecondCounty.CountSoldiers)
            {
                CountSoldierInPlatoon = platoonSecondCounty.CountSoldiers;
            }
            else
            {
                CountSoldierInPlatoon = platoonFirstCounty.CountSoldiers;
            }
        }
   
        private void TryGetWinner(Country secondCountry,Country firstCounty, int counWinnerPlatoonSecondCountry ,int counWinnerPlatoonFirstCountry ,int CountBasePlatoom, int CountReservingPlatoom)
        {
            if (counWinnerPlatoonSecondCountry > counWinnerPlatoonFirstCountry & firstCounty.CountBasePlatoom == 0 & firstCounty.CountReservingPlatoom == 0)
            {
                Console.WriteLine($"Битва завершена победила  {secondCountry.Name } ");
                Console.ReadLine();
                IsBattleContinue = false;
            }
            else
            {
                Console.WriteLine("У войск остались резервы, битва продолжается!");
                RemovePlatoon(firstCounty, secondCountry);
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    class Country
    {
        private List<Platoon> _basePlatoons = new();
        private List<Platoon> _reservingPlatoons = new();
        private List<Platoon> _deadPlatoons = new();

        public string Name { get; protected set; }
        public int CountSoldiersInPlatoon { get; protected set; }
        public int CountBasePlatoom { get { return _basePlatoons.Count; } }
        public int CountReservingPlatoom { get { return _reservingPlatoons.Count; } }
        public int CountPlatoom { get; protected set; }
        public Country(string name, int count, int number)
        {
            Name = name;
            CountSoldiersInPlatoon = number;
            CountPlatoom = count;
            CreatePlatoons();
        }

        private void CreatePlatoons()
        {
            for (int i = 0; i < CountPlatoom; i++)
            {
                _basePlatoons.Add(new Platoon(CountSoldiersInPlatoon));
            }
        }

        public Platoon GetPlatoon(int numberPlatoon)
        {
            Platoon selectplatoon;
            selectplatoon = _basePlatoons[numberPlatoon];
            return selectplatoon;
        }

        public void ReservingPlatoon(Platoon platoon)
        {
            int number = _basePlatoons.IndexOf(platoon);

            _reservingPlatoons.Add(platoon);
            _basePlatoons.RemoveAt(number);
        }

        public void AddToListOfDead(Platoon platoon)
        {
            int number = _basePlatoons.IndexOf(platoon);

            _deadPlatoons.Add(platoon);
            _basePlatoons.RemoveAt(number);
        }
        public void ReturnPlatoon()
        {
            _basePlatoons.AddRange(_reservingPlatoons);
            _reservingPlatoons.Clear();
        }

    }

    class NorthernCountry : Country
    {
        public NorthernCountry(string name, int count, int number) : base(name, count, number)
        {
        }
    }

    class SouthCountry : Country
    {
        public SouthCountry(string name, int count, int number) : base(name, count, number)
        {
        }
    }

    class Platoon
    {
        private List<Soldier> BaseSoldiers = new();
        private List<Soldier> ReservingSolders = new();
        private List<Soldier> DeadSolders = new();

        public int CountSoldiers { get { return BaseSoldiers.Count; } }
        public int CountSoldiersInReserv { get { return ReservingSolders.Count; } }
        public Platoon(int countSoldiers)
        {
            CreateSoldiers(countSoldiers);
        }

        private void CreateSoldiers(int countSoldiers)
        {
            Random random = new();
            int countTypeSolier = 2;

            for (int i = 0; i < countSoldiers; i++)
            {
                int number = random.Next(0, countTypeSolier);
                if (number == 1)
                {
                    BaseSoldiers.Add(new Swordsman());
                }
                else
                {
                    BaseSoldiers.Add(new Archer());
                }
            }
        }

        public Soldier GetSoldiers(int number)
        {
            Soldier selectSoldier;
            selectSoldier = BaseSoldiers[number];
            return selectSoldier;
        }

        public void AddToListOfDead(Soldier soldier)
        {
            int number = BaseSoldiers.IndexOf(soldier);

            Console.WriteLine("Солдат погиб!");
            DeadSolders.Add(soldier);
            BaseSoldiers.RemoveAt(number);
        }

        public void ReservingSolder(Soldier sldier)
        {
            int number = BaseSoldiers.IndexOf(sldier);

            ReservingSolders.Add(sldier);
            BaseSoldiers.RemoveAt(number);
        }

        public void ReturnReserve()
        {
            BaseSoldiers.AddRange(ReservingSolders);
            ReservingSolders.Clear();
        }
    }

    class Soldier
    {
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }
        public int DamageMaxRatio { get; protected set; }
        public int DamageMinRatio { get; protected set; }
        public int HealthMaxRatio { get; protected set; }
        public int ArmorMaxRatio { get; protected set; }
        public int CountTakeDamage { get; protected set; }
        public int MaxCountTakeDamage { get; protected set; }
        public string NameType { get; protected set; }

        public Soldier()
        {
            Health = 50;
            Damage = 10;
            Armor = 0;
            CountTakeDamage = 0;
            MaxCountTakeDamage = 3;
        }

        public void Attack()
        {
            Random random = new();
            Damage = random.Next(DamageMinRatio, DamageMaxRatio);
            Console.WriteLine($" - {Damage} hp\n\n\n");
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
    }

    class Swordsman : Soldier
    {
        public Swordsman()
        {
            Random random = new();
            DamageMaxRatio = 80;
            DamageMinRatio = 30;
            HealthMaxRatio = 80;
            ArmorMaxRatio = 30;

            int healthRatio = random.Next(0, HealthMaxRatio);
            int armorRatio = random.Next(0, ArmorMaxRatio);

            NameType = "Мечник";
            Health += healthRatio;
            Armor += armorRatio;
        }
    }

    class Archer : Soldier
    {
        public Archer()
        {
            Random random = new();
            DamageMaxRatio = 50;
            DamageMinRatio = 20;
            HealthMaxRatio = 100;
            ArmorMaxRatio = 50;

            int healthRatio = random.Next(0, HealthMaxRatio);
            int armorRatio = random.Next(0, ArmorMaxRatio);

            NameType = "Лучник";
            Health += healthRatio;
            Armor += armorRatio;
        }
    }
}
