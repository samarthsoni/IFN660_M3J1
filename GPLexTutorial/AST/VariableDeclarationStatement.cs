using System.Collections.Generic;

namespace GPLexTutorial.AST
{
    public class VariableDeclarationStatement : Statement
    {
        public Type Type { get; set; }
        public List<Expression> IdentifierExpressions { get; set; }
        public Dims Dims { get; set; }
        public VariableDeclarationStatement(Type type, List<Expression> identifierExpressions, Dims dims)
        {
            Type = type;
            IdentifierExpressions = identifierExpressions;
            Dims = dims;
        }
    }
}