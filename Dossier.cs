using System;

namespace Cadrovui_ychet
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string[] fullNames = new string[0];
            string[] positions = new string[0];
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("  1 - добавить досье. " +
                    "\n  2 - вывести все досье. " +
                    "\n  3 - удалить досье. " +
                    "\n  4 - поиск по фамилии. " +
                    "\n  5 - выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreatDossier(ref fullNames, ref positions);
                        break;
                    case "2":
                        ShowAllDossiers(fullNames, positions);
                        break;
                    case "3":
                        DeleteDossier(ref fullNames, ref positions);
                        break;
                    case "4":
                        FindDossier(fullNames, positions);
                        break;
                    case "5":
                        isWorking = false;
                        break;
                }
            }
        }

        static void CreatDossier(ref string[] fullNames, ref string[] positions)
        {
            string names;
            string post;

            Console.Clear();
            Console.WriteLine("  Добавление досье \n  Введите фамилию:\n");
            names = (" - " + Console.ReadLine() + " - ").ToUpper();
            Console.WriteLine("\n  Введите Имя:\n");
            names += (Console.ReadLine() + " - ").ToUpper();
            Console.WriteLine("\n  Введите Отчество:\n");
            names += (Console.ReadLine() + " - ").ToUpper();
            Console.WriteLine("\n  Введите Должность:\n");
            post = (Console.ReadLine()).ToUpper();
            ExtensionArray(ref fullNames, names);
            ExtensionArray(ref positions, post);
            Console.WriteLine("Досье успешно добавлено!");
            Console.ReadKey();
        }

        static void ExtensionArray(ref string[] extension, string inputData)
        {
            string[] tempExtension = new string[extension.Length + 1];

            for (int i = 0; i < extension.GetLength(0); i++)
            {
                tempExtension[i] = extension[i];
            }
            tempExtension[tempExtension.Length - 1] = inputData;
            extension = tempExtension;
        }

        static void ShowAllDossiers(string[] fullNames, string[] positions)
        {
            Console.Clear();
            Console.WriteLine($" ID - Фамилия -  Имя - Отчество -  Должность ");
            if (fullNames.Length != 0)
            {
                for (int i = 0; i < fullNames.GetLength(0); i++)
                {
                    Console.WriteLine($"  {i} { fullNames[i] } { positions[i] }");
                }
            }
            else
            {
                Console.WriteLine("Досье не найденоно");
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void DeleteDossier(ref string[] fullNames, ref string[] positions)
        {
            int userInput;
            Console.Clear();
            Console.WriteLine("Ведите номер досье: ");
            userInput = Convert.ToInt32(Console.ReadLine());

            if (userInput > 0 & userInput <= fullNames.Length)
            {
                DecreaseArray(ref fullNames, userInput);
                DecreaseArray(ref positions, userInput);
                Console.WriteLine("Досье успешно удалено");
            }
            else
            {
                Console.WriteLine("Досье не найденоно");
            }
            Console.ReadKey();
        }

        static void DecreaseArray(ref string[] decrease, int inputData)
        {
            string[] tempDecrease = new string[decrease.Length - 1];

            for (int i = 0; i < inputData; i++)
            {
                tempDecrease[i] = decrease[i];
            }

            for (int i = inputData + 1; i < decrease.Length; i++)
            {
                tempDecrease[i - 1] = decrease[i];
            }
            decrease = tempDecrease; ;
        }

        static void FindDossier(string[] fullNames, string[] positions)
        {
            bool isFinded = false;
            Console.Clear();
            Console.WriteLine("   Введите фамилию:  \n");
            string userInput = (Console.ReadLine()).ToUpper();

            foreach (var fullName in fullNames)
            {
                if (fullName.Contains(userInput))
                {
                    int number = Array.IndexOf(fullNames, fullName);
                    Console.Clear();
                    Console.WriteLine($" ID - Фамилия -  Имя - Отчество -  Должность ");
                    Console.WriteLine($"Досье найдено: { number } - { fullNames[number] } { positions[number] }");
                    isFinded = true;
                }
            }

            if (isFinded == false)
            {
                Console.Clear();
                Console.WriteLine("  Досье ненайдено!");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
