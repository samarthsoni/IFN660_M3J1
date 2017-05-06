using System;

namespace GPLexTutorial.AST
{
    public class FormalParameterDeclarationStatement : Statement, IDeclaration
    {
        public Type Type { get; set; }
        public Expression IdentifierExpression { get; set; }
        public FormalParameterDeclarationStatement(Type type, Expression identifierExpression)
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

        public override void ResolveNames(LexicalScope ls)
        {
            ls.SymbolTable.Add(GetName(), this);
        }

        public Type GetDeclarationType()
        {
            return Type;
        }

        public override void TypeCheck()
        {
            Type.TypeCheck();
        }
    }

}