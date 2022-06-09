using System;
using System.IO;
using System.Collections.Generic;

namespace TrainProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.BasicWindow();
        }
    }

    class Menu
    {
        City city = new City();
        Train train = new Train();
        int changeInMenu = 0;
        public void BasicWindow()
        {
            CheckErrors checkErrors = new CheckErrors();
            int j = -1;
            int CityCount = Convert.ToInt32(city.TransferDataCity(j, j, 1));
            int CityofDeparture = CityCount;
            int CityofArrival = CityCount;
            string CityofDepartureName = null;
            string CityofArrivalName = null;
            Console.WriteLine("  Добро пожаловать в Конфигуратор Пассажирских Поездов! \n  Здесь вы можете : ");

            while (true)
            {
                Console.WriteLine("  1 - Cоздать новое отправление.  \n  2 - Получить информацию о графике отправлений.\n  " +
                "3 - Вывести график отправлений на печать.\n  4 - Завершение работы.");

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
                if (changeInMenu == 2)
                {

                }
                if (changeInMenu == 3)
                {

                }
                if (changeInMenu == 4)
                {
                    Environment.Exit(0);
                }
            }

        }





    }
}

class City
{
    CheckErrors checkErrors = new CheckErrors();
    int changeInMenu = 0;
    List<string> CitysCatalog = new List<string>();
    List<string> CitysName = new List<string>();
    List<string> CityofDeparture = new List<string>();
    List<string> CityofArrival = new List<string>();

    public Random rnd = new Random();

    int i = 0;

    public void CreateCities()

    {
        string filename = @"C:\Users\Home\source\repos\TrainProgram\TrainProgram\TextFile1.txt";
        FileStream file1 = new FileStream(filename, FileMode.Open);//создаем файловый поток
        StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком
        while (false == reader.EndOfStream)
        {
            CitysCatalog.Add(reader.ReadLine());
        }
        //Console.WriteLine(reader.ReadToEnd()); //считываем все данные с потока и выводим на экран
        reader.Close(); //закрываем поток

    }
    public void ChangeDeparturePoints()
    {
        int RangList = CitysCatalog.Count;
        string PersonAnswer;

        Console.WriteLine("  Для создания отправления необходимо:\n * Выборать пункты отправления и прибытия\n * Сформировать и отправить поезд");
        Console.WriteLine("         Выбор направления\n\n\n   Для выбора направления вам необходимо указать \n  1 - Пункт отправления и пункт прибытия \n  2 - Рандомное создание");
        changeInMenu = checkErrors.CheckError(Console.ReadLine());
        if (changeInMenu == 1)
        {
            Console.WriteLine("         Введите название города отправления");
            PersonAnswer = Console.ReadLine();
            FindCity(PersonAnswer);
            ShowCityPerson();
            Console.WriteLine("         Выберете номер города отправления");
            changeInMenu = checkErrors.CheckError(Console.ReadLine());
            CheckNumCity(changeInMenu, RangList);
            CityofDeparture.Add(CitysCatalog[changeInMenu]);
            Console.WriteLine("         Города отправления выбран ");

            Console.WriteLine("         Введите название города прибытия");
            PersonAnswer = Console.ReadLine();
            FindCity(PersonAnswer);
            ShowCityPerson();
            Console.WriteLine("         Выберете номер города прибытия");
            changeInMenu = checkErrors.CheckError(Console.ReadLine());
            CheckNumCity(changeInMenu, RangList);
            CityofArrival.Add(CitysCatalog[changeInMenu]);
            Console.WriteLine("         Города прибытия выбран");
            Console.WriteLine($"  Город отправления - {CityofDeparture[i]}   =====>  \n   Город прибытия - {CityofArrival[i]}");

        }
        if (changeInMenu == 2)
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

    public string FindCity(string PersAnswer)
    {
        foreach (var item in CitysCatalog)
        {
            int ID = 0;
            if (item.Contains(PersAnswer))
            {
                ID = CitysCatalog.IndexOf(item);
                CitysName.Add($"{ID}  {item}");
            }
        }
        CitysName.AddRange(CitysCatalog.FindAll(o => o == PersAnswer));
        return "Найдены следующие совпадения:";
    }
    public void ShowCityPerson()
    {
        foreach (var item in CitysName)
        {
            Console.WriteLine(item);
        }

    }
    public void ShowCityForShedule()
    {
        foreach (var item in CityofDeparture)
        {
            Console.WriteLine(item);
        }

    }
    public string CheckNumCity(int changInMenu, int rangList)
    {
        string answer;
        int i = 0;
        if (changInMenu >= rangList)
        {
            if (rangList > i)
            {
                return changInMenu.ToString();
            }
        }
        return answer = "Вы ввели не верные данные";
    }

    public string TransferDataCity(int IndexCityofDeparture, int IndexCityofArrival, int CountDeparturePoints)
    {
        string x = "Ошибка";
        if (IndexCityofDeparture > -1)
        {
            return CityofDeparture[i - 1];
        }
        if (IndexCityofArrival > -1)
        {
            return CityofArrival[i - 1];
        }
        if (CountDeparturePoints > -1)
        {
            return i.ToString();
        }

        else
            return x;

    }

    public void CancelChangeDeparturePoints(bool CancelChangeTrain)
    {
        if (CancelChangeTrain == false)
        {
            CityofDeparture.RemoveAt(i);
            CityofArrival.RemoveAt(i);
        }
    }

}

class Train
{

