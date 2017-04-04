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
    }
}