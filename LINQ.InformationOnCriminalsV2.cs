using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.InformationOnCriminals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database criminalBase = new Database();
            criminalBase.Work();
        }
    }

    class Database
    {
        private List<Felon> _felons = new List<Felon>();
        private string _articleAmnesty;
        public Database()
        {
            Random random = new Random();
            int numberName;
            int numberSurname;
            int numberArticle;
            int countFelon = 15;

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

            List<string> articlesViolate = new List<string>()
            {
                "Кража",
                "Мошенничество",
                "Антиправительственное"
            };

            _articleAmnesty = articlesViolate[2];

            for (int i = 0; i < countFelon; i++)
            {

                numberName = random.Next(names.Count);
                numberSurname = random.Next(surnames.Count);
                numberArticle = random.Next(articlesViolate.Count); ;

                _felons.Add(new Felon(names[numberName], surnames[numberSurname], articlesViolate[numberArticle]));
            }
        }

        public void Work()
        {

            Console.WriteLine("  Да здравствует Амнистия ! \n\n  1 - Провести Амнистию   \n  Любая другая кнопка - Выход");

            switch (Console.ReadLine())
            {
                case "1":
                    StartAmnesty();
                    break;
                default:
                    break;
            }
            Console.WriteLine("\n  Нажмите любую кнопку для завершения работы рограммы");
            Console.ReadLine();
            Console.Clear();
        }

        private List<Felon> SelectFelons()
        {
            Console.Clear();
            ShowFelons(_felons);

            var findFelons = from Felon felon in _felons
                             where felon.ArticleViolate == _articleAmnesty
                             select felon;
            return findFelons.ToList();
        }

        private void StartAmnesty()
        {
            List<Felon> selectFelons = SelectFelons();

            for (int i = 0; i < selectFelons.Count; i++)
            {
                if (_felons.Contains(selectFelons[i]))
                {
                    _felons.RemoveAt(_felons.IndexOf(selectFelons[i]));
                }
            }

            Console.WriteLine("Амнистия произведена!");
            ShowFelons(_felons);
        }


        private void ShowFelons(List<Felon> felons)
        {
            int sleepTimeStep = 2000;
            Console.Clear();

            if (felons.Count > 0)
            {
                Console.WriteLine("\n Список осужденных лиц и сатус их заключения");

                foreach (Felon felon in felons)
                {

                    Console.WriteLine($"\n  Name: {felon.Name}   Surname: {felon.Surname}   Article: {felon.ArticleViolate}");
                }
            }
            else
            {
                Console.WriteLine($"Осужденных по статье {_articleAmnesty} нет");
            }

            System.Threading.Thread.Sleep(sleepTimeStep);
        }
    }

    class Felon
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string ArticleViolate { get; private set; }

        public Felon(string name, string surname, string articleViolate)
        {
            Name = name;
            Surname = surname;
            ArticleViolate = articleViolate;
        }
    }
}