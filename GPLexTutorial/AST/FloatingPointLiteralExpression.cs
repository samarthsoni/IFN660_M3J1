using System;

namespace GPLexTutorial.AST
{
    public class FloatingPointLiteralExpression : Expression
    {
        public float Value { get; set; }

        public FloatingPointLiteralExpression(float val)
        {
            Value = val;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            
        }

        public override void TypeCheck()
        {
            type = new NamedType(typeof(float).Name);
        }
    }
}