namespace GPLexTutorial.AST
{
    public class ParameterDeclarationStatement : Statement
    {
        public Type Type { get; set; }
        public Expression IdentifierExpression { get; set; }
        public ParameterDeclarationStatement(Type type, Expression identifierExpression)
        {
            Type = type;
            IdentifierExpression = identifierExpression;
        }
    }
}