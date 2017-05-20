using System;

namespace GPLexTutorial.AST
{
    public class IntegerLiteralExpression:Expression
    {
        public int Value { get; set; }

        public IntegerLiteralExpression(int val)
        {
            Value = val;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            
        }

        public override void TypeCheck()
        {
            type = new NamedType(typeof(int).Name);
        }

        public override void GenCode(ref string output)
        {
            output += Environment.NewLine + $"ldc.i4.s {Value}" ;
        }

        public override void GenStoreCode(ref string output)
        {
            
        }
    }
}