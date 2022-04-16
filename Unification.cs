using System;
using System.Collections.Generic;

namespace Unification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxLenght = 100;
            int[] line = new int[maxLenght];
            int[] line2 = new int[maxLenght];
            List<int> united = new List<int>();

            line = FillArray(line);
            line2 = FillArray(line2);
            united = FillList(united,line);
            united=FillList(united, line2);
        }

        static int[] FillArray(int [] selected)
        {
                int maxValue = 100;
                int minValue = 0;
                Random random = new Random();

                for (int i = 0; i < selected.Length; i++)
                {
                    selected[i]=random.Next(minValue,maxValue);    
                }

                return selected;
        }

        static List<int> FillList(List<int> united, int[] selected)
        {
            foreach (var element in selected)
            {
                if (united.Contains(element)==false)
                {
                    united.Add(element);
                }
            }

            united.Sort();
            return united;
        }
    }
}
