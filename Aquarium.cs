using System;
using System.Collections.Generic;

namespace Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new();
            bool isWork=true;
            aquarium.ShowMenu();

            if (aquarium.ChoiceLaunch()==true)
            {
                while (isWork==true)
                {   
                    aquarium.Observe();
                    isWork=aquarium.ChoiceAction();
                }
                
            }
        }
    }

    class Aquarium
    {

        private readonly int _coutFish=15;

        private List<Fish> _fish = new();
        private List<string> _groupNames = new();
        private Random _random = new();
        private bool _isSelectObserve = false;
        private  bool isObserve = true;
        public Aquarium()
        {
            FillGroupNameTypes();
            CreateFishForAquarium();
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
            string userInput;
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    _isSelectObserve = true;
                    break;
            }

            Console.Clear();
            return _isSelectObserve;
        }

        public void Observe()
        {
            ConsoleKeyInfo key;
            int cursorPositionX = 2;
            int cursorPositionY = 5;
            int sleepTime = 300;

            while (Console.KeyAvailable == false & isObserve == true)
            {             
                while (Console.KeyAvailable == false)
                {
                    Console.WriteLine("Нажмите");
                    Console.WriteLine("1 -  Чтобы добавить рыбку");
                    Console.WriteLine("2 -  Чтобы взять сачек и выловить рыбку");
                    Console.WriteLine("3 -  Выход ");
                    Console.CursorVisible=false;
                    Console.SetCursorPosition(cursorPositionX, cursorPositionY);
                   
                    if (_fish.Count==0)
                    {
                        Console.WriteLine("Аквариум пуст!");
                    }
                    else
                    {
                        Console.WriteLine("Перед Вами аквариум и его обитатели:\n\n");
                    }
                    ShowFish();
                    System.Threading.Thread.Sleep(sleepTime);
                    GetHealthFish();
                    LiveDay();
                    Console.Clear();
                }
                Console.CursorVisible = true;
            }

           
        }

        public bool ChoiceAction()
        {
            bool isWork=true; 
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
                        StopObserve(out isWork);
                        break;
                }
            return isWork;
        }

        public void GiveAwayFish()
        {
            int numberFish;

            if (_fish.Count==0)
            {
                Console.WriteLine("Аквариум пуст, суши свчек");
            }
            else
            {
                numberFish = _random.Next(0, _fish.Count);
                Console.WriteLine($"Вы выловили рыбку:{_fish[numberFish].Name} ");
                _fish.RemoveAt(numberFish);
            }
            
            Console.ReadLine();
            Console.Clear();
        }

        private void CreateFishForAquarium()
        {
            int numberName;
            string nameFish;

            for (int i = 0; i <= _coutFish; i++)
            {
                numberName = _random.Next(0, _groupNames.Count);
                nameFish = _groupNames[numberName];
                _fish.Add(new Fish(nameFish));
            }
        }

        public void LiveDay()
        {
            int day=1;

            foreach (Fish fish in _fish)
            {
                fish.SetAge(day);
                fish.SetStatusHealth();
            }
        }


        public void CreateFish()
        {
            int numberName;
            string nameFish;
            if (_fish.Count==_coutFish)
            {
                Console.WriteLine("Аквариум полон, больше нельзя добавить");
            }
            else
            {
                numberName = _random.Next(0, _groupNames.Count);
                nameFish = _groupNames[numberName];
                _fish.Add(new Fish(nameFish));
                Console.WriteLine($"Вы добавили рыбку:{_fish[_fish.Count - 1].Name} ");               
            }
            Console.ReadLine();
            Console.Clear();

        }

        public void ShowFish()
        {
            foreach (Fish fish in _fish)
            {
                Console.WriteLine($"  {fish.Name}\n  возраст: { fish.Age} дней   на вид состояние  { fish.HealthStatus} \n");
            }
        }

        private void FillGroupNameTypes()
        {
            List<string> groupNames = new()
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

            };

            foreach (string type in groupNames)
            {
                _groupNames.Add(type);
            }
        }

        public bool StopObserve(out bool isWork)
        {
            return isWork = false;
        }

        private void GetHealthFish()
        {
            int number = _fish.Count;

            for (int i = 0; i < number; i++)
            {
                if(_fish[i].Health == 0)
                {
                    _fish.RemoveAt(i);
                    number = _fish.Count;
                }
            }
                 
        }

    }

    class Fish
    {

        private int _maxAge =100;
        private int _minAge =20;

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string HealthStatus { get ; private set; }

        public int Health{ get ; private set; }

    private List<string> _groupHealthStatus = new();

        public Fish(string name)
        {
            Random random = new Random();
            _maxAge=random.Next(_maxAge-_minAge, _maxAge);

            Name = name;
            Age = random.Next(_minAge, _maxAge);
            Health = 1;
            FillGroupHealthStatus();
            SetStatusHealth();
        }


        private void Dead()
        {
            HealthStatus = "К сожалению рыбка умерла от старости";
            Health = 0;
        }

        private void FillGroupHealthStatus()
        {
            List<string> groupHealthStatus = new()
            {
                "Отлично",
                "Нормально",
                "Удовлетворительно",
                "Все плохо",
            };

            foreach (string type in groupHealthStatus)
            {
                _groupHealthStatus.Add(type);
            }
        }

        public void SetAge(int number)
        {
            if (Age==_maxAge)
            {
                Dead();
            }
            else
            {
                Age += number;
            }
        }

        public void SetStatusHealth()
        {
            int Great = 0;
            int Normally = 1;
            int Satisfactory = 2;
            int Bad = 3;
            int statusGreat = 1;
            int statusNormally = 25;
            int statusSatisfactory = 50;
            int statusBad = 70;
            if (Health!=0)
            {
                 if (statusGreat < Age &  Age <statusNormally)
            {
                HealthStatus = _groupHealthStatus[Great];
            }
            else if (statusNormally < Age & Age < statusSatisfactory)
            {
                HealthStatus = _groupHealthStatus[Normally];
            }
            else if (statusSatisfactory < Age & Age < statusBad)
            {
                HealthStatus = _groupHealthStatus[Satisfactory];
            }
            else if (statusBad < Age )
            {
                HealthStatus = _groupHealthStatus[Bad];
            }
            }
            
        }
    }


}
