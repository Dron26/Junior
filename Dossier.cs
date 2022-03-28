using System;

namespace Cadrovui_ychet
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string[] familyArray = new string[0];
            string[] nameArray = new string[0];
            string[] postArray = new string[0];
            int[] idArray = new int[0];
            int ID = 0;
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
                        CreatDossier(ref familyArray, ref nameArray, ref postArray, ref ID, ref idArray);
                        break;
                    case "2":
                        ShowAllDossiers(familyArray, nameArray, postArray, idArray);
                        break;
                    case "3":
                        DeleteDossier(ref familyArray, ref nameArray, ref postArray, ref idArray);
                        break;
                    case "4":
                        FindDossier(familyArray, nameArray, postArray, idArray);
                        break;
                    case "5":
                        isWorking = false;
                        break;
                }
            }
        }
        static void DeleteDossier(ref string[] familyArray, ref string[] nameArray, ref string[] postArray, ref int[] idArray)
        {
            string userInput;
            bool isFinded = false;
            Console.Clear();
            Console.WriteLine("Ведите номер досье: ");
            userInput = Console.ReadLine();

            for (int id = 0; id < idArray.Length; id++)
            {
                if (Convert.ToInt32(userInput) == id)
                {
                    string[] tempFamily = new string[familyArray.Length];
                    string[] tempFamilyDown = new string[tempFamily.Length - 1];
                    string[] tempPost = new string[postArray.Length];
                    string[] tempPostDown = new string[tempPost.Length - 1];
                    string[] tempName = new string[nameArray.Length];
                    string[] tempNameDown = new string[tempName.Length - 1];
                    int[] tempId = new int[idArray.Length];
                    int[] tempIdDpwn = new int[idArray.Length - 1];

                    for (int i = 0; i < id; i++)
                    {
                        tempFamily[i] = familyArray[i];
                        tempPost[i] = postArray[i];
                        tempName[i] = nameArray[i];
                        tempId[i] = idArray[i];
                    }

                    for (int i = id + 1; i < familyArray.Length; i++)
                    {
                        tempFamily[i - 1] = familyArray[i];
                        tempPost[i - 1] = postArray[i];
                        tempName[i - 1] = nameArray[i];
                        tempId[i - 1] = idArray[i];
                    }

                    for (int i = 0; i < tempFamilyDown.Length; i++)
                    {
                        tempFamilyDown[i] = tempFamily[i];
                        tempPostDown[i] = tempPost[i];
                        tempNameDown[i] = tempName[i];
                        tempIdDpwn[i] = tempId[i];
                    }
                    familyArray = tempFamilyDown;
                    postArray = tempPostDown;
                    nameArray = tempNameDown;
                    idArray = tempIdDpwn;
                    Console.WriteLine("Досье успешно удалено");
                    isFinded = true;
                }
            }

            if (isFinded == false)
            {
                Console.WriteLine("Досье не найденоно");
            }
            Console.ReadKey();
        }
        static void FindDossier(string[] familyArray, string[] nameArray, string[] postArray, int[] idArray)
        {
            Console.Clear();
            Console.WriteLine("   Введите фамилию:  \n");
            string family = Console.ReadLine();

            for (int i = 0; i < familyArray.Length; i++)
            {
                if (family == familyArray[i])
                {
                    Console.Clear();
                    Console.WriteLine($" ID - Фамилия -  Имя - Отчество -  Должность ");
                    Console.WriteLine($"Досье найдено: { idArray[i] } - { familyArray[i] } -  { nameArray[i] } -  { postArray[i] }");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("  Досье ненайдено!");
                }
            }
            Console.ReadKey();
            Console.Clear();

        }
        static void ShowAllDossiers(string[] familyArray, string[] nameArray, string[] postsArray, int[] idArray)
        {
            Console.Clear();
            Console.WriteLine($" ID - Фамилия -  Имя - Отчество -  Должность ");
            if (familyArray.Length != 0)
            {
                for (int i = 0; i < familyArray.GetLength(0); i++)
                {
                    Console.WriteLine($" { idArray[i] } - { familyArray[i] } -  { nameArray[i] } -  { postsArray[i] }");
                }
            }
            else
            {
                Console.WriteLine("Досье не найденоно");
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void CreatDossier(ref string[] familyArray, ref string[] nameArray, ref string[] postArray, ref int ID, ref int[] idArray)
        {
            string[] tempFamily = new string[familyArray.Length + 1];
            string[] tempName = new string[nameArray.Length + 1];
            string[] tempPost = new string[postArray.Length + 1];
            int[] tempId = new int[idArray.Length + 1];
            string family;
            string name;
            string post;
            ID++;

            Console.Clear();
            Console.WriteLine("  Добавление досье \n  Введите фамилию:  \n\n");
            family = Console.ReadLine();
            Console.WriteLine("    Введите Имя:  \n\n");
            name = Console.ReadLine() + " - ";
            Console.WriteLine("  Введите Отчество:  \n\n");
            name += Console.ReadLine();
            Console.WriteLine("  Введите Должность:  \n\n");
            post = Console.ReadLine();

            for (int i = 0; i < familyArray.GetLength(0); i++)
            {
                tempFamily[i] = familyArray[i];
                tempPost[i] = postArray[i];
                tempName[i] = nameArray[i];
                tempId[i] = idArray[i];
            }
            tempFamily[tempFamily.Length - 1] = family;
            tempName[tempFamily.Length - 1] = name;
            tempPost[tempPost.Length - 1] = post;
            tempId[tempId.Length - 1] = ID;
            familyArray = tempFamily;
            postArray = tempPost;
            nameArray = tempName;
            idArray = tempId;
            Console.WriteLine("Досье успешно добавлено!");
            Console.ReadKey();
        }
    }
}


