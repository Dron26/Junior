using System;

namespace Battel_vs_Boss
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string name;
            int minDamage = random.Next(10, 18);
            int maxDamage = random.Next(25, 35);
            int countFirebolls = 0;
            int maxCountFirebolls = 3;
            int minHealth = random.Next(90, 100);
            int maxHealth = random.Next(145, 160);
            int maxPerecentChance = 50;
            string userInput;
            bool isSelectStrike = false;
            bool isTrySelectStrike = false;
            bool isIceBollSelect = false;
            bool isUserSelectNewPlay = true;
            bool isHealthBossRestored = false;
            bool isAlive = true;

            while (isUserSelectNewPlay == true)
            {
                int magicStrike = random.Next(minDamage, maxDamage);
                int fireboll = random.Next(minDamage, maxDamage);
                int iceboll = random.Next(minDamage, maxDamage);
                int magicRestore = random.Next(maxDamage, minDamage + maxDamage);
                int health = random.Next(minHealth, maxHealth);
                int bossHealth = random.Next(minHealth, maxHealth);
                int bossDamage = random.Next(minDamage, maxDamage);
                int chanceFirstStrike = random.Next(0, 100);
                int chanceMagicRestore;
                int minChanceHealthRestore=30;
                int maxChanceHealthRestore=100;

                Console.WriteLine(" \n  Добро пожаловать в игру Битва с Боссом");
                Console.Write(" \n  Введи свое имя: ");
                name = Console.ReadLine();

                Console.WriteLine($"\n  {name},  У тебя есть 4 магических приема:\n\n" +
                    $"1 - Магический удар - наносит урон (-{magicStrike}xp) \n" +
                    $"2 - Огненный шар - наносит урон (-{fireboll}xp) \n" +
                    $" (его можно использовать не более трех раз подряд) \n\n" +
                    $"3 - Ледяной шар - наносит урон (-{iceboll}xp)\n" +
                    $"4 - Магическое восстановление жизни (+{magicRestore}xp)\n" +
                    $" (его можно использовать только после ледяного шара)");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine(" \n  Перед тобой злой троль по имени  Гнусcвин, " +
                    "\n  Тебе необходимо победить его!");
                Console.ReadLine();
                Console.WriteLine("\n  Если ты не струсил,то прими бой или убегай!");
                Console.WriteLine("\n  1 - В бой \n  2 - Заплакать и убежать");
                userInput = Console.ReadLine();

                if (userInput == "2")
                {
                    Console.WriteLine("Подрасти и возвращайся");
                    isUserSelectNewPlay = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n Хорошо погнали");
                    Console.WriteLine($"\n  Твои жизни  {health}\n  жизни Гнусвина  {bossHealth}");

                    if (chanceFirstStrike > maxPerecentChance)
                    {
                        Console.WriteLine("\n Первый удар делаеш Ты");
                    }
                    else
                    {
                        Console.WriteLine($"\n Первый удар делает Гнусвин!  - {bossDamage} xp");
                        health -= bossDamage;
                        Console.WriteLine($"\n  Твои жизни  {health}\n  жизни Гнусвина  {bossHealth}");
                    }
                    Console.ReadLine();

                    while (health > 0 && bossHealth > 0)
                    {
                        while (isSelectStrike == false && isAlive == true)
                        {
                            Console.WriteLine("\n Выбери удар:  \n  " +
                            $"1 -  Магический удар ({magicStrike}) \n  " +
                            $"2 -  Огненный шар  ({fireboll}) \n  " +
                            $"3 -  Ледяной шар ({iceboll})\n  " +
                            $"4 -  Восстановление жизни (+{magicRestore}xp)");
                            userInput = Console.ReadLine();

                            switch (userInput)
                            {
                                case "1":
                                    bossHealth -= magicStrike;
                                    break;
                                case "2":
                                    if (countFirebolls > maxCountFirebolls)
                                    {
                                        Console.WriteLine("ты не можешь применить это заклинание больше 3х раз подряд");
                                        isTrySelectStrike = true;
                                    }
                                    else
                                    {
                                        bossHealth -= fireboll;
                                        countFirebolls++;
                                    }
                                    break;
                                case "3":
                                    bossHealth -= iceboll;
                                    isIceBollSelect = true;
                                    break;
                                case "4":
                                    if (isIceBollSelect == true)
                                    {
                                        health += magicRestore;
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
                                if (userInput != "2")
                                {
                                    countFirebolls = 0;
                                }
                            }

                            if (health > 0 & bossHealth > 0)
                            {
                                isSelectStrike = false;
                                Console.WriteLine($"\n  Твои жизни  {health}\n  жизни Гнусвина  {bossHealth}");

                                if ((chanceMagicRestore = random.Next(minChanceHealthRestore, maxChanceHealthRestore)) > maxPerecentChance)
                                {
                                    Console.WriteLine($"\n Удар наносит Гнусвин!  - {bossDamage} xp");
                                    health -= bossDamage;
                                    isHealthBossRestored = false;
                                }
                                else
                                {
                                    if (isHealthBossRestored == false)
                                    {
                                        Console.WriteLine($"\n  Гнусвин смог восстановить себе здоровье на {magicRestore}");
                                        bossHealth += magicRestore;
                                        isHealthBossRestored = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"\n  Гнусвин промахнулся");
                                        isHealthBossRestored = false;
                                    }
                                }

                                if (health > 0)
                                {
                                    Console.WriteLine($"\n  Твои жизни  {health}\n  жизни Гнусвина  {bossHealth}");
                                }
                                else
                                {
                                    isAlive = false;
                                }
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }

                    if (health <= 0)
                    {
                        Console.WriteLine("Ты погиб, но мы будем помнить тебя! Попробуй еще раз, мы сможем воскресить тебя");
                    }
                    else
                    {
                        Console.WriteLine(" Ты победил!!! попробуй показать свою мощь еще раз!");
                    }
                    Console.WriteLine("  1 - Попробовать снова \n  2 - Хочу на покой");
                    userInput = Console.ReadLine();

                    if (userInput == "1")
                    {
                        Console.WriteLine(" Давай по новой!");
                        isSelectStrike = false;
                        isAlive = true;
                    }
                    else
                    {
                        Console.WriteLine("Аминь");
                        isUserSelectNewPlay = false;
                    }
                    Console.Clear();
                }
            }
        }
    }
}
