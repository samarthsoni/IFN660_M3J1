using System;

namespace GPLexTutorial
{
    public struct MyValueType
    {
        public int num;
        public string name;
        public float floatValue;
        public string stringValue;
    };

    public enum Tokens
    {
        NUMBER = 258,
        IDENT = 259,
        BOOL = 263,
        EOF = 264,
        FLOATLITERAL = 265,
        STRINGLITERAL = 266,
        ABSTRACT = 268,
        ASSERT = 269,
        BOOLEAN = 270,
        BREAK = 271,
        BYTE = 272,
        CASE = 273,
        CATCH = 274,
        CHAR = 275,
        CLASS = 276,
        CONST = 277,
        CONTINUE = 278,
        DEFAULT = 279,
        DO = 280,
        DOUBLE = 281,
        ELSE = 282,
        ENUM = 283,
        EXTENDS = 284,
        FINAL = 285,
        FINALLY = 286,
        FLOAT = 287,
        FOR = 288,
        IF = 289,
        GOTO = 290,
        IMPLEMENTS = 291,
        IMPORT = 292,
        INSTANCEOF = 293,
        INT = 294,
        INTERFACE = 295,
        LONG = 296,
        NATIVE = 297,
        NEW = 298,
        PACKAGE = 299,
        PRIVATE = 300,
        PROTECTED = 301,
        PUBLIC = 302,
        RETURN = 303,
        SHORT = 304,
        STATIC = 305,
        STRICTFP = 306,
        SUPER = 307,
        SWITCH = 308,
        SYNCHRONIZED = 309,
        THIS = 310,
        THROW = 311,
        THROWS = 312,
        TRANSIENT = 313,
        TRY = 314,
        VOID = 315,
        VOLATILE = 316,
        WHILE = 317,

    };

    public abstract class ScanBase
    {
        public MyValueType yylval;
        public abstract int yylex();
        protected virtual bool yywrap() { return true; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                using (var input = System.IO.File.OpenRead(args[0]))
                {
                    Scanner scanner = new Scanner(input);

                    Tokens token;
                    do
                    {
                        token = (Tokens)scanner.yylex();
                        switch (token)
                        {
                            case Tokens.NUMBER:
                                Console.WriteLine("NUMBER ({0})", scanner.yylval.num);
                                break;
                            case Tokens.IDENT:
                                Console.WriteLine("IDENT ({0})", scanner.yylval.name);
                                break;
                            case Tokens.IF:
                                Console.WriteLine("IF");
                                break;
                            case Tokens.ELSE:
                                Console.WriteLine("ELSE");
                                break;
                            case Tokens.INT:
                                Console.WriteLine("INT");
                                break;
                            case Tokens.BOOL:
                                Console.WriteLine("BOOL");
                                break;
                            case Tokens.EOF:
                                Console.WriteLine("EOF");
                                break;
                            default:
                                Console.WriteLine("'{0}'", (char)token);
                                break;
                        }
                    }
                    while (token != Tokens.EOF);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

