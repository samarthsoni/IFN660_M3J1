using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    class MethodBody : Statement
    {
        public List<Statement> BodyStatements { get; set; }

        public MethodBody(List<Statement> bodyStatements)
        {
            BodyStatements = bodyStatements;
        }
    }
}
