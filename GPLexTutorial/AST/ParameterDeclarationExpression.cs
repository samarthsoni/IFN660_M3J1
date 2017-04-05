namespace GPLexTutorial.AST
{
    public class ParameterDeclarationExpression : Expression
    {
        public Type Type { get; set; }
        public Expression IdentifierExpression { get; set; }
        public ParameterDeclarationExpression(Type type, Expression identifierExpression)
        {
            Type = type;
            IdentifierExpression = identifierExpression;
        }
    }
}