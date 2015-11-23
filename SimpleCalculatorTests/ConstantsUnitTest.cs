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
    }
}
