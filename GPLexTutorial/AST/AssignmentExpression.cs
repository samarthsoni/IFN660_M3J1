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
            throw new NotImplementedException();
        }
    }
}