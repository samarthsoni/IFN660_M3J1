using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodDeclarator : Node,ILexicalScope
    {
        public Identifier Identifier;
        public List<Statement> FormalParameterList;
        public LexicalScope LexicalScope { get; set; }

        public MethodDeclarator(Identifier identifier, List<Statement> formalParameterList)
        {
            FormalParameterList = formalParameterList;
            Identifier = identifier;
        }

        public IDeclaration Resolve(string name)
        {
            return LexicalScope.Resolve(name);
        }

        public void InitializeLexicalScope(LexicalScope parentLexicalScope)
        {
            var declarations = new Dictionary<string, IDeclaration>();
            foreach (Statement formalParameterStatement in FormalParameterList)
            {
                if (formalParameterStatement is ParameterDeclarationStatement)
                {
                    var declaration = (IDeclaration)formalParameterStatement;
                    declarations.Add(declaration.GetName(), declaration);
                }
            }
            LexicalScope = new LexicalScope(declarations,parentLexicalScope);
        }

        public LexicalScope GetLexicalScope()
        {
            return LexicalScope;
        }
    }
}
