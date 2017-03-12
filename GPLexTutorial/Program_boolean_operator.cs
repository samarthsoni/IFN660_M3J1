using System;

namespace GPLexTutorial
{
    public enum Tokens
    {
        NUMBER = 258,
        IDENT = 259,
        IF = 260,
        ELSE = 261,
        INT = 262,
        BOOL = 263,
        EOF = 264,
        FLOAT =265,
        BOOLEAN = 266,
        OPERATOR = 268
    };

    public struct MyValueType
    {
        public int num;
        public string name;
        public float floatValue;
        public bool boolValue;
       
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
            Scanner scanner = new Scanner(Console.OpenStandardInput());

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
                    case Tokens.BOOLEAN:
                        Console.WriteLine("BOOL ({0})", scanner.yylval.boolValue);
                        break;
                    case Tokens.OPERATOR:
                        Console.WriteLine("'{0}'", scanner.yylval.name);
                        break;
                    default:
                        Console.WriteLine("'{0}'", (char)token);
                        break;
                }
            }
            while (token != Tokens.EOF);

        }
    }

}
