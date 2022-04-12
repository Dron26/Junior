using System;
using System.Collections.Generic;
using System.IO;

namespace WorkWithList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> popularWords = new List<string>();
            List<string> meaningsOfPopularWords = new List<string>();
            string nameFileWords = "popularWords";
            string nameFileMeanings = "meaningsOfPopularWords";
            string userInput;
            bool isWorking = true;

            popularWords = FillingList(nameFileWords);
            meaningsOfPopularWords = FillingList(nameFileMeanings);
            Console.WriteLine("Вы вводите слово, а я обьясняю его значение.");

            while (isWorking)
            {
                Console.WriteLine("\n  1 - Ввести слово \n  2 - Показать весь список слов\n  3 - Для завершения программы\n");
                userInput = (Console.ReadLine()).ToUpper();

                switch (userInput)
                {
                    case "1":
                        FindingWordInLists(popularWords, meaningsOfPopularWords);
                        break;

                    case "2":
                        ShowingAllInList(popularWords);
                        break;

                    case "3":
                        isWorking = false;
                        break;

                    default:
                        break;
                }
            }

        }

        static void FindingWordInLists(List<string> list, List<string> list2)
        {
            Console.Clear();
            Console.WriteLine("Введите слово:");
            string userInput = Console.ReadLine();

            foreach (var word in list)
            {
                if (word.ToUpper().Contains(userInput.ToUpper()))
                {
                    int number = list.IndexOf(word);
                    Console.WriteLine($"\n{ list[number]}{list2[number]}\n\n");
                    break;
                }
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void ShowingAllInList(List<string> list)
        {
            Console.Clear();

            foreach (var line in list)
            {
                Console.WriteLine(line);
            }

            Console.ReadLine();
            Console.Clear();
        }

        static List<string> FillingList(string namefile)
        {
            List<string> newFile = new List<string>();
            FileStream fileStream = new FileStream($"{namefile}.txt", FileMode.Open);
            StreamReader readFile = new StreamReader(fileStream);

            while (!readFile.EndOfStream)
            {
                newFile.Add(readFile.ReadLine());
            }

            readFile.Close();
            return newFile;
        }
    }
}
