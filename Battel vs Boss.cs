using System;

namespace Battel_vs_Boss
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string name;
            int minDamage = 15;
            int maxDamage = 30;
            int magicStrike = random.Next(minDamage, maxDamage);
            int fireBoll = random.Next(minDamage, maxDamage);
            int iceBoll = random.Next(minDamage, maxDamage);
            int magicRecover = random.Next(maxDamage, minDamage + maxDamage);
            int counFireBoll = 0;
            int minHealth = 100;
            int maxHealth = 150;
            int maxHealthRecoverBoss = random.Next(0, 85);
            int health = random.Next(minHealth, maxHealth);
            int bossHealth = random.Next(minHealth, maxHealth);
            int bossDamage = random.Next(minDamage, maxDamage);
            int chanceFirstStrike = random.Next(0, 100);
            int userInput;
            bool isSelectStrike = false;
            bool isTrySelectStrike = false;
            bool isIceBollSelect = false;
            bool isUserSelectNewPlay = true;

            while (isUserSelectNewPlay == true)
            {
                Console.Clear();
                Console.WriteLine(" \n  Добро пожаловать в игру Битва с Боссом");
                Console.Write(" \n  Введи свое имя: ");
                name = Console.ReadLine();
                Console.WriteLine($"\n  {name},  У тебя есть 4 магических приема:\n\n" +
                    $"1 - Магический удар - наносит урон (-{magicStrike}xp) \n" +
                    $"2 - Огненный шар - наносит урон (-{fireBoll}xp) \n" +
                    $" (его можно использовать не более трех раз подряд) \n\n" +
                    $"3 - Ледяной шар - наносит урон (-{iceBoll}xp)\n" +
                    $"4 - Магическое восстановление жизни (+{magicRecover}xp)\n" +
                    $" (его можно использовать только после ледяного шара)");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine(" \n  Перед тобой злой троль по имени  Гнусcвин, " +
                    "\n  Тебе необходимо победить его!");
                Console.ReadLine();
                Console.WriteLine("\n  Если ты не струсил,то прими бой или убегай!");
                Console.WriteLine("\n  1 - В бой \n  2 - Заплакать и убежать");
                userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == 2)
                {
                    Console.WriteLine("Подрасти и возвращайся");
                    isUserSelectNewPlay = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n Хорошо погнали");
                    Console.WriteLine($"\n  Твои жизни  {health}\n  жизни Гнусcвин  {bossHealth}");

                    if (chanceFirstStrike > 50)
                    {
                        Console.WriteLine("\n Первый удар делаеш Ты");
                    }
                    else
                    {
                        Console.WriteLine("\n Первый удар делает Гнусвин");
                        health -= bossDamage;
                        Console.WriteLine($"\n  Твои жизни  {health}\n  жизни Гнусcвин  {bossHealth}");
                    }

                    while (health > 0 && bossHealth > 0)
                    {
                        while (isSelectStrike == false)
                        {
                            Console.WriteLine("\n Выбери удар:  \n  " +
                            $"1 -  Магический удар ({magicStrike}) \n  " +
                            $"2 -  Огненный шар  ({fireBoll}) \n  " +
                            $"3 -  Ледяной шар ({iceBoll})\n  " +
                            $"4 -  Восстановление жизни (+{magicRecover}xp)");
                            userInput = Convert.ToInt32(Console.ReadLine());

                            switch (userInput)
                            {
                                case 1:
                                    bossHealth -= magicStrike;
                                    break;
                                case 2:
                                    if (counFireBoll > 3)
                                    {
                                        Console.WriteLine("ты не можешь применить это заклинание больше 3х раз подряд");
                                        isTrySelectStrike = true;
                                    }
                                    else
                                    {
                                        bossHealth -= fireBoll;
                                        counFireBoll++;
                                    }
                                    break;
                                case 3:
                                    bossHealth -= iceBoll;
                                    isIceBollSelect = true;
                                    break;
                                case 4:
                                    if (isIceBollSelect == true)
                                    {
                                        health += magicRecover;
                                        isIceBollSelect = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("  Ты не можешь применить это заклинание," +
                                        "\n оно применяется только поле ледяного шара");
                                        isTrySelectStrike = true;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("  Ты промахнулся!");
                                    break;
                            }

                            if (isTrySelectStrike == true)
                            {
                                isSelectStrike = false;
                                isTrySelectStrike = false;
                            }
                            else
                            {
                                isSelectStrike = true;
                                if (userInput != 2)
                                {
                                    counFireBoll = 0;
                                }
                            }
                        }
                        if (health > 0 && bossHealth > 0)
                        {
                            isSelectStrike = false;
                            Console.WriteLine($"\n  Твои жизни  {health}\n  жизни Гнусcвин  {bossHealth}");

                            if (maxHealthRecoverBoss > 70)
                            {
                                Console.WriteLine($"\n  Гнусвин смог восстановить себе здоровье на {magicRecover}");
                                bossHealth += magicRecover;
                            }
                            else
                            {
                                Console.WriteLine("\n Удар наносит Гнусcвин");
                                health -= bossDamage;
                            }
                            Console.WriteLine($"\n  Твои жизни  {health}\n  жизни Гнусcвин  {bossHealth}");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }

                    if (health <= 0)
                    {
                        Console.WriteLine("Ты погиб, но мы будем помнить тебя! Попробуй еще раз, мы сможем воскресить тебя");
                        Console.WriteLine("  1 - Попробовать снова \n  2 - Хочу на покой");
                        userInput = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine(" Ты победил!!! попробуй показать свою мощь еще раз!");
                        Console.WriteLine("  1 - Попробовать снова \n  2 - Хочу на покой");
                        userInput = Convert.ToInt32(Console.ReadLine());
                    }

                    if (userInput == 1)
                    {
                        Console.WriteLine(" Давай по новой!");
                    }
                    else
                    {
                        Console.WriteLine("Аминь");
                        isUserSelectNewPlay = false;
                    }
                }
            }
        }
    }
}