    public Random rnd = new Random();
    int j = -1;
    int i = 0;
    List<int> TravelTime = new List<int>();
    List<int> TravelPassengers = new List<int>();
    public void CreateTrain(string CityofDeparture, string CityofArrival)
    {
        CheckErrors checkErrors = new CheckErrors();

        TravelTime.Add(rnd.Next(3, 240));

        int rand = rnd.Next(300, 1253);
        int rand2 = rnd.Next(rand, rand) - 341;
        int changeInMenu;
        Console.WriteLine("  Формируем и отправляем поезд");
        Console.WriteLine("  Сформированное направление:");
        Console.WriteLine($"  Город отправления - {CityofDeparture}   =====>  Город прибытия - {CityofArrival}");
        Console.WriteLine($"\n   Время в пути {TravelTime[i]}");
        Console.WriteLine($"  Всего продано билетов на этот поезд: {rand}  \n  На это количество пассажиров необходимо сформировать поезд из вагонов.\n");



        if (rand > rand2)
        {


            while (rand > rand2)
            {
                Console.WriteLine($" Вместительность поезда на данный момент {rand2}");
                Console.WriteLine("  Необходимо  добавить вагоны\n\n   Нажмите (Д)обавить");
                changeInMenu = checkErrors.CheckError(Console.ReadLine());
                if (changeInMenu == 1)
                {
                    rand2 = rand2 + rnd.Next(73, 118);
                }

            }
        }
        Console.WriteLine($"Необходимое количество мест подготовлено");
        Console.WriteLine("Отправляем поезд?\n   1 - Да\n   2 - Нет");
        changeInMenu = checkErrors.CheckError(Console.ReadLine());

        if (changeInMenu == 1)
        {
            Console.WriteLine("Все пассажиры заняли свои места!");
            Console.WriteLine("Поезд успешно отправлен!");
            TravelPassengers.Add(rand);
            i = i + 1;
        }

        if (changeInMenu == 2)
        {
            TravelTime.RemoveAt(i);
        }
    }
    public bool CancelChangeTrain()
    {
        bool ready = false;69
        return ready;
    }

}
class Passenger { }

class TextMenu
{

}


class CheckErrors
{
    public int CheckError(string changeInMenu)
    {
        int chMenu = 0;
        if (int.TryParse(changeInMenu, out int result))
        {
            changeInMenu = result.ToString();
            return Convert.ToInt32(changeInMenu);
        }
        if (changeInMenu == "Д")
        {
            return 1;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("\n\n   Вы ввели неверные данные");
            Console.ReadLine();
            changeInMenu = chMenu.ToString();
            return Convert.ToInt32(changeInMenu);
        }
    }
}
