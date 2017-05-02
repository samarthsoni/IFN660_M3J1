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

        public override void ResolveNames(LexicalScope ls)
        {
            if (ls != null)
            {
                var result =ls.Resolve(Identifier.Name);
                if(result==null)
                {
                    throw new ApplicationException($"Error: Undeclared identifier {Identifier.Name}");
                }
            }
                
            //ls.SymbolTable.Add(GetName(), this);
        }

        public Type GetDeclarationType()
        {

        }
    }
}
