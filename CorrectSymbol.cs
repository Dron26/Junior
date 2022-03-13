using System;

namespace converter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string textInput;
            int depth = 0;
            int maxDepth = 0;
            string showCorrectText = null;

            Console.WriteLine("Введите комбинацию символов");
            textInput=Console.ReadLine();

            foreach (char symbol in textInput)
            {
                if ( symbol == '(')
                {
                    depth++;
                    
                    if (maxDepth < depth)
                    {
                        maxDepth = depth;
                    }                    
                }
                else 
                {                                                   
                    depth--;
                }                
                if (depth < 0)
                {
                    showCorrectText = "не корректная";
                    break;
                }
            }

            if (depth!=0)
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
