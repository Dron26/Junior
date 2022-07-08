using System;
using System.Collections.Generic;

namespace Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new();
            aquarium.ShowMenu();

            if (aquarium.ChoiceLaunch() == true)
            {
                while (aquarium._isWork)
                {
                    aquarium.Observe();
                    aquarium.ChoiceAction();
                }
            }
        }
    }

    class Aquarium
    {
        private readonly int _coutFish = 15;
        private List<Fish> _groupFish = new();
        private List<string> _groupNames = new();
        private Random _random = new();
        public bool _isWork { get; private set; }

        public Aquarium()
        {
            int numberName;
            string nameFish;
            _isWork = true;
            FillGroupNameTypes();

            for (int i = 0; i <= _coutFish; i++)
            {
                _groupFish.Add(new Fish(nameFish = _groupNames[numberName = _random.Next(0, _groupNames.Count)]));
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Нажмите");
            Console.WriteLine("1 -  Чтобы понаблюдать за аквариумом ");
            Console.WriteLine("2 -  Выход ");
        }

        public bool ChoiceLaunch()
        {
            string userInput = Console.ReadLine();
            Console.Clear();
            return userInput == "1";
        }

        public void Observe()
        {
            ConsoleKeyInfo key;
            int cursorPositionX = 2;
            int cursorPositionY = 5;
            int sleepTime = 300;

            while (Console.KeyAvailable == false & _isWork == true)
            {
                while (Console.KeyAvailable == false)
                {
                    Console.WriteLine("Нажмите");
                    Console.WriteLine("1 -  Чтобы добавить рыбку");
                    Console.WriteLine("2 -  Чтобы взять сачек и выловить рыбку");
                    Console.WriteLine("3 -  Выход ");
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(cursorPositionX, cursorPositionY);

                    if (_groupFish.Count == 0)
                    {
                        Console.WriteLine("Аквариум пуст!");
                    }
                    else
                    {
                        Console.WriteLine("Перед Вами аквариум и его обитатели:\n\n");
                    }
                    ShowFish();
                    System.Threading.Thread.Sleep(sleepTime);
                    DeleteDeadFish();
                    LiveDay();
                    Console.Clear();
                }
                Console.CursorVisible = true;
            }
        }

        public bool ChoiceAction()
        {
            string userInput;
            userInput = Console.ReadLine();

            Console.Clear();

            switch (userInput)
            {
                case "1":
                    CreateFish();
                    break;
                case "2":
                    GiveAwayFish();
                    break;
                case "3":
                    _isWork=StopObserve();
                    break;
            }

            return _isWork;
        }

        private void GiveAwayFish()
        {
            int numberFish;

            if (_groupFish.Count == 0)
            {
                Console.WriteLine("Аквариум пуст, суши свчек");
            }
            else
            {
                numberFish = _random.Next(0, _groupFish.Count);
                Console.WriteLine($"Вы выловили рыбку:{_groupFish[numberFish].Name} ");
                _groupFish.RemoveAt(numberFish);
            }

            Console.ReadLine();
            Console.Clear();
        }

        private void LiveDay()
        {
            int day = 1;

            foreach (Fish fish in _groupFish)
            {
                fish.IncreasingAge(day);
                fish.SetStatusHealth();
            }
        }

        private void CreateFish()
        {
            int numberName;
            string nameFish;

            if (_groupFish.Count == _coutFish)
            {
                Console.WriteLine("Аквариум полон, больше нельзя добавить");
            }
            else
            {
                numberName = _random.Next(0, _groupNames.Count);
                nameFish = _groupNames[numberName];
                _groupFish.Add(new Fish(nameFish));
                Console.WriteLine($"Вы добавили рыбку:{_groupFish[_groupFish.Count - 1].Name} ");
            }

            Console.ReadLine();
            Console.Clear();
        }

        private void ShowFish()
        {
            foreach (Fish fish in _groupFish)
            {
                Console.WriteLine($"  {fish.Name}\n  возраст: { fish.Age} дней   на вид состояние  { fish.HealthStatus} \n");
            }
        }

        private void FillGroupNameTypes()
        {
                _groupNames.AddRange(new List<string> 
                {
                    "Петушок",
                    "Скалярия",
                    "Барбусы",
                    "Данио",
                    "Анциструс",
                    "Тернеция",
                    "Моллинезия",
                    "Гуппи",
                    "Акары",
                    "Рыба-попугай",
                    "Коридорас",
                    "Пецилия",
                    "Астронотус",
                    "Неоны",
                    "Рыба-клоун",
                    "Цихлазомы",
                    "Меченосец",
                    "Золотая, рыбка",
                    "Боции",
                    "Гурами",
                    "Лялиус",
                    "Тетраодон",
                    "Телескоп",
                    "Апистограмма",
                    "Сиамский, водорослеед",
                    "Дискус",
                    "Птеригоплихт",
                    "Цихлазома, северум",
                    "Вуалехвост",
                    "Глофиш, (GloFish)",
                    "Макропод",
                    "Торакатум",
                    "Лабео",
                    "Данио-рерио",
                    "Барбус, суматранский",
                    "Хромис-красавец",
                    "Пельвикахромис, пульхер",
                    "Акара, бирюзовая",
                    "Радужницы",
                    "Комета",
                    "Моллинезия, черная",
                    "Голубой, дельфин",
                    "Апистограмма, Рамирези",
                    "Гурами, мраморный",
                    "Синодонтис",
                    "Гурами, жемчужный",
                    "Акантофтальмус",
                    "Гуппи, Эндлера",
                    "Тетры",
                    "Псевдотрофеусы",
                });
        }

        private bool StopObserve()
        {
            return  _isWork=false;
        }

        private void DeleteDeadFish()
        {
            int number = _groupFish.Count;

            for (int i = 0; i < number; i++)
            {
                if (_groupFish[i].IsHealth == false)
                {
                    _groupFish.RemoveAt(i);
                    number = _groupFish.Count;
                }
            }
        }
    }

    class Fish
    {
        private int _maxAge = 100;
        private int _minAge = 20;

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string HealthStatus { get; private set; }
        public bool IsHealth { get; private set; }
      
        public Fish(string name)
        {
            Random random = new Random();
            _maxAge = random.Next(_maxAge - _minAge, _maxAge);
            Name = name;
            Age = random.Next(_minAge, _maxAge);
            IsHealth = true;

            SetStatusHealth();
        }

        public void SetStatusHealth()
        {
            string Great = "Отлично";
            string Normally = "Нормально";
            string Satisfactory = "Удовлетворительно";
            string Bad = "Все плохо";
            int _statusGreat = 1;
            int _statusNormally = 25;
            int _statusSatisfactory = 50;
            int _statusBad = 70;

            if (IsHealth)
            {
                if (_statusGreat < Age & Age < _statusNormally)
                {
                    HealthStatus = Great;
                }
                else if (_statusNormally < Age & Age < _statusSatisfactory)
                {
                    HealthStatus = Normally;
                }
                else if (_statusSatisfactory < Age & Age < _statusBad)
                {
                    HealthStatus = Satisfactory;
                }
                else if (_statusBad < Age)
                {
                    HealthStatus = Bad;
                }
            }
        }

        public void IncreasingAge(int number)
        {
            if (Age == _maxAge)
            {
                Dead();
            }
            else
            {
                Age += number;
            }
        }

        private void Dead()
        {
            HealthStatus = "К сожалению рыбка умерла от старости";
            IsHealth=false;
        }
    }
}
