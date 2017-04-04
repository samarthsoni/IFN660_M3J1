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
        public MethodDeclaration(List<MethodModifier> methodModifier, Result result, MethodDeclarator methodDeclarator)
        {
            MethodModifier = methodModifier;
            Result = result;
            MethodDeclarator = methodDeclarator;
        }
    }
}