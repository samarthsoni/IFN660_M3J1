using System.Collections.Generic;

namespace GPLexTutorial.AST
{
    public class VariableDeclarationStatement : Statement, ILexicalScope
    {
        public Type Type { get; set; }
        public List<Expression> IdentifierExpressions { get; set; }
        public Dims Dims { get; set; }
        public Dictionary<string,IDeclaration> Declarations { get; set; }
        public ILexicalScope ParentLexicalScope { get; set; }
        public VariableDeclarationStatement(Type type, List<Expression> identifierExpressions, Dims dims)
        {
            Type = type;
            IdentifierExpressions = identifierExpressions;
            Dims = dims;
            Declarations = new Dictionary<string, IDeclaration>();
        }

        public IDeclaration Resolve(string name)
        {
            if (Declarations.ContainsKey(name))
                return Declarations[name];
            else if (this.ParentLexicalScope != null)
                return ParentLexicalScope.Resolve(name);
            else
                return null;
        }

        public void SetParentScope(ILexicalScope parentLexicalScope)
        {
            this.ParentLexicalScope = parentLexicalScope;
        }

        public ILexicalScope GetLexicalScope()
        {
            return ParentLexicalScope;
        }
    }
}