using System.Collections.Generic;

namespace GPLexTutorial.AST
{
    public class CompilationUnit : Node
    {
        public List<TypeDeclaration> TypeDeclarations { get; set; }
        public CompilationUnit(List<TypeDeclaration> typeDeclarations)
        {
            TypeDeclarations = typeDeclarations;
        }
    }
}
