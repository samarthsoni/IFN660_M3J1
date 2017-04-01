using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class MethodDeclaration
    {
        public List<MethodModifier> MethodModifier { get; set; }
        public Result Result { get; set; }
        public MethodDeclarator MethodDeclarator { get; set; }
    }
}