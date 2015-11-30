using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Parse
    {
      

        public List<int> GetNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3 };
            return numbers;
        }

        public List<string> GetNumbers(string toInt)
        {
            bool valid = ValidateData(toInt);
            if (valid == true)
            {
                Char[] delimiterChars = { ' ' };
                string[] numbers = toInt.Split(delimiterChars);
                List<string> numberInt = numbers.ToList();
                return numberInt;
            } else
            {
                throw new Exception("invalid data");
            }
        }

        public List<int> MakeInts(List<string> numberInt)
        {
            List<int> numbers = new List<int> { };
            int x = 0;
            numbers = numberInt.Where(str => int.TryParse(str, out x))
                            .Select(str => x)
                            .ToList();
            return numbers;
        }

        public List<int> MakeIntsToo(List<string> numberInt, Dictionary<char, int> dictionary)
        {

            List<int> numbers = new List<int> { };
            int y = 0;
            char[] num1 = numberInt[0].ToCharArray();
            int number1 = dictionary[num1[0]];
            numbers.Add(number1);
            int x = 0;
            List<int> numbers2 = numberInt.Where(str => int.TryParse(str, out x))
                            .Select(str => x)
                            .ToList();
            numbers.AddRange(numbers2);
            return numbers;

        }

        public char GetOperator(string toOperator)
        {
            string[] numbers = toOperator.Split(':');
            foreach (char i in toOperator)
            {
                if (i == '+')
                {
                    return '+';
                }
                else if (i == '-')
                {
                    return '-';
                }
                else if (i == '*')
                {
                    return '*';
                }
                else if (i == '/')
                {
                    return '/';
                }
                else if (i == '=')
                {
                    return '=';
                }
            }
            throw new Exception("invalid input");
        }

        public int Calculate(char theOperator, int num1, int num2)
        {
            if (theOperator == '+')
            {
                return num1 + num2;
            }else if (theOperator == '-')
            {
                return num1 - num2;
            } else if (theOperator == '*')
            {
                return num1 * num2;
            } else if (theOperator == '/')
            {
                return num1 / num2;
            }
            throw new Exception("invalid input");
        }

        public bool ValidateData(string toOperator)
        {
            Regex rx = new Regex(@"[-]{0,1}[\da-z]+[\s][-+*/=]{1,1}[\s][-]{0,1}[\d]+");

            Match validated = rx.Match(toOperator);

            if (validated.Success && validated.Length == toOperator.Length)
            {
                return true;

            }
            else
            {
                return false;
                
            }
        }

        
    }
}
