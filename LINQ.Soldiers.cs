using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.Soldier
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
        private List<Soldier> _soldiers = new List<Soldier>();
        public Barrack()
        {
            Random random = new Random();

            int countSoldiers = 15;
            int numberName;
            int numberSurname;
            string fullName;
            int numberWeapons;
            string weapon;
            int numberTitle;
            string title;
            int maxSoldierServiceLife = 12;
            DateTime soldierServiceLife = new DateTime();

            List<string> names = new List<string>()
            {
                "Александр",
                "Михаил",
                "Даниил",
                "Матвей",
                "Иван",
                "Кирилл",
                "Егор",
                "Дмитрий",
                "Роман",
                "Артем",
                "Тимофей",
                "Виктор",
                "Владимир",
                "Илья",
                "Максим",
                "Алексей",
                "Евгений",
                "Денис",
                "Ярослав",
                "Арсений",
                "Платон",
                "Никита",
                "Сергей",
                "Лев",
                "Степан",
                "Константин",
                "Мирон",
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

            for (int i = 0; i < countSoldiers; i++)
            {
                numberName = random.Next(names.Count);
                numberSurname = random.Next(surnames.Count);
                fullName = names[numberName] + " - " + surnames[numberSurname];

                numberWeapons = random.Next(weapons.Count);
                weapon = weapons[numberWeapons];

                numberTitle = random.Next(titles.Count);
                title = titles[numberTitle];

                soldierServiceLife = new DateTime(2022, 01 + random.Next(maxSoldierServiceLife), 01);

                _soldiers.Add(new Soldier(fullName, weapon, title, soldierServiceLife));
            }

        }

        public void Work()
        {
            var selectParametrsSoldiers = _soldiers.Select(soldier => new { soldier.FullName, soldier.Title }).ToList();

            foreach (var soldier in selectParametrsSoldiers)
            {
                Console.WriteLine($"Имя Фамилия - {soldier.FullName}  Звание - {soldier.Title}");
            }
        }
    }
    class Soldier
    {
        public string FullName { get; protected set; }
        public string Weapon { get; protected set; }
        public string Title { get; protected set; }
        public DateTime ServiceLife { get; protected set; }

        public Soldier(string fullName, string weapon, string title, DateTime serviceLife)
        {
            FullName = fullName;
            Weapon = weapon;
            Title = title;
            ServiceLife = serviceLife;
        }
    }
}

