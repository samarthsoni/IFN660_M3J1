using System;
using System.Collections.Generic;

namespace GPLexTutorial.AST
{
    public class VariableDeclarationStatement : Statement
    {
        public List<VariableDeclaration> VariableDeclarations { get; set; }
        public Dims Dims { get; set; }
        public LexicalScope LexicalScope { get; set; }

        public VariableDeclarationStatement(Type type, List<Expression> identifierExpressions, Dims dims)
        {
            VariableDeclarations = new List<VariableDeclaration>();
            Dims = dims;
            foreach (Expression identifierExpression in identifierExpressions)
                VariableDeclarations.Add(new VariableDeclaration(type, (IdentifierExpression)identifierExpression));

        }

        public override void ResolveNames(LexicalScope ls)
        {
            foreach (var variableDeclaration in VariableDeclarations)
            {
                variableDeclaration.ResolveNames(ls);
             }
        }

        public override void TypeCheck()
        {
            foreach (var variableDeclaration in VariableDeclarations)
            {
                variableDeclaration.TypeCheck();
            }
        }

        public override void GenCode(ref string output)
        {
            foreach (var variableDeclaration in VariableDeclarations)
            {
                variableDeclaration.GenCode(ref output);
            }
        }

        public override void GenStoreCode(ref string output)
        {
            
        }
    }
}