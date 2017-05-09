using System;

namespace GPLexTutorial.AST
{
    public class StringLiteralExpression:Expression
    {
        public string Value { get; set; }

        public StringLiteralExpression(string val)
        {
            Value = val;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            
        }

        public override void TypeCheck()
        {
            type = new NamedType(typeof(string).Name);
        }
    }
}