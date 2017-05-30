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

        public override void GenCode(ref string output)
        {
            output += Environment.NewLine + $"ldc.r4 {Value.ToString("R")}";
        }

        public override void GenStoreCode(ref string output)
        {
            output += Value;
        }
    }
}