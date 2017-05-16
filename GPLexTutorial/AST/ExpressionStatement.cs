using System;

namespace GPLexTutorial.AST
{
    public class ExpressionStatement : Statement
    {
        public Expression Expression;

        public ExpressionStatement(Expression expression)
        {
            Expression = expression;
        }

        public override void GenCode(string output)
        {
            Expression.GenCode(output);
        }

        public override void GenStoreCode(string output)
        {
            throw new NotImplementedException();
        }

        public override void ResolveNames(LexicalScope ls)
        {
            Expression.ResolveNames(ls);
        }

        public override void TypeCheck()
        {
            Expression.TypeCheck();
        }
    }
}