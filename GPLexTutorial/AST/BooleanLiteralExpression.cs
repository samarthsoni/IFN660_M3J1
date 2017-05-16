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

        public override void GenCode(string output)
        {
            output += Value;
        }

        public override void GenStoreCode(string output)
        {
            output += Value;
        }
    }
}