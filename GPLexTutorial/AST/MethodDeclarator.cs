using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodDeclarator : Node
    {
        public Identifier Identifier;
        public List<Statement> FormalParameterList;

        public MethodDeclarator(Identifier identifier, List<Statement> formalParameterList)
        {
            FormalParameterList = formalParameterList;
            Identifier = identifier;
        }
    }
}
