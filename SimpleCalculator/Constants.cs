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
    }

    
}
