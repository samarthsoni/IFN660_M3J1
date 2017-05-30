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

        public override void GenCode(ref string output)
        {
            output += $"ldstr \"{Value}\"";
        }

        public override void GenStoreCode(ref string output)
        {
            output += Value;
        }
    }
}