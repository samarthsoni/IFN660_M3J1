using System;
using System.Collections.Generic;

namespace GPLexTutorial.AST
{
    public class CompilationUnit : Node
    {
        public List<Type> TypeDeclarations { get; set; }
        public LexicalScope LexicalScope { get; set; }
        public CompilationUnit(List<Type> typeDeclarations)
        {
            TypeDeclarations = typeDeclarations;
            LexicalScope = new LexicalScope(null);
        }

        public override void ResolveNames(LexicalScope ls)
        {
            foreach (var declaration in TypeDeclarations)
                declaration.ResolveNames(LexicalScope);
        }

        public override void TypeCheck()
        {
            foreach (var declaration in TypeDeclarations)
                declaration.TypeCheck();
        }

        public override void GenCode(string output)
        {
            throw new NotImplementedException();
        }

        public override void GenStoreCode(string output)
        {
            throw new NotImplementedException();
        }
    }
}
