using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    class BasicForStatement : Statement
    {
        public BasicForStatement(Statement forInit, Expression expression, Expression ForUpdate, Statement statement)
        {

        }
        public override void GenCode(ref string output)
        {
            throw new NotImplementedException();
        }

        public override void GenStoreCode(ref string output)
        {
            throw new NotImplementedException();
        }

        public override void ResolveNames(LexicalScope ls)
        {
            throw new NotImplementedException();
        }

        public override void TypeCheck()
        {
            throw new NotImplementedException();
        }
    }
}
