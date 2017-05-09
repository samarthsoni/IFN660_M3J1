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

        public IDeclaration Declaration { get; set; }

        public IdentifierExpression(Identifier identifier)
        {
            Identifier = identifier;
        }



        public override void ResolveNames(LexicalScope ls)
        {
            if (ls != null)
            {
                var result = ls.Resolve(Identifier.Name);
                if (result == null)
                {
                    throw new ApplicationException($"Error: Undeclared identifier {Identifier.Name}");
                }
                else
                {
                    Declaration = result;
                    type = Declaration.GetDeclarationType();
                }
                    
            }

            //ls.SymbolTable.Add(GetName(), this);
        }

        public override void TypeCheck()
        {
        }
    }
}
