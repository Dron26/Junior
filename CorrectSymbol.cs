using System;

namespace converter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string textInput;
            int upDepth = 0;;
            int maxDepth = 0;
            string showCorrectText = null;

            Console.WriteLine("Введите комбинацию символов");
            textInput=Console.ReadLine();

            foreach (char symbol in textInput)
            {
                if ( symbol == '(')
                {
                    upDepth++;
                }
                else 
                {                               
                    if (maxDepth< upDepth)
                    {
                        maxDepth = upDepth;
                    }
                    upDepth--;
                }                

                if (upDepth < 0)
                {
                    showCorrectText = "не корректная";
                    break;
                }
            }

            if (upDepth!=0)
            {                
                showCorrectText = "не корректная";
            }               
            else
            {
                showCorrectText = "корректная";
            }
            Console.WriteLine($"{textInput} - строка {showCorrectText} и максимум глубины равняется {maxDepth}");
        }    
    } 
}
