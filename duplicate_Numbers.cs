using System;

namespace duplicate_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxElements = 30;
            int[] array = new int[maxElements];
            int countDuplicate = 0;
            int maxCountDuplicate=0;
            int maxNumber = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 3);
                Console.Write(array[i] + " ");
            }
            Console.Write("\n\n");

            for (int i = 1; i < array.Length; i++)
            {
                int z=(array[i]);
                if (array[i - 1] == array[i])
                {
                    countDuplicate++;
                }
                else
                {
                    if (maxCountDuplicate <= countDuplicate)
                    {
                        maxCountDuplicate = countDuplicate;
                        maxNumber = array[i - 1];
                    }
                    countDuplicate = 0;
                }    
            }
                Console.Write($" число {maxNumber}, имеет количество повторений = {maxCountDuplicate} ");
        }
    }
}
