using System.Collections.Generic;

namespace GPLexTutorial.AST
{
    public class MethodDeclarator
    {
        public Identifier Identifier { get; set; }
        public List<FormalParameter> FormalParameterList { get; set; }
    }
}