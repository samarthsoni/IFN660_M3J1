using System;
using System.Collections.Generic;
using GPLexTutorial;
using GPLexTutorial.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GPlex.Tests
{
    [TestClass]
    public class FloatingPointLiteralTests
    {
        private Scanner _scanner;

        public FloatingPointLiteralTests()
        {
            
        }

        [TestInitialize]
        public void Initializer()
        {
            _scanner = new Scanner();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _scanner = null;
        }

        [TestMethod]
        public void Float_DigitDotDigit()
        {
            AssertFloatRule("1.1", 1.1f);
        }

        [TestMethod]
        public void Float_DotDigit()
        {
            AssertFloatRule(".1", 0.1f);
        }

        [TestMethod]
        public void Float_DotDigitSuffix()
        {
            AssertFloatRule(".1f", 0.1f);
            AssertFloatRule(".1F", 0.1f);
            AssertFloatRule(".1d", 0.1f);
            AssertFloatRule(".1D", 0.1f);
        }

        [TestMethod]
        public void Float_DigitDotExponentPart()
        {
            AssertFloatRule("1.e-1", 0.1f);
            AssertFloatRule("1.e+1", 10f);
            AssertFloatRule("1.1E-1", 0.11f);
            AssertFloatRule("1.1E+1", 11f);
        }

        [TestMethod]
        public void Float_DigitExponentPartWithoutDot()
        {
            AssertFloatRule("1e-1", 0.1f);
            AssertFloatRule("1e+1", 10f);
            AssertFloatRule("11E-1", 1.1f);
            AssertFloatRule("11E+1", 110f);
        }


        #region Private Methods

        private void AssertFloatRule(string valueToTest, float expectedValue)
        {
            _scanner.SetSource(new List<string>() { valueToTest });
            Tokens token;
            token = (Tokens)_scanner.yylex();
            AssertIsFloat(token);
            AssertExpectedFloatValue(expectedValue);
        }

        private void AssertIsFloat(Tokens token)
        {
            Assert.AreEqual(Tokens.FLOATLITERAL, token);
        }

        private void AssertExpectedFloatValue(float expectedValue)
        {
            Assert.AreEqual(expectedValue, _scanner.yylval.floatValue);
        }


        #endregion
    }
}
