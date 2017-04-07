using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodDeclaratorExpression : Expression
    {
        public Identifier Identifier;
        public List<Expression> FormalParameterList;

        public MethodDeclaratorExpression(Identifier identifier, List<Expression> formalParameterList)
        {
            FormalParameterList = formalParameterList;
            Identifier = identifier;
        }
    }
}
