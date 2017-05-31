using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    class BasicForStatement : Statement
    {
        Statement ForInit { get; set; }
        Expression Expression { get; set; }
        Expression ForUpdate { get; set; }
        Statement Statement { get; set; }
        public LexicalScope LexicalScope { get; set; }

        public BasicForStatement(Statement forInit, Expression expression, Expression forUpdate, Statement statement)
        {
            ForInit = forInit;
            Expression = expression;
            ForUpdate = forUpdate;
            Statement = statement;
        }
        public override void GenCode(ref string output)
        {
            ForInit.GenCode(ref output);
            Expression.GenCode(ref output);
            ForUpdate.GenCode(ref output);
            Statement.GenCode(ref output);
        }

        public override void GenStoreCode(ref string output)
        {
            
        }

        public override void ResolveNames(LexicalScope ls)
        {
            LexicalScope = new LexicalScope(ls);
            ForInit.ResolveNames(ls);
            Expression.ResolveNames(ls);
            ForUpdate.ResolveNames(ls);
            Statement.ResolveNames(LexicalScope);
        }

        public override void TypeCheck()
        {
            ForInit.TypeCheck();
            Expression.TypeCheck();
            ForUpdate.TypeCheck();
            Statement.TypeCheck();
        }
    }
}
