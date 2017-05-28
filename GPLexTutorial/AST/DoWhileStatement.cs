using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    class DoWhileStatement:Statement
    {
        Statement Statement { get; set; }
        Expression Expression { get; set; }
        public LexicalScope LexicalScope { get; set; }
        public DoWhileStatement(Statement statement,Expression expression)
        {
            Statement = statement;
            Expression = expression;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            LexicalScope = new LexicalScope(ls);
            Expression.ResolveNames(ls);
            Statement.ResolveNames(LexicalScope);
        }

        public override void TypeCheck()
        {
            Expression.TypeCheck();
            Statement.TypeCheck();
        }

        public override void GenCode(ref string output)
        {
            Statement.GenCode(ref output);
            Expression.GenCode(ref output);
        }

        public override void GenStoreCode(ref string output)
        {

        }
    }
}
