using System;
using System.Collections.Generic;
using GPLexTutorial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GPlex.Tests
{
    [TestClass]
    public class StringLiteralTests
    {
        [TestMethod]
        public void String_EmptyString()
        {
            AssertString("\"\"", string.Empty);
        }

        [TestMethod]
        public void String_singleCharacter()
        {
            AssertString("\"a\"", "a");
        }

        [TestMethod]
        public void String_MultiCharacter()
        {
            AssertString("\"asd\"", "asd");
        }

        [TestMethod]
        public void String_MultiSymbol()
        {
            AssertString("\"aasd234%$@\"", "aasd234%$@");
        }

        private static void AssertString(string input, string expected)
        {
            Scanner scanner = new Scanner();
            scanner.SetSource(new List<string>() {input});
            Tokens token = (Tokens) scanner.yylex();
            Assert.AreEqual(token, Tokens.STRINGLITERAL);
            Assert.AreEqual(expected, scanner.yylval.stringValue);
        }
    }
}
