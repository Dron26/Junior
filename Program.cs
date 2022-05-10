using System;
using System.Collections.Generic;

namespace HomeLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookStorage bookStorage = new BookStorage();
            bookStorage.Work();
        }
    }

    public class BookStorage
    {
        private List<Book> _grupBooks = new List<Book>();
        private List<string> _genres = new List<string>()
        {
            "Деловая литература",
            "Детективы и Триллеры",
            "Документальная литература",
            "Дом, ремесла, досуг, хобби" +
            "Драматургия",
            "Искусство, Искусствоведение, Дизайн",
            "Компьютеры и Интернет",
            "Литература для детей",
            "Любовные романы",
            "Наука, Образование" +
            "Поэзия",
            "Приключения",
            "Проза",
            "Прочее",
            "Религия, духовность, эзотерика",
            "Справочная литература",
            "Старинное",
            "Техника",
            "Учебники и пособия" +
            "Фантастика",
            "Фольклор",
            "Юмор",
            "Здоровье, красота, психология",
            "Зарубежная литература"
        };
        private int _maxLenghtNameBook = 100;
        private int _minLenghtName = 1;
        private int _maxLenghtNameAuthor = 30;
        private int _maxDateRelease = DateTime.Today.Year + 1;
        private int _id = 0;

        public void Work()
        {
            string userInput;
            bool isWork = true;

            Console.WriteLine("Добро пожаловать в Домашнюю Библиотеку\n Тут вы можете:");

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("  1 - Добавить книгу\n  2 - Убрать книгу \n  3 - Показать все книги \n  4 - Найти книгу\n  5 - Выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        DeleteBook();
                        break;
                    case "3":
                        ShowAllBook();
                        break;
                    case "4":
                        FindBook();
                        break;
                    case "5":
                        isWork = false;
                        break;
                }
            }
        }

        private void AddBook()
        {
            string name;
            string author;
            string genre;
            int yearOfRelease;
            int idGrence;

            name = GetBookName();
            author = GetAuthorName();
            yearOfRelease = GetReleaseDate();
            genre = GetGenre(out idGrence);

            _grupBooks.Add(new Book(name, author, genre, idGrence, yearOfRelease, _id));

            Console.Clear();
            Console.WriteLine("Книга добавлена: ");
            Console.WriteLine($"  Название книги: {name}, Автор книги: {author}, Жанр: {genre}, Год выпуска книги : {yearOfRelease}, Уникальный ноиер книги : {_id}");
            Console.ReadLine();
            _id++;
        }

        private string GetBookName()
        {
            string name;
            bool isNameGet = false;

            Console.Clear();
            Console.WriteLine("Ввведите следующую информацию по книге:\n  Название книги:");
            name = Console.ReadLine();

            while (isNameGet == false)
            {
                if (_minLenghtName <= name.Length & name.Length <= _maxLenghtNameBook)
                {
                    isNameGet = true;
                }
                else
                {
                    Console.WriteLine($"  Вы ввели не верные данные.\n  Название книги должно быть не менее {_minLenghtName} и не более {_maxLenghtNameBook} символов.\n  Повторите ввод: ");
                    name = Console.ReadLine();
                }
            }

            return name;
        }

        private string GetAuthorName()
        {
            string name;
            bool isNameGet = false;

            Console.Clear();
            Console.WriteLine("Фамилия и Имя автора книги:");
            name = Console.ReadLine();

            while (isNameGet == false)
            {
                if (_minLenghtName <= name.Length & name.Length <= _maxLenghtNameAuthor)
                {
                    isNameGet = true;
                }
                else
                {
                    Console.WriteLine($"  Вы ввели не верные данные.\n  Фамилия и имя автора не иогут быть мнее {_minLenghtName} и длиннее {_maxLenghtNameAuthor} символов.\n  Повторите ввод: ");
                    name = Console.ReadLine();
                }
            }

            return name;
        }

        private int GetReleaseDate()
        {
            bool isYearGet = false;
            int userInput = 0;

            Console.Clear();
            Console.WriteLine("Год выпуска книги:");

            while (isYearGet == false)
            {
                if (int.TryParse(Console.ReadLine(), out int year) & year <= _maxDateRelease)
                {
                    userInput = year;
                    isYearGet = true;
                }
                else
                {
                    Console.WriteLine($"  Вы ввели не верные данные.\n Дата выпуска книги не может быть будущей датой .\n  Повторите ввод: ");
                }
            }

            return userInput;
        }

        private string GetGenre(out int selectedNumber)
        {
            bool isGenreGet = false;
            string selectedGenre = null;
            selectedNumber = 0;

            Console.Clear();
            Console.WriteLine("Выберите жанр книги по содержанию");

            ShowGenre();

            while (isGenreGet == false)
            {
                if (int.TryParse(Console.ReadLine(), out int number) & 0 < number & number <= _genres.Count)
                {
                    selectedGenre = _genres[number];
                    selectedNumber = number;
                    isGenreGet = true;
                }
                else
                {
                    Console.WriteLine($"  Вы ввели не верные данные.\n  Повторите ввод: ");
                }
            }

            return selectedGenre;
        }

        private void ShowGenre()
        {
            int number = 0;

            foreach (string genre in _genres)
            {
                Console.WriteLine($"{number} - {genre}");
                number++;
            }
        }

        private void DeleteBook()
        {
            string userInput;

            Console.Clear();
            Console.WriteLine("  Введите уникальный номер книги:");
            userInput = Console.ReadLine();

            if (TryGetBook(userInput, out Book book))
            {
                book.ShowInfo();
                Console.WriteLine("  Вы точно хотите убрать книгу? Y/N:");
                userInput = Console.ReadLine();

                if (userInput.ToLower() == "y")
                {
                    _grupBooks.Remove(book);
                    Console.WriteLine($" Ok, книги больше нет");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine($"Отмена ");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не верные данные,возможно такой книги нет");
                Console.ReadLine();
            }
        }

        private bool TryGetBook(string userInput, out Book trueBook)
        {
            trueBook = null;
            bool isGetBook = false;

            if (int.TryParse(userInput, out int number) == true)
            {
                foreach (Book book in _grupBooks)
                {
                    if (book.Id == number)
                    {
                        trueBook = book;
                        isGetBook = true;
                        return isGetBook;
                    }
                }
            }

            return isGetBook;
        }

        private void ShowAllBook()
        {
            Console.Clear();

            if (_grupBooks.Count == 0)
            {
                Console.WriteLine("На данный момент у вас нет книг");
            }
            else
            {
                foreach (Book book in _grupBooks)
                {
                    book.ShowInfo();
                }
            }

            Console.ReadLine();
        }

        private void FindBook()
        {
            string userInput;
            bool isFinded = false;

            Console.Clear();
            Console.WriteLine("По какому критерию будем искать книгу?\n  1 - По названию книги\n  2 - По имени автора\n  3 - По дате выпуска книги\n  4 - По жанру\n  5 - По уникальному номеру");
            userInput = Console.ReadLine();

            if (userInput == "4")
            {
                Console.Clear();
                Console.WriteLine("Список доступных жанров:");
                ShowGenre();
            }

            if (int.TryParse(userInput, out int number) == true)
            {
                Console.WriteLine("Введите данные:");
                userInput = Console.ReadLine();
                Console.Clear();
                int.TryParse(userInput, out int result);

                foreach (Book book in _grupBooks)
                {
                    switch (number)
                    {
                        case 1:
                            isFinded = book.Name.ToLower().Contains(userInput.ToLower());
                            break;
                        case 2:
                            isFinded = book.Author.ToLower().Contains(userInput.ToLower());
                            break;
                        case 3:
                            isFinded = book.YearOfRelease == result;
                            break;
                        case 4:
                            isFinded = book.IdGenre == result;
                            break;
                        case 5:
                            isFinded = book.Id == result;
                            break;
                    }

                    if (isFinded == true)
                    {
                        Console.WriteLine("По введенным данным есть совпадения: ");
                        book.ShowInfo();
                    }
                    else
                    {
                        Console.WriteLine("По введенным данным совпадений нет ");
                    }
                }

                Console.ReadLine();
            }
        }
    }

    class Book
    {
        public string Name { get; }
        public string Author { get; }
        public string Genre { get; }
        public int IdGenre { get; }
        public int YearOfRelease { get; }
        public int Id { get; }

        public Book(string name, string autor, string genre, int idGrence, int yearOfRelease, int id)
        {
            Name = name;
            Author = autor;
            Genre = genre;
            IdGenre = idGrence;
            YearOfRelease = yearOfRelease;
            Id = id;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название книги: {Name}, Автор книги: {Author}, Жанр: {Genre}, Год выпуска книги : {YearOfRelease}, Уникальный ноиер книги : {Id}");
        }
    }
}

