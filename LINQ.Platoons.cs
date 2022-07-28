using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Platoons
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
            int umberFirstPlatoon = 0;
            int numberSecondPlatoon = 1;

            var selectSoldiers = _platoons[umberFirstPlatoon].GetSoldiers().Where(soldier => soldier.Name.ToUpper().StartsWith("Б")).ToList();

            for (int i = 0; i < selectSoldiers.Count; i++)
            {
                for (int j = 0; j < _platoons[umberFirstPlatoon].GetSoldiers().Count; j++)
                {
                    if (selectSoldiers[i] == _platoons[umberFirstPlatoon].GetSoldiers()[j])
                    {
                        _platoons[numberSecondPlatoon].GetSoldiers().Add(_platoons[umberFirstPlatoon].GetSoldiers()[j]);
                        _platoons[umberFirstPlatoon].GetSoldiers().RemoveAt(i);
                        j--;
                        break;
                    }                    
                }               
            }
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
            Random random = new Random();
            int numberName;
            string name;
            int numberSurname;
            string surname;
            int numberWeapons;
            string weapon;
            int numberTitle;
            string title;
            int maxSoldierServiceLife = 12;
            DateTime soldierServiceLife = new DateTime();

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

            for (int j = 0; j < countSoldiers; j++)
            {
                numberName = random.Next(names.Count);
                numberSurname = random.Next(surnames.Count);
                name = names[numberName];
                surname = surnames[numberSurname];
                numberWeapons = random.Next(weapons.Count);
                weapon = weapons[numberWeapons];

                numberTitle = random.Next(titles.Count);
                title = titles[numberTitle];

                soldierServiceLife = new DateTime(2022, 01 + random.Next(maxSoldierServiceLife), 01);

                _soldiers.Add(new Soldier(name, surname, weapon, title, soldierServiceLife));
            }

        }
    }



}

