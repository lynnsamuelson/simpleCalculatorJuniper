using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
    
        static void Main(string[] args)
        {
            Stack monkey = new Stack();
            Parse parse = new Parse();
            Constants constant = new Constants();

            bool toExit = false;

            while (!toExit)
            {

                String prompt = "> ";
                Console.WriteLine("What do you want me to do?");
                Console.Write(prompt);
                string response = Console.ReadLine();
                if (response == "exit")
                {
                    toExit = true;
                } else if (response == "quit")
                {
                    toExit = true;
                }
                else
                {
                    bool validResponse = parse.ValidateData(response);
                
                    if (validResponse == true)
                    {
                        char theOperator = parse.GetOperator(response);
                        List<string> numbers = parse.GetNumbers(response);
                        List<int> numberInts = parse.MakeInts(numbers);
                        if (theOperator == '+' || theOperator == '-' || theOperator == '/' || theOperator == '*')
                        {
                            int calculator = parse.Calculate(theOperator, numberInts[0], numberInts[1]);
                            Console.WriteLine("The answer is " + calculator + ".");
                        }
                        if (theOperator == '=')
                        {

                            int constantValue = constant.GetConstantsValue(response);
                            char theConstant = constant.GetConstant(response); 
                            Console.WriteLine("The constant " + theConstant + " has been saved with the value " + constantValue + ".");
                        }
                    }
                    else if (validResponse == false)
                    {
                        Console.WriteLine("invalid data");
                    }
                }
            }
        }
    }
}
