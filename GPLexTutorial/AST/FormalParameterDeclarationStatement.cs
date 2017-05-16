using System;

namespace GPLexTutorial.AST
{
    public class FormalParameterDeclarationStatement : Statement, IDeclaration
    {
        public Type Type { get; set; }
        public Expression IdentifierExpression { get; set; }
        public int AttributeNumber { get; set; }
        public FormalParameterDeclarationStatement(Type type, Expression identifierExpression)
        {
            Type = type;
            IdentifierExpression = identifierExpression;
            AttributeNumber = AttributeNumbering.Instance.NextCurrentAttributeNumber();
        }

        public string GetName()
        {
            return ((IdentifierExpression) IdentifierExpression).Identifier.Name;
            //if (IdentifierExpression is IDeclaration)
            //    return ((IDeclaration) IdentifierExpression).GetName();
            //else
            //    return null;
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

        public int GetNumber()
        {
            return AttributeNumber;
        }
    }

}