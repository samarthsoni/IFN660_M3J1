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

        public override void GenCode(ref string output)
        {
            output += $".assembly ConsoleApplication1"+Environment.NewLine+"{"+Environment.NewLine+"}";
            foreach (var declaration in TypeDeclarations)
                declaration.GenCode(ref output);
        }

        public override void GenStoreCode(ref string output)
        {
            
        }
    }
}
