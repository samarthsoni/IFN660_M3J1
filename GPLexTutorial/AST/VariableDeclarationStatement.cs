using System;
using System.Collections.Generic;

namespace GPLexTutorial.AST
{
    public class VariableDeclarationStatement : Statement, IDeclaration
    {
        public Type Type { get; set; }
        public List<Expression> IdentifierExpressions { get; set; }
        public Dims Dims { get; set; }

        public LexicalScope LexicalScope { get; set; }

        public VariableDeclarationStatement(Type type, List<Expression> identifierExpressions, Dims dims)
        {
            Type = type;
            IdentifierExpressions = identifierExpressions;
            Dims = dims;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            foreach (IdentifierExpression identifierExpression in IdentifierExpressions)
            {
                ls.SymbolTable.Add(identifierExpression.Identifier.Name, this);
            }
        }

        public string GetName()
        {
            return "VariableDeclarationStatement";
        }
    }
}