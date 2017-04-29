using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodDeclarator : Node,IDeclaration
    {
        public Identifier Identifier;
        public List<Statement> FormalParameterList;

        public MethodDeclarator(Identifier identifier, List<Statement> formalParameterList)
        {
            FormalParameterList = formalParameterList;
            Identifier = identifier;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            ls.SymbolTable.Add(GetName(), this);
            foreach (var FormalParameter in FormalParameterList)
                FormalParameter.ResolveNames(ls);
        }

        public string GetName()
        {
            return Identifier.Name;
        }
    }
}
