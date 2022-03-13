using System;

namespace converter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string textInput;
            int Depth = 0;
            int maxDepth = 0;
            string showCorrectText = null;

            Console.WriteLine("Введите комбинацию символов");
            textInput=Console.ReadLine();

            foreach (char symbol in textInput)
            {
                if ( symbol == '(')
                {
                    Depth++;
                }
                else 
                {                               
                    if (maxDepth< Depth)
                    {
                        maxDepth = Depth;
                    }
                    Depth--;
                }                

                if (Depth < 0)
                {
                    showCorrectText = "не корректная";
                    break;
                }
            }

            if (Depth!=0)
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
