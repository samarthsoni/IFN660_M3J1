namespace GPLexTutorial.AST
{
    public class ParameterDeclarationStatement : Statement, IDeclaration
    {
        public Type Type { get; set; }
        public Expression IdentifierExpression { get; set; }
        public ParameterDeclarationStatement(Type type, Expression identifierExpression)
        {
            Type = type;
            IdentifierExpression = identifierExpression;
        }

        public string GetName()
        {
            if (IdentifierExpression is IDeclaration)
                return ((IDeclaration) IdentifierExpression).GetName();
            else
                return null;
        }
    }
}