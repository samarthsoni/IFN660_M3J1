using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class IdentifierExpression : Expression
    {
        public Identifier Identifier;

        public IdentifierExpression(Identifier identifier)
        {
            Identifier = identifier;
        }
    }
}
