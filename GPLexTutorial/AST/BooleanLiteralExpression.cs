using System;

namespace GPLexTutorial.AST
{
    public class BooleanLiteralExpression:Expression
    {
        public bool Value { get; set; }

        public BooleanLiteralExpression(bool val)
        {
            Value = val;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            
        }

        public override void TypeCheck()
        {
            type = new NamedType(typeof(bool).Name);
        }

        public override void GenCode(ref string output)
        {
            output += Environment.NewLine + $"ldc.i4.{(Value?"1":"0")}";
        }

        public override void GenStoreCode(ref string output)
        {
            output += Value;
        }
    }
}