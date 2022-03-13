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
            int clouseDepth = 1;
            bool isUncorrectText = false;
            string showCorrectText = null;
            int count = 0;

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
                    if (symbol == ')'&(count == 0| count == 1))
                    {
                        isUncorrectText = true;
                    }
                    
                    else if (maxDepth< upDepth)
                    {
                        maxDepth = upDepth;
                    }
                    upDepth--;
                }                
                count++;              
            }

            if (upDepth!=0)
            {
                isUncorrectText = true;
                showCorrectText = "не корректная";
            }    
            
            else
            {
                showCorrectText = "корректная";
            }
            Console.WriteLine($"{textInput} - строка {showCorrectText}  и максимум глубины равняется {maxDepth}");
        }    
    } 
}
