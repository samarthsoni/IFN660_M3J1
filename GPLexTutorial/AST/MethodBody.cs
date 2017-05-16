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
        public LexicalScope LexicalScope { get; set; }

        public MethodBody(List<Statement> bodyStatements)
        {
            BodyStatements = bodyStatements;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            LexicalScope = new LexicalScope(ls);
            foreach (var statement in BodyStatements)
                statement.ResolveNames(LexicalScope);
        }

        public override void TypeCheck()
        {
            foreach (var statement in BodyStatements)
                statement.TypeCheck();
        }

        public override void GenCode(string output)
        {
            foreach (var statement in BodyStatements)
                statement.GenCode(output);
        }

        public override void GenStoreCode(string output)
        {
            throw new NotImplementedException();
        }
    }
}
