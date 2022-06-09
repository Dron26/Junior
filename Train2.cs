using System;
using System.Collections.Generic;
using System.IO;

namespace TrainDepartureConfigurator
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class ConfiguratorDirections
    {
        List<string> _cities = new List<string>();
        List<string> SelectNames = new List<string>();
        List<string> CityofDeparture = new List<string>();
        List<string> CityofArrival = new List<string>();
        List<string> TextOfMenu = new List<string>();
        public void ShowMenu()
        {
            string changeInMenu;
            bool isWorking = true;

            Console.WriteLine(TextOfMenu[0]);

            while (isWorking)
            {
                Console.WriteLine(TextOfMenu[1]);

                changeInMenu = Console.ReadLine();

                switch (changeInMenu)
                {
                    case "1":
                        RouteSelection();
                        break;
                    case "2":
                        ;
                        break;
                    case "3":
                        isWorking = false;
                        break;
                }


                changeInMenu = checkErrors.CheckError(Console.ReadLine());
                if (changeInMenu == 1)
                {
                    city.CreateCities();
                    city.ChangeDeparturePoints();
                    CityofDepartureName = city.TransferDataCity(CityofDeparture, j, j);
                    CityofArrivalName = city.TransferDataCity(j, CityofDeparture, j);
                    train.CreateTrain(CityofDepartureName, CityofArrivalName);
                    train.CancelChangeTrain();
                    city.CancelChangeDeparturePoints(train.CancelChangeTrain());
                }
            }
        }

        public void CreateCities()
        {
            List<string> Cities = new List<string>();
            string filename = @"C:\Users\Home\source\repos\TrainProgram\TrainProgram\TextFile1.txt";
            FileStream file1 = new FileStream(filename, FileMode.Open);
            StreamReader reader = new StreamReader(file1);

            while (false == reader.EndOfStream)
            {
                Cities.Add(reader.ReadLine());
            }

            reader.Close();

        }

        public void RouteSelection()
        {
            string userInput;
            bool isWork = true;
            int RangList = CitysCatalog.Count;
            string PersonAnswer;            

            Console.WriteLine(TextOfMenu[2]);
            userInput = Console.ReadLine();

            int numberUserInput;
            int numberLineMenu = 3;

            while (isWork)
            {
                GetTextMenu(numberLineMenu);
                GetTextMenu(5);
                userInput = Console.ReadLine();
                FindCity(userInput);
                GetTextMenu(6);
                ShowSelectCities();
                GetTextMenu(7);
                userInput = Console.ReadLine();
                if (GetNumberCity(userInput, out numberUserInput) == false)
                {
                    GetTextMenu(8);
                    break;
                }
                else
                {

                    CityofDeparture.Add(_cities[numberUserInput]);
                    GetTextMenu(9);
                }
            }



            while (isWork)
            {
                if (int.TryParse(userInput, out int tryNumber) != true)
                {
                    isWork = false;
                }
                else
                {
                    numberLineMenu = 3;
                    SelectCity(numberLineMenu);

                    Console.WriteLine("         Введите название города прибытия");
                    PersonAnswer = Console.ReadLine();
                    FindCity(PersonAnswer);
                    ShowCityPerson();
                    Console.WriteLine("         Выберете номер города прибытия");
                    userInput = checkErrors.CheckError(Console.ReadLine());
                    CheckNumCity(userInput, RangList);
                    CityofArrival.Add(CitysCatalog[userInput]);
                    Console.WriteLine("         Города прибытия выбран");
                    Console.WriteLine($"  Город отправления - {CityofDeparture[i]}   =====>  \n   Город прибытия - {CityofArrival[i]}");
                }

            }

            else
            {
                if (userInput == 1)
                {


                }
                if (userInput == 2)
                {
                    int rand = rnd.Next(0, 1117);
                    CityofDeparture.Add(CitysCatalog[rand]);
                    rand = rnd.Next(0, 1117);
                    CityofArrival.Add(CitysCatalog[rand]);
                    Console.WriteLine($"  Город отправления - {CityofDeparture[i]}   =====>  Город прибытия - {CityofArrival[i]}");
                    Console.ReadLine();
                }

                i = +1;
            }
        }

        public void FindCity(string userInput)
        {
            foreach (var city in _cities)
            {
                int ID = 0;
                if (city.Contains(userInput))
                {
                    ID = userInput.IndexOf(city);
                    SelectNames.Add($"{ID}  {city}");
                }
            }
        }

        public void ShowSelectCities()
        {
            int i = 0;

            foreach (var selectName in SelectNames)
            {
                
                Console.WriteLine($"{i} - {selectName}");
                i++;
            }

        }

        public bool GetNumberCity(string userInput,out int numberUserInput)
        {
            numberUserInput = 0;
            string answer;
            bool isSelectTrue=false;

            if (int.TryParse(userInput, out int tryNumber) == false| tryNumber> _cities.Count| tryNumber<0)
            {
                isSelectTrue = false;
            }
            else
            {
                numberUserInput = tryNumber;
                return isSelectTrue = true;
            }
            
            return isSelectTrue;
        }

        public void SelectCity(int numberLineMenu)
        {
            
        }

        public void FillingText()
        {
            List<string> Menuline = new()
            {
                "    Добро пожаловать в Конфигуратор Пассажирских Поездов! \n  Здесь вы можете : ",
                "    1 - Cоздать новое отправление.  \n  2 - Получить информацию о графике всех отправлений.\n  3 - - Завершение работы.",
                "    Выберите направления\n\n   Для выбора направления вам необходимо указать \n  1 - Пункт отправления и пункт прибытия \n  2 - Рандомное создание",
                "           Выбор города отправления",
                "           Выбор города прибытия",
                "    Введите название города",
                "    Найдены следующие совпадения:",
                "    Выберете номер города:",
                "    Вы ввели не верные данные",
                "    Город выбран"
            };

            foreach (string line in Menuline)
            {
                TextOfMenu.Add(line);
            }
        }

        public void GetTextMenu(int topic)
        {
            ConsoleColor color = ConsoleColor.Green;
            Console.ForegroundColor = color;
            Console.WriteLine(TextOfMenu[topic]);
            Console.ResetColor();
        }

    }

    class Traim
    {

    }
    class Passenger
    {

    }

    class Ticket
    {

    }

    class Wagon
    {

    }

}
