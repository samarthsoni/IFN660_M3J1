using System;

namespace GPLexTutorial.AST
{
    public class AssignmentExpression : Expression
    {
        private Expression LeftExpression;
        private Expression RightExpression;

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

        public override void TypeCheck()
        {
            LeftExpression.TypeCheck();
            RightExpression.TypeCheck();
            if (RightExpression.type.Compatible(LeftExpression.type))
            {
                throw new ApplicationException($"Error: TypeCheck error");
            }
            type = RightExpression.type;
        }
    }
}