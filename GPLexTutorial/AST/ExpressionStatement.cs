namespace GPLexTutorial.AST
{
    public class ExpressionStatement : Statement
    {
        public Expression Expression;

        public ExpressionStatement(Expression expression)
        {
            Expression = expression;
        }
    }
}