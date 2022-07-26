using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ.InformationOnCriminals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Handler medicalBase = new Handler();
            medicalBase.Work();
        }
    }

    class DataBase
    {
        private List<Client> _clients = new List<Client>();
        public DataBase()
        {
            Random random = new Random();
            int numberName;
            int numberSurname;
            int numberDisease;
            int counClient = 15;
            int maxAge = 100;
            int minAge = 1;
            int age;

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

            List<string> disease = new List<string>()
            {
                "Абсцесс головного мозга",
                "Абсцесс легкого хронический",
                "Абсцесс околочелюстной",
                "Авитаминоз",
                "Аденовирус",
                "Аденоиды (гипертрофия глоточной миндалины)",
                "Аденома простаты",
                "Аденома щитовидной железы",
                "Аденоматоз толстой кишки",
                "Аднексит (сальпингоофорит)",
                "Акне",
                "Акромегалия",
                "Актиномикоз",
                "Алалия",
                "Алкоголизм",
                "Аллергический ринит (насморк)",
                "Аллергия инсектная",
                "Аллергия лекарственная",
                "Аллергия пищевая",
                "Алопеция",
                "Альвеолит",
                "Альгоменорея",
                "Амблиопия",
                "Амебиаз (амебная дизентерия)",
                "Аменорея",
                "Амнезия",
                "Ангина",
                "Аневризмы сосудов головного мозга/интракраниальные аневризмы",
                "Аноргазмия",
                "Апатия",
                "Апноэ",
                "Аппендицит острый",
                "Аритмия",
                "Артроз",
                "Астенопия",
                "Астигматизм",
                "Атерома",
                "Атеросклероз",
                "Атопический дерматит",
                "Атопический дерматоз (нейродермит)",
                "Атрофия головного мозга",
                "Аутизм",
                "Афазия"
            };

            for (int i = 0; i < counClient; i++)
            {
                numberName = random.Next(names.Count);
                numberSurname = random.Next(surnames.Count);
                numberDisease = random.Next(disease.Count);
                age=random.Next(minAge, maxAge);

                _clients.Add(new Client(names[numberName], surnames[numberSurname], age, disease[numberDisease]));
            }
        }

        public List<Client>  GetGroupClients()
        {
            List<Client> tempClients = new List<Client>();

            foreach (Client client in _clients)
            {
                tempClients.Add(client);
            }

            return tempClients;
        }  
    }

    class Handler
    {
        DataBase _groupClients= new DataBase();
        
        public void Work()
        {
            bool isWork = true;

            while (isWork == true)
            {
                Console.WriteLine("  Medical Base \n\n  1 -  Sorting clients by Name\n  2 -  Sorting clients by Surname\n  3 -  Sorting clients by Age \n  4 -  Sorting clients by Disease \n  Any other button - Exite");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowClients(SortByName());
                        break;
                    case "2":
                        ShowClients(SortBySurname());
                        break;
                    case "3":
                        ShowClients(SortByAge());
                        break;
                    case "4":
                        ShowClients(SortByDisease());
                        break;
                    default:
                        isWork = false;
                        break;
                }
                Console.Clear();
            }

            Console.Clear();
        }

        private void ShowClients(List<Client> clients)
        {
            Console.Clear();

            if (clients != null & clients.Count > 0)
            {
                Console.WriteLine("\n List of eligible clients:");

                foreach (Client client in clients)
                {
                    Console.WriteLine($"\n  Name: {client.Name}   Surname: {client.Surname}  Age: {client.Age} Article: {client.Disease}");
                }
            }
            else
            {
                Console.WriteLine($"Client was not found");
            }

            Console.ReadLine();
        }

        private List<Client> SortByName()
        {
            Console.Clear();
            Console.WriteLine("Please enter the client's name: ");
            string name = Console.ReadLine();

            var findClients = from Client client in _groupClients.GetGroupClients()
                              where client.Name == name
                              select client;

            return findClients.ToList();
        }

        private List<Client> SortBySurname()
        {
            Console.Clear();
            Console.WriteLine("Please enter the client's surname: ");
            string surname = Console.ReadLine();

            var findClients = from Client client in _groupClients.GetGroupClients()
                              where client.Surname == surname
                              select client;

            return findClients.ToList();
        }

        public List<Client> SortByAge()
        {
            Console.Clear();
            Console.WriteLine("Please enter the client's age: ");
            string age = Console.ReadLine();

            if (int.TryParse(age, out int clientAge))
            {
                var findClients = from Client client in _groupClients.GetGroupClients()
                                  where client.Age == clientAge
                                  select client;

                return findClients.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Client> SortByDisease()
        {
            Console.Clear();
            Console.WriteLine("Please enter the client's disease: ");
            string disease = Console.ReadLine();

            var findClients = from Client client in _groupClients.GetGroupClients()
                              where client.Disease.Contains(disease)
                              select client;

            return findClients.ToList();
        }
    }

    class Client
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Client(string name, string surname, int age, string disease)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Disease = disease;
        }
    }
}
