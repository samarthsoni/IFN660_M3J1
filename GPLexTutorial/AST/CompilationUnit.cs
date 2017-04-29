using System;
using System.Collections.Generic;

namespace GPLexTutorial.AST
{
    public class CompilationUnit : Node
    {
        public List<TypeDeclaration> TypeDeclarations { get; set; }
        public LexicalScope LexicalScope { get; set; }
        public CompilationUnit(List<TypeDeclaration> typeDeclarations)
        {
            TypeDeclarations = typeDeclarations;
            LexicalScope = new LexicalScope(null);
        }

        public override void ResolveNames(LexicalScope ls)
        {
            foreach (var declaration in TypeDeclarations)
                declaration.ResolveNames(LexicalScope);
        }
    }
}
