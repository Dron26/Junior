using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Soldiers

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Barrack barrack = new Barrack();
            barrack.Work();
        }
    }

    class Barrack
    {
        private List<Platoon> _platoons = new List<Platoon>();

        public Barrack()
        {
            CreatePlatoons();
        }

        public void Work()
        {
            int numberFirstPlatoon = 0;
            int numberSecondPlatoon = 1;

            var secondPlatoon = _platoons[numberSecondPlatoon].GetSoldiers().Union(_platoons[numberFirstPlatoon].GetSoldiers().Where(soldier => soldier.Name.ToUpper().StartsWith("Б"))).ToList();
            var firstPlatoon = _platoons[numberFirstPlatoon].GetSoldiers().Except(secondPlatoon).ToList();

            _platoons[numberFirstPlatoon].RemoveSoldiers();
            _platoons[numberSecondPlatoon].RemoveSoldiers();

            TransferSoldier(firstPlatoon.ToList(), numberFirstPlatoon);
            TransferSoldier(secondPlatoon.ToList(), numberSecondPlatoon);
        }

        private void CreatePlatoons()
        {
            int countPlatoom = 2;
            int countSoldiersInPlatoon = 15;

            for (int i = 0; i < countPlatoom; i++)
            {
                _platoons.Add(new Platoon(countSoldiersInPlatoon));
            }
        }

        private void TransferSoldier(List<Soldier> tempPlatoon,int number)
        {
            foreach (Soldier soldier in tempPlatoon)
            {
                _platoons[number].AddSoldier(soldier);
            }
        }
    }

    class Soldier
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Weapon { get; protected set; }
        public string Title { get; protected set; }
        public DateTime ServiceLife { get; protected set; }

        public Soldier(string name, string surname, string weapon, string title, DateTime serviceLife)
        {
            Name = name;
            Surname = surname;
            Weapon = weapon;
            Title = title;
            ServiceLife = serviceLife;
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers = new();
        private Random random = new Random();
        public int CountSoldiers { get { return _soldiers.Count; } }

        public Platoon(int countSoldiers)
        {
            CreateSoldiers(countSoldiers);
        }

        public List<Soldier> GetSoldiers()
        {
            List<Soldier> selectSoldier = new List<Soldier>();

            foreach (Soldier soldier in _soldiers)
            {
                selectSoldier.Add(soldier);
            }

            return selectSoldier;
        }

        private void CreateSoldiers(int countSoldiers)
        {
            string name;           
            string surname;
            string weapon;
            string title;
            int maxSoldierServiceLife = 12;
            DateTime soldierServiceLife = new DateTime();

            for (int j = 0; j < countSoldiers; j++)
            {                
                name = GetSoldierName();
                surname = GetSoldierSurname();
                weapon = GetSoldierTitles();
                title = GetSoldierWeapon();
                soldierServiceLife = new DateTime(2022, 01 + random.Next(maxSoldierServiceLife), 01);

                _soldiers.Add(new Soldier(name, surname, weapon, title, soldierServiceLife));
            }
        }

        public void RemoveSoldiers ()
        {
            _soldiers.Clear();
        }

        private string GetSoldierName()
        {
            int numberName;

            List<string> names = new List<string>()
            {
                "Александр",
                "Борис",
                "Даниил",
                "Матвей",
                "Иван",
                "Кирилл",
                "Егор",
                "Дмитрий",
                "Роман",
                "Бернар",
                "Владимир",
                "Болеслав",
                "Максим",
                "Боголюб",
                "Сергей",
                "Бахрам",
                "Степан",
                "Богдан",
                "Федор",
                "Андрей",
            };
            numberName = random.Next(names.Count);

            return names[numberName];
        }

        private string GetSoldierSurname()
        {
            int numberSurname;

            List<string> surnames = new List<string>()
            {
                "Иванов",
                "Васильев",
                "Петров",
                "Смирнов",
                "Михайлов",
                "Фёдоров",
                "Соколов",
                "Яковлев",
                "Попов",
                "Андреев",
                "Алексеев",
                "Александров",
                "Лебедев",
                "Григорьев",
                "Степанов",
            };
            
            numberSurname = random.Next(surnames.Count);

            return surnames[numberSurname];
        }

        private string GetSoldierTitles()
        {
            int numberTitle;

            List<string> titles = new List<string>()
            {
                "Рядовой",
                "Ефрейтор",
                "Младший",
                "Сержант",
                "Старший сержант",
                "Прапорщик",
                "Старший прапорщик",
                "Младший лейтенант",
                "Лейтенант",
                "Старший лейтенант",
                "Капитан",
                "Майор",
                "Подполковник",
                "Полковник",
                "Генерал-майор",
            };
            numberTitle = random.Next(titles.Count);

            return titles[numberTitle];
        }

        private string GetSoldierWeapon()
        {
            int numberWeapons;

            List<string> weapons = new List<string>()
            {
                "9-мм армейский пистолет МР-443 «Грач»",
                "5,45-мм автомат Калашникова АК-74М ",
                "7,62-мм пулемет «Печенег» ",
                "9-мм пистолет Сердюкова СПС «Гюрза» ",
                "9-мм винтовка снайперская специальная ВСС «Винторез»т",
                "5,45-мм ручной пулемет Калашникова РПК",
                "7,62-мм снайперская винтовка Драгунова СВД "
            };
            numberWeapons = random.Next(weapons.Count);

            return weapons[numberWeapons];
        }

        public void AddSoldier(Soldier soldier)
        {
            _soldiers.Add(soldier);
        }
    }
}
