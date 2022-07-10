using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.Work();
        }
    }

    class Zoo
    {
        private List<Valliere> _vallieres = new();
        public bool IsWork { get; private set; }

        public Zoo()
        {
            CreateValliere();
            IsWork = true;
        }

        public void Work()
        {
            Console.WriteLine("Добро пожаловать в зоопарк!\n");

            while (IsWork)
            {
                Console.WriteLine(" Нажмите (M)ap  что бы показать карту зоопарка\n");
                Console.WriteLine(" Нажмите любую другую клавишу что бы покинуть зоопарк\n");

                if (ChoiceLaunch())
                {
                    ShowMap();
                    Console.WriteLine("\n\n Нажмите (E)xite  что бы покинуть зоопарк\n\n");
                    SelectValliere();
                }
                else
                {
                    IsWork = false;
                }
            }
        }

        private bool ChoiceLaunch()
        {
            string userInput;
            userInput = Console.ReadLine().ToLower();

            Console.Clear();
            return userInput == "m";
        }

        private void SelectValliere()
        {
            string userInput;

            userInput = Console.ReadLine();
            Console.Clear();

            if (int.TryParse(userInput, out int numbervalliere) == true & numbervalliere < _vallieres.Count & numbervalliere >= 0)
            {
                _vallieres[numbervalliere].ShowAnimals();
                Console.ReadLine();
                Console.Clear();
            }
            else if (userInput.ToLower() == "e")
            {
                IsWork = false;
                Console.WriteLine("Всего хорошего!");
            }
        }

        private void ShowMap()
        {
            int count = 0;

            Console.WriteLine("Выберите вольер");

            foreach (Valliere valliere in _vallieres)
            {
                Console.WriteLine($"{count} вольер - {valliere.NameType}");
                count++;
            }
        }

        private void CreateValliere()
        {
            List<string> animalsAndScream = new()
            {
                 "Слоны", 
                 "Обезьяны",
                 "Тигры", 
                 "Попугаи", 
            };

            foreach (string type in animalsAndScream)
            {
                _vallieres.Add(new Valliere(type));
            }
        }
    }


    class Valliere
    {
        public List<Animal> _residents = new();
        public int CountAnimals { get { return _residents.Count; } }
        public string NameType { get; protected set; }
        public int NumberAnimalsInValliere { get; protected set; }

        public Valliere(string nameType)
        {
            NameType = nameType;
            int maxNumberAnimalsInValliere = 5;
            Random random = new Random();
            NumberAnimalsInValliere = random.Next(1, maxNumberAnimalsInValliere);
            CreateAnimals();
        }

        public void ShowAnimals()
        {
            Console.WriteLine("В данном вольере находятся:");
            Console.WriteLine($"{NameType}  ");

            foreach (Animal animal in _residents)
            {
                Console.WriteLine($"{animal.Name} - {animal.Gender} - издает звук  {animal.Scream }\n");
            }           
        }

        private void CreateAnimals()
        {
            for (int i = 0; i < NumberAnimalsInValliere; i++)
            {
                _residents.Add(new Animal(NameType));
            }
        }
    }

    class Animal
    {
        public int Health { get; protected set; }
        public string NameType { get; protected set; }
        public string Name { get; protected set; }
        public int HealthMaxRatio { get; protected set; }
        public string Scream { get; protected set; }
        public string Gender { get; protected set; }

        public Animal(string nameType)
        {
            Health = 50;
            NameType = nameType;
            SetGender();
            SetName();
            SetScream();
        }

        private void SetScream()
        {
            List<string> scream = new();

            scream.AddRange(new List<string>
            { 
                "Грубббххххп",
                "Ияяяяи",
                "РРРрррррааау",
            });

            Random random = new Random();
            int number = random.Next(0, scream.Count);
            Scream=scream[number];
        }

        private void SetName()
        {
            List<string> names = new()
            {
                "Аэро",
                "Арден",
                "Альф",
                "Алекс",
                "Арто",
                "Арчи",
                "Барни",
                "Барон",
                "Вилли",
                "Бруно",
                "Бинго",
                "Бумер",
                "Кэш",
                "Шеф",
                "Шериф",
                "Дизель",
                "Локи",
                "Дюк",
                "Феликс",
                "Фред",
                "Гизмо",
                "Джек",
                "Логан",
                "Локи",
                "Пеппер",
                "Поттер",
                "Руфус",
                "Римус",
                "Реми",
                "Рекс",
                "Рокси",
                "Орео",
                "Нельсон",
                "Микки",
                "Ник",
                "Ден",
                "Честер",

            };

            Random random = new Random();
            int NumbernName = random.Next(names.Count);
            Name = names[NumbernName];
        }

        private void SetGender()
        {
            Random random = new Random();
            const int maxNumberGender = 2;
            int numberGender = random.Next(maxNumberGender);

            if (numberGender == 0)
            {
                Gender = "Мальчик";
            }
            else
            {
                Gender = "Девочка";
            }
        }
    }
}
