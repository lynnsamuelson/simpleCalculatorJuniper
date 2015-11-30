using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Constants
    {
        public char constant { get; set; }
        public Parse parse = new Parse();
        
        

        public char GetConstant(string input)
        {
            char first = input.First<char>();
            return first;
        }

        public int GetConstantsValue(string input)
        {
            List<string> numbers = parse.GetNumbers(input);
            int theValue = (parse.MakeInts(numbers)).First();
            return theValue;
        }

        public bool IsConstantDeclaration(string input)
        {
            char opperator = parse.GetOperator(input);
            if (opperator == '=')
            {
                return true;
            } else
            {
                return false;
            }
        }


        public static Dictionary<char, int> AddToDictionary(string response)
        {
            Constants constant = new Constants();
            bool isConstant = constant.IsConstantDeclaration(response);
            if (isConstant == true)
            {
                Dictionary<char, int> dictionary = new Dictionary<char, int>();
                int constantValue = constant.GetConstantsValue(response);
                char theConstant = constant.GetConstant(response);
                dictionary.Add(theConstant, constantValue);
                return dictionary;
            } else
            {
                throw new Exception("This is not a constant.");
            }
        }

        public int ApplyDictionary(Dictionary<char, int> dictionary, string nextProblem)
        {
            Constants constant = new Constants();
            char theConstant = constant.GetConstant(nextProblem);
            int retrieveTheValue = dictionary[theConstant];
            return retrieveTheValue;
        }
    }

    
}
