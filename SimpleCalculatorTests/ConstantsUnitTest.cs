using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;
using System.Collections.Generic;

namespace SimpleCalculatorTests
{
    [TestClass]
    public class ConstantsUnitTest
    {
        [TestMethod]
        public void ConstantsEnsureCanCreateAnInstance()
        {
            Constants constant = new Constants();
            Assert.IsNotNull(constant);
        }

        [TestMethod]
        public void ConstantsEnsureInputDefinesAConstant()
        {
            Constants constant = new Constants();
            string input = "a = 1";
            bool isConstant = constant.IsConstantDeclaration(input);
            Assert.IsTrue(isConstant);
        }

        [TestMethod]
        public void ConstantsEnsureInputIsNotAConstant()
        {
            Constants constant = new Constants();
            string input = "a + 1";
            bool isNotConstant = constant.IsConstantDeclaration(input);
            Assert.IsFalse(isNotConstant);
        }

        [TestMethod]
        public void ConstantsEnsureCanGiveConstantAValue()
        {
            Constants constant = new Constants();
            string input = "a = 1";
            char constantChar = constant.GetConstant(input);
            Assert.AreEqual('a', constantChar);
        }

        [TestMethod]
        public void ConstanstsEnsureICanGetTheValue()
        {
            Constants constant = new Constants();
            string input = "a = 1";
            int theValue = constant.GetConstantsValue(input);
            Assert.AreEqual(1, theValue);
        }

        [TestMethod]
        public void ConstantsEnsureICanRecognizeConstantDeclaration()
        {
            Constants constant = new Constants();
            string input = "a = 1";
            bool constantDeclaration = constant.IsConstantDeclaration(input);
            Assert.IsTrue(constantDeclaration);
        }

        [TestMethod]
        public void ConstantsEnsureICanSetDictionaryValue()
        {
            Constants constant = new Constants();
            string input = "a = 1";
            char constantChar = constant.GetConstant(input);
            int theValue = constant.GetConstantsValue(input);
            Dictionary<char, int> constantInt = new Dictionary<char, int>();
            constantInt.Add(constantChar, theValue);
            Assert.AreEqual(1, constantInt[constantChar]);
        }

        [TestMethod]
        public void ConstantsDeclaringTheConstantIsValidData()
        {
            Constants constant = new Constants();
            Parse parse = new Parse();
            string input = "a = 1";
            bool validate = parse.ValidateData(input);
            Assert.AreEqual(true, validate);
        }

        [TestMethod]
        public void ConstantsICanGetTheValue()
        {
            Constants constant = new Constants();
            Parse parse = new Parse();
            string input = "a = 1";
            List<int> expected = new List<int> { 1 };
            List<string> numbers = parse.GetNumbers(input);
            List<int> numberInts = parse.MakeInts(numbers);
            CollectionAssert.AreEqual(expected, numberInts);
        }

        [TestMethod]
        public void ConstantsICanSaveTheValuePairToADictionary()
        {
            string response = "a = 3";
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            dictionary = Constants.AddToDictionary(response);
            Assert.AreEqual(3, dictionary['a']);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "This is not a constant.")]
        public void ConstantsICanUseAValueFromTheDictionary()
        {
            string response = "a + 3";
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            dictionary = Constants.AddToDictionary(response);
        }

        [TestMethod]
        public void ConstatnsRetrieveFromDictionary()
        {
            string response = "a = 3";
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            dictionary = Constants.AddToDictionary(response);
            int retrieveTheValue = dictionary['a'];
            Assert.AreEqual(3, retrieveTheValue);
        }

        [TestMethod]
        public void ConstantsICanUseTheDictionary()
        {
            Parse parse = new Parse();
            string response = "a = 3";
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            dictionary = Constants.AddToDictionary(response);
            string nextProblem = "a + 4";
            char theOperator = parse.GetOperator(nextProblem);
            List<string> numbers = parse.GetNumbers(nextProblem);
            List<int> numberInts = parse.MakeIntsToo(numbers, dictionary);
            int num1 = numberInts[0];
            Assert.AreEqual(3, num1);
            int num2 = numberInts[1];
            int calculator = parse.Calculate(theOperator, num1, num2);
            Assert.AreEqual(7, calculator);
        }
    }
}
