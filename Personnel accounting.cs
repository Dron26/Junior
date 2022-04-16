using System;
using System.Collections.Generic;

namespace Cadrovui_ychet
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dossiers = new Dictionary<string, string>();
            string userInput;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("  1 - добавить досье. " +
                    "\n  2 - вывести все досье. " +
                    "\n  3 - удалить досье. " +
                    "\n  4 - выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        dossiers= AddDossier( dossiers);
                        break;

                    case "2":
                        ShowAllDossiers(dossiers);
                        break;

                    case "3":
                        dossiers = DeleteDossier(dossiers);
                        break;

                    case "4":
                        isWorking = false;
                        break;
                }
            }
        }

        static Dictionary<string, string> AddDossier( Dictionary<string, string> tempDossiers )
        {
            string dossierNumber =Convert.ToString( tempDossiers.Count);
            string dossier;

            Console.Clear();
            Console.WriteLine("  Добавление досье \n  Введите фамилию:\n");
            dossier = (" - " + Console.ReadLine() + " - ");
            Console.WriteLine("\n  Введите Имя:\n");
            dossier += (Console.ReadLine() + " - ");
            Console.WriteLine("\n  Введите Отчество:\n");
            dossier += (Console.ReadLine() + " - ");
            Console.WriteLine("\n  Введите Должность:\n");
            dossier += Console.ReadLine();
            tempDossiers.Add(dossierNumber, dossier);
            Console.WriteLine("Досье успешно добавлено!");
            Console.ReadKey();
            return tempDossiers;
        }

        static void ShowAllDossiers(Dictionary<string, string> tempDictionary)
        {
            Console.Clear();
            Console.WriteLine($" ID - Фамилия -  Имя - Отчество -  Должность ");

            foreach (var record in tempDictionary)
            {
                Console.WriteLine($"  {record.Key} {record.Value}\n");
            }

            Console.ReadKey();
            Console.Clear();
        }

        static Dictionary<string, string> DeleteDossier(Dictionary<string, string> dossiers)
        {

            Console.Clear();
            Console.WriteLine("Ведите номер досье: ");
            string userIput = Console.ReadLine();

            if (dossiers.ContainsKey(userIput) == true)
            {
                dossiers.Remove(userIput);
                Console.WriteLine("Досье успешно удалено");
            }
            else
            {
                Console.WriteLine("Досье не найдено");
            }

            Console.ReadKey();
            return dossiers;
        }
    }
}
