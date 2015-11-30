using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;
using System.Collections.Generic;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ParseEnsureICanCreateAnInstance()
        {
            Parse parse = new Parse();
            Assert.IsNotNull(parse);
        }

        [TestMethod]
        public void ParseEnsureThatTheArrayOfIntCanBeCreated()
        {
            Parse parse = new Parse();
            //string toInt =  "1 + 2";
            List<int> numbers = parse.GetNumbers();
            Assert.AreEqual(1, numbers[0]);
        }
        [TestMethod]
        public void ParseEnsureThatICanSplitDataintoStringArray()
        {
            Parse parse = new Parse();
            string toInt =  "1 + 2";
            List<string> numbers = parse.GetNumbers(toInt);
            Assert.AreEqual("1", numbers[0]);
        }

        [TestMethod]
        public void ParseEnsureThatICanConvertTheStringArrayIntoIntArray()
        {
            Parse parse = new Parse();
            string toInt = "1 + 2";
            List<string> numbers = parse.GetNumbers(toInt);
            List<int> numberInts = parse.MakeInts(numbers);
            Assert.AreEqual(1, numberInts[0]);
        }
        
        [TestMethod]
        public void ParseEnsureThatICanExtractTheOperatorEmbededInTheExpression()
        {
            Parse parse = new Parse();
            string toOperator = "1 + 2";
            char theOperator = parse.GetOperator(toOperator);
            Assert.AreEqual('+', theOperator);
        }

        [TestMethod]
        public void ParseEnsureThatICanUseTheOperatorWithTwoNumbers()
        {
            Parse parse = new Parse();
            string toOperator = "1 + 2";
            List<string> numbers = parse.GetNumbers(toOperator);
            List<int> numberInts = parse.MakeInts(numbers);
            int num1 = numberInts[0];
            int num2 = numberInts[1];
            char theOperator = parse.GetOperator(toOperator);
            int calculator = parse.Calculate(theOperator, num1, num2 );
            Assert.AreEqual(3, calculator);
        }

        [TestMethod]
        public void ParseEnsureThatICanUseSubtraction()
        {
            Parse parse = new Parse();
            string toOperator = "2 - 1";
            List<string> numbers = parse.GetNumbers(toOperator);
            List<int> numberInts = parse.MakeInts(numbers);
            int num1 = numberInts[0];
            int num2 = numberInts[1];
            char theOperator = parse.GetOperator(toOperator);
            int calculator = parse.Calculate(theOperator, num1, num2);
            Assert.AreEqual(1, calculator);

        }

        [TestMethod]
        public void ParseEnsureThatICanUseMultiplication()
        {
            Parse parse = new Parse();
            string toOperator = "2 * 1";
            List<string> numbers = parse.GetNumbers(toOperator);
            List<int> numberInts = parse.MakeInts(numbers);
            int num1 = numberInts[0];
            int num2 = numberInts[1];
            char theOperator = parse.GetOperator(toOperator);
            int calculator = parse.Calculate(theOperator, num1, num2);
            Assert.AreEqual(2, calculator);
        }

        [TestMethod]
        public void ParseEnsureThatICanUseDivision()
        {
            Parse parse = new Parse();
            string toOperator = "2 / 1";
            List<string> numbers = parse.GetNumbers(toOperator);
            List<int> numberInts = parse.MakeInts(numbers);
            int num1 = numberInts[0];
            int num2 = numberInts[1];
            char theOperator = parse.GetOperator(toOperator);
            int calculator = parse.Calculate(theOperator, num1, num2);
            Assert.AreEqual(2, calculator);
        }

        [TestMethod]
        public void ParseEnsureThatICanUseNegativeNumbersDivide()
        {
            Parse parse = new Parse();
            string toOperator = "2 / -1";
            List<string> numbers = parse.GetNumbers(toOperator);
            List<int> numberInts = parse.MakeInts(numbers);
            int num1 = numberInts[0];
            int num2 = numberInts[1];
            char theOperator = parse.GetOperator(toOperator);
            int calculator = parse.Calculate(theOperator, num1, num2);
            Assert.AreEqual(-2, calculator);
        }
        [TestMethod]
        public void ParseEnsureThatICanUseNegativeNumbersMultiple()
        {
            Parse parse = new Parse();
            string toOperator = "2 * -1";
            List<string> numbers = parse.GetNumbers(toOperator);
            List<int> numberInts = parse.MakeInts(numbers);
            int num1 = numberInts[0];
            int num2 = numberInts[1];
            char theOperator = parse.GetOperator(toOperator);
            int calculator = parse.Calculate(theOperator, num1, num2);
            Assert.AreEqual(-2, calculator);

        }
        [TestMethod]
        public void ParseEnsureThatICanUseNegativeNumbersAdd()
        {
            Parse parse = new Parse();
            string toOperator = "2 + -1";
            List<string> numbers = parse.GetNumbers(toOperator);
            List<int> numberInts = parse.MakeInts(numbers);
            int num1 = numberInts[0];
            int num2 = numberInts[1];
            char theOperator = parse.GetOperator(toOperator);
            int calculator = parse.Calculate(theOperator, num1, num2);
            Assert.AreEqual(1, calculator);
        }
        [TestMethod]
        public void ParseEnsureThatICanUseNegativeNumbersSubratact()
        {
            Parse parse = new Parse();
            string toOperator = "-2 - 1";
            List<string> numbers = parse.GetNumbers(toOperator);
            List<int> numberInts = parse.MakeInts(numbers);
            int num1 = numberInts[0];
            int num2 = numberInts[1];
            char theOperator = parse.GetOperator(toOperator);
            int calculator = parse.Calculate(theOperator, num1, num2);
            Assert.AreEqual(-3, calculator);
        }

        [TestMethod]
        //[ExpectedException(typeof(Exception), "invalid input")]
        public void ParseEnsureThatBadInputIsInvalid()
        {
            Parse parse = new Parse();
            string toOperator = "2 + + 1";
            bool validData = parse.ValidateData(toOperator);
            Assert.IsFalse(validData);
            
        }

        [TestMethod]
        public void ParseEnsureThatGoodInputIsValid()
        {
            Parse parse = new Parse();
            string toOperator = "2 + 1";
            bool validData = parse.ValidateData(toOperator);
            Assert.IsTrue(validData);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "invalid input")]
        public void ParseEnsureThatBadInputIsInvalidWhenParsingNumbers()
        {
            Parse parse = new Parse();
            string toOperator = "2 + + 1";
            List<string> numbers = parse.GetNumbers(toOperator);
        }

        [TestMethod]
        //[ExpectedException(typeof(Exception), "invalid input")]
        public void ParseEnsureThatThreeNumbersBadInputIsInvalidWhenParsingNumbers()
        {
            Parse parse = new Parse();
            string toOperator = "2 + 1 1";
            bool validData = parse.ValidateData(toOperator);
            Assert.IsFalse(validData);
            Assert.AreEqual(false, validData);


        }
    }
}
