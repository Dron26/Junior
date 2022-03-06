using System;

namespace ConsoleApp9
{
    internal class Questionnaire
    {
        static void Main(string[] args)
        {
            string name;
            string surname;
            int age;
            string work;
            string position;
            string hobby;
            string dogName;
            string relationshipsToLife;
            Console.WriteLine("  Привет! Поможешь мне заполнить анкету? \n  Тут всего пару вопросов!) Погнали, это быстро");
            Console.WriteLine("Как тебя зовут?");
            name = Console.ReadLine();
            Console.WriteLine("Как тебя по батюшке?) ");
            surname = Console.ReadLine();
            Console.WriteLine("А сколько тебе лет, если не секрет? ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Так хорошо сохраниться похвально! Где ты сейчас работаешь? ");
            work = Console.ReadLine();
            Console.WriteLine("А должность? ");
            position = Console.ReadLine();
            Console.WriteLine("Дай угадаю у тебя по любому есть любимое хобби, какое оно? ");
            hobby = Console.ReadLine();
            Console.WriteLine("Если бы тебе подарили собаку, как бы ты ее назвал?)");
            dogName = Console.ReadLine();
            Console.WriteLine("как ты относишься к жизни");
            relationshipsToLife = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Готово! Вот мы и заполнили анкету, давай проверим на всякий случай:");
            Console.WriteLine($"  Тебя зовут: {name}\n  Твое отчество: {surname}  \n  Тебе - {age} лет \n  Ты работаешь в {work}  на должности: {position}" +
                $"\n  Твое хобби: {hobby} \n  Кличка твоей будущей собачки: {dogName} \n  твое отношение к жизни: {relationshipsToLife}");
        }
    }
}