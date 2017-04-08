using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class MethodDeclaration : MemberDeclaration
    {
        public Node MethodHeader;
        public List<MethodModifier> MethodModifiers { get; set; }
        public List<Statement> BodyStatements { get; set; }
        public MethodDeclaration(List<MethodModifier> methodModifier, Node methodHeader , List<Statement> bodyStatements)
        {
            MethodHeader = methodHeader;
            MethodModifiers = methodModifier;
            BodyStatements = bodyStatements;
        }
    }
}