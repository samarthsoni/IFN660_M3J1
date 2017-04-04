using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class MethodDeclaration : MemberDeclaration
    {
        public List<MethodModifier> MethodModifiers { get; set; }
        public Type Result { get; set; }
        public Identifier Identifier { get; set; }
        public List<FormalParameter> FormalParameterList { get; set; }
        public List<Statement> BodyStatements { get; set; }
        public MethodDeclaration(List<MethodModifier> methodModifier, Type result, List<FormalParameter> formalParameterList, List<Statement> bodyStatements)
        {
            MethodModifiers = methodModifier;
            Result = result;
            FormalParameterList = formalParameterList;
            BodyStatements = bodyStatements;
        }
    }
}