using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;
using System.Collections.Generic;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class StackTests
    {
        private object parse;

        [TestMethod]
        public void EvaluateEnsureICanCreateAnInstance()
        {
            Stack evaluate = new Stack();
            Assert.IsNotNull(evaluate);
        }

        [TestMethod]
        public void StackEnsureICanSetLastq()
        {
            Stack monkey = new Stack();
            string input = "1 + 2";
            monkey.lastq = input;
            Assert.AreEqual("1 + 2", monkey.lastq);
        }

        [TestMethod]
        public void StackEnsureICanSetLast()
        {
            Stack monkey = new Stack();
            Parse parse = new Parse();
            string input = "1 + 2";
            char theOperator = parse.GetOperator(input);
            List<string> numbers = parse.GetNumbers(input);
            List<int> numberInts = parse.MakeInts(numbers);
            int num1 = numberInts[0];
            int num2 = numberInts[1];
            int calculator = parse.Calculate(theOperator, num1, num2);
            Assert.AreEqual(3, calculator);
        }

        //[TestMethod]
        //public void EvaluateEnsureCanCreateLastq()
        //{
        //    Stack eveluate = new Stack();
        //    string toOperator = "1 + 2";
        //    string lastq = Stack.GetLast(toOperator);
        //    Assert.AreEqual("1 + 2", lastq);
        //}
        //[TestMethod]
        //public void EvaluateEnsureCanCreatLastAnser()
        //{
        //    Stack evaluate = new Stack();
        //    Parse parse = new Parse();
        //    string input = "1 + 2";
        //    string lastq = Stack.GetLast(input);
        //    List<string> numbers = parse.GetNumbers(lastq);
        //    List<int> numberInts = parse.MakeInts(numbers);
        //    int num1 = numberInts[0];
        //    int num2 = numberInts[1];
        //    char theOperator = parse.GetOperator(lastq);
        //    int calculator = parse.Calculate(theOperator, num1, num2);
        //    Assert.AreEqual("1 + 2", lastq);
        //}
    }
}
