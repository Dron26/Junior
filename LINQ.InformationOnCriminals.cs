using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.InformationOnCriminals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database criminalBase = new();
            criminalBase.Work();
        }
    }

    class Database
    {
        private List<Felon> _felons = new();

        public Database()
        {
            Random random = new();
            int numberName;
            int numberSurname;
            int numberNationality;
            int countFelon = 15;
            int maxWeight = 140;
            int minWeight = 50;
            int maxHight = 197;
            int minHight = 145;
            int weight;
            int hight;
            int maxValueForDetention = 70;
            int minValueForDetention = 50;
            int valueForDetention;
            bool isDetention = false;

            List<string> names = new()
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

            List<string> surnames = new()
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

            List<string> nationalities = new()
            {
                "Русский",
                "Татар",
                "Украинец",
                "Башкир",
                "Чуваш",
                "Белорус",
            };

            for (int i = 0; i < countFelon; i++)
            {

                numberName = random.Next(names.Count);
                numberSurname = random.Next(surnames.Count);
                numberNationality = random.Next(nationalities.Count);
                hight = random.Next(minHight, maxHight);
                weight = random.Next(minWeight, maxWeight);
                valueForDetention = random.Next(0, maxValueForDetention);

                if (valueForDetention > minValueForDetention)
                {
                    isDetention = true;
                }

                _felons.Add(new Felon(names[numberName], surnames[numberSurname], nationalities[numberNationality], hight, weight, isDetention));
            }
        }

        public void Work()
        {
            string userInput;
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("  База Данных преступников  \n  1 - Поиск преступника   \n Любая другая кнопка - Выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        FindFelons();
                        break;
                    default:
                        isWorking = false;
                        break;
                }

                Console.Clear();
            }
        }

        private void FindFelons()
        {
            Console.Clear();
            ParametrsFelon parametrs = GetParametrsFindFelon();

            if (parametrs != null)
            {
                var selectFelons = from Felon felon in _felons
                                   where felon.Nationality.Contains(parametrs.Nationality)
                                   where felon.Height <= parametrs.MaxHight & felon.Height >= parametrs.MinHight
                                   where felon.Weight <= parametrs.MaxWeight & felon.Weight >= parametrs.MinWeight
                                   where felon.IsDetention==false
                                   select felon;
                selectFelons.ToList();
                
                ShowResultFind(selectFelons.ToList());
            }
        }
        private void ShowNationality()
        {
            List<string> nationalities = new()
            {
                "Русский",
                "Татар",
                "Украинец",
                "Башкир",
                "Чуваш",
                "Белорус",
            };

            foreach (string nationality in nationalities)
            {
                Console.WriteLine($"{nationality}");
            }
        }

        private ParametrsFelon GetParametrsFindFelon()
        {
            string nationality;
            int maxWeight = 0;
            int minWeight = 0;
            int maxHight = 0;
            int minHight = 0;
            bool isUserInputNumber = false;
            ParametrsFelon parametrs = null;

            while (isUserInputNumber == false)
            {
                Console.WriteLine("  Список возможных национальностей:");

                ShowNationality();

                Console.WriteLine("  Для поиска введите национальность преступника:");

                nationality = Console.ReadLine();

                Console.WriteLine("  Введите диапазон поиска по росту, минимальный рост см :");

                isUserInputNumber = int.TryParse(Console.ReadLine(), out minHight);

                if (isUserInputNumber == true)
                {
                    Console.WriteLine("  Введите диапазон поиска по росту, максимальный рост см :");

                    isUserInputNumber = int.TryParse(Console.ReadLine(), out maxHight);
                }

                if (isUserInputNumber == true)
                {
                    Console.WriteLine("  Введите диапазон поиска по весу, минимальный вес кг :");

                    isUserInputNumber = int.TryParse(Console.ReadLine(), out minWeight);
                }

                if (isUserInputNumber == true)
                {
                    Console.WriteLine("  Введите диапазон поиска по весу, максимальный вес кг :");

                    isUserInputNumber = int.TryParse(Console.ReadLine(), out maxWeight);
                }

                if (isUserInputNumber == false)
                {
                    Console.WriteLine("  Вы ввели неверные данные");
                }
                else
                {
                    parametrs = new ParametrsFelon(nationality, minHight, maxHight, minWeight, maxWeight);
                }
            }

            Console.Clear();
            return parametrs;
        }

        private void ShowResultFind(List<Felon> resultWeight)
        {
            if (resultWeight.Count > 0)
            {
                Console.WriteLine("\n  По введенным данным есть совпадения");

                foreach (Felon felon in resultWeight)
                {
                    if (felon.IsDetention == false)
                    {
                        Console.WriteLine($"Name: {felon.Name} Surname: {felon.Surname} - Nationality:{felon.Nationality} - Height: {felon.Height} см - Weight: {felon.Weight} кг");
                    }
                }
            }
            else
            {
                Console.WriteLine("По введенным данным  совпадений нет");
            }

            Console.ReadLine();
        }
    }

    class Felon
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public bool IsDetention { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public Felon(string name, string surname, string nationality, int height, int weight, bool isDetention)
        {
            Name = name;
            Surname = surname;
            Nationality = nationality;
            Height = height;
            Weight = weight;
            IsDetention = isDetention;
        }
    }

    class ParametrsFelon
    {
        public string Nationality { get; private set; }
        public int MinHight { get; private set; }
        public int MaxHight { get; private set; }
        public int MinWeight { get; private set; }
        public int MaxWeight { get; private set; }

        public ParametrsFelon(string nationality, int minHight, int maxHight, int minWeight, int maxWeight)
        {
            Nationality = nationality;
            MinHight = minHight;
            MaxHight = maxHight;
            MinWeight = minWeight;
            MaxWeight = maxWeight;
        }
    }
}
