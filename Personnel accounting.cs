using System;
using System.Collections.Generic;

namespace Cadrovui_ychet
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dossiers = new Dictionary<int, string>();
            string userInput;
            bool isWorking = true;
            int countDossiers = 0;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("  1 - добавить досье. " +
                    "\n  2 - вывести все досье. " +
                    "\n  3 - удалить досье. " +
                    "\n  5 - выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDossier(ref dossiers, ref countDossiers);
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

                    default:
                        break;
                }

            }

        }

        static void AddDossier(ref Dictionary<int, string> tempDossiers, ref int countDossiers)
        {
            string namesAndPosition;

            Console.Clear();
            Console.WriteLine("  Добавление досье \n  Введите фамилию:\n");
            namesAndPosition = (" - " + Console.ReadLine() + " - ");
            Console.WriteLine("\n  Введите Имя:\n");
            namesAndPosition += (Console.ReadLine() + " - ");
            Console.WriteLine("\n  Введите Отчество:\n");
            namesAndPosition += (Console.ReadLine() + " - ");
            Console.WriteLine("\n  Введите Должность:\n");
            namesAndPosition += Console.ReadLine();
            tempDossiers.Add(countDossiers, namesAndPosition);
            countDossiers++;
            Console.WriteLine("Досье успешно добавлено!");
            Console.ReadKey();
        }

        static void ShowAllDossiers(Dictionary<int, string> tempDictionary)
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

        static Dictionary<int, string> DeleteDossier(Dictionary<int, string> dossiers)
        {
            Dictionary<int, string> tempDossiers = new Dictionary<int, string>();

            Console.Clear();
            Console.WriteLine("Ведите номер досье: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            if (dossiers.ContainsKey(userInput) == true)
            {
                int count = 0;
                dossiers.Remove(userInput);

                foreach (var record in dossiers)
                {
                    tempDossiers.Add(count, record.Value);
                    count++;
                }

                dossiers = tempDossiers;
                Console.WriteLine("Досье успешно удалено");
            }
            else
            {
                Console.WriteLine("Досье не найденоно");
            }

            Console.ReadKey();
            return dossiers;
        }

    }

}
