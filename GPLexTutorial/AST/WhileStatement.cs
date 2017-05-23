using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class WhileStatement : Statement
    {
        public Expression Expression;
        public Statement Statement;

        public WhileStatement(Expression expression, Statement statement)
        {
            Expression = expression;
            Statement = statement;
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
