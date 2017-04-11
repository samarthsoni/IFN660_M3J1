using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodDeclarator : Node, ILexicalScope
    {
        public Identifier Identifier;
        public List<Statement> FormalParameterList;
        public Dictionary<string, IDeclaration> Declarations { get; set; }
        public ILexicalScope ParentLexicalScope { get; set; }

        public MethodDeclarator(Identifier identifier, List<Statement> formalParameterList)
        {
            FormalParameterList = formalParameterList;
            Identifier = identifier;
            Declarations = new Dictionary<string, IDeclaration>();
            foreach (Statement formalParameterStatement in formalParameterList)
            {
                if (formalParameterStatement is ParameterDeclarationStatement)
                {
                    var declaration = (IDeclaration) formalParameterStatement;
                    Declarations.Add(declaration.GetName(),declaration);
                }
                    
            }
        }
        public IDeclaration Resolve(string name)
        {
            if (Declarations.ContainsKey(name))
                return Declarations[name];
            else if (this.ParentLexicalScope!= null)
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
