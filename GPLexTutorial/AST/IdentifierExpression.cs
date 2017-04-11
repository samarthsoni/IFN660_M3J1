using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class IdentifierExpression : Expression, IDeclaration
    {
        public Identifier Identifier;

        public IdentifierExpression(Identifier identifier)
        {
            Identifier = identifier;
        }

        public string GetName()
        {
            return Identifier.Name;
        }
    }
}
