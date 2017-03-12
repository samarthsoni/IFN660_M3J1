using System;
using System.Collections.Generic;
using GPLexTutorial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GPlex.Tests
{
    [TestClass]
    public class KeywordsTests
    {
        [TestMethod]
        public void TestAllKeywords()
        {
            AssertKeyword("abstract", "abstract");
            AssertKeyword("assert", "assert");
            AssertKeyword("boolean", "boolean");
            AssertKeyword("break", "break");
            AssertKeyword("byte", "byte");
            AssertKeyword("case", "case");
            AssertKeyword("catch", "catch");
            AssertKeyword("char", "char");
            AssertKeyword("class", "class");
            AssertKeyword("const", "const");
            AssertKeyword("continue", "continue");
            AssertKeyword("default", "default");
            AssertKeyword("do", "do");
            AssertKeyword("double", "double");
            AssertKeyword("else", "else");
            AssertKeyword("enum", "enum");
            AssertKeyword("extends", "extends");
            AssertKeyword("final", "final");
            AssertKeyword("finally", "finally");
            AssertKeyword("float", "float");
            AssertKeyword("for", "for");
            AssertKeyword("if", "if");
            AssertKeyword("goto", "goto");
            AssertKeyword("implements", "implements");
            AssertKeyword("import", "import");
            AssertKeyword("instanceof", "instanceof");
            AssertKeyword("int", "int");
            AssertKeyword("interface", "interface");
            AssertKeyword("long", "long");
            AssertKeyword("native", "native");
            AssertKeyword("new", "new");
            AssertKeyword("package", "package");
            AssertKeyword("private", "private");
            AssertKeyword("protected", "protected");
            AssertKeyword("public", "public");
            AssertKeyword("return", "return");
            AssertKeyword("short", "short");
            AssertKeyword("static", "static");
            AssertKeyword("strictfp", "strictfp");
            AssertKeyword("super", "super");
            AssertKeyword("switch", "switch");
            AssertKeyword("synchronized", "synchronized");
            AssertKeyword("this", "this");
            AssertKeyword("throw", "throw");
            AssertKeyword("throws", "throws");
            AssertKeyword("transient", "transient");
            AssertKeyword("try", "try");
            AssertKeyword("void", "void");
            AssertKeyword("volatile", "volatile");
            AssertKeyword("while", "while");
        }

        private static void AssertKeyword(string input, string expected)
        {
            Scanner scanner = new Scanner();
            scanner.SetSource(new List<string>() { input });
            Tokens token = (Tokens)scanner.yylex();
            Assert.AreEqual(token, Enum.Parse(typeof(Tokens),input.ToUpper()));
        }
    }
}
