using System;

namespace GPLexTutorial.AST
{
    public class AssignmentExpression : Expression
    {
        public Expression LeftExpression;
        public Expression RightExpression;

        public AssignmentExpression(Expression leftExpression, Expression rightExpression)
        {
            RightExpression = rightExpression;
            LeftExpression = leftExpression;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            LeftExpression.ResolveNames(ls);
            RightExpression.ResolveNames(ls);
        }
    }
}