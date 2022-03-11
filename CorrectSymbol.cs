using System;

namespace converter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string textInput;
            int upDepth = 0;
            int downDepth = 0;
            int maxDepth = 0;
            int clouseDepth = 1;
            int upDepthAll = 1;
            bool CorrectText = false;
            string showCorrectText = null;
            int count = 0;

            Console.WriteLine("Введите комбинацию символов");
            textInput=Console.ReadLine();

            foreach (char c in textInput)
            {             
                if (c==')')
                {
                    downDepth++;
                    if (c == ')'&(count == 0| count == 1))
                    {
                        CorrectText = true;
                    }
                    
                    else if (maxDepth< upDepth)
                    {
                        maxDepth = upDepth;
                        upDepth= upDepth - clouseDepth;
                    }

                    else if (downDepth> upDepthAll)
                    {
                        CorrectText = true;
                    }
                }

                else if(count > 0&&c=='(')
                {
                    upDepth++;
                    upDepthAll++;
                }
                count++;              
            }
            if (upDepthAll != downDepth)
            {
                CorrectText = true;
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
