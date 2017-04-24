using System;
using System.Collections.Generic;

namespace GPLexTutorial.AST
{
    public class VariableDeclarationStatement : Statement, ILexicalScope
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

        public IDeclaration Resolve(string name)
        {
            return LexicalScope.Resolve(name);
        }

        public void InitializeLexicalScope(LexicalScope parentLexicalScope)
        {
            var declarations = new Dictionary<string, IDeclaration>();
            foreach (Expression identifierExpression in IdentifierExpressions)
            {
                if (identifierExpression is IdentifierExpression)
                {
                    var declaration = (IdentifierExpression)identifierExpression;
                    declarations.Add(declaration.GetName(), declaration);
                }
            }
            LexicalScope = new LexicalScope(declarations, parentLexicalScope);
        }

        public LexicalScope GetLexicalScope()
        {
            return LexicalScope;
        }
    }
}