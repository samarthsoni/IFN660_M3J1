using System.Collections.Generic;
using System.Security.AccessControl;

namespace GPLexTutorial.AST
{
    public class MethodDeclarator
    {
        public Identifier Identifier { get; set; }
        public List<FormalParameter> FormalParameterList { get; set; }
        public List<Statement> BodyStatements { get; set; }
        public MethodDeclarator(Identifier identifier, List<FormalParameter> formalParameterList, List<Statement> bodyStatements)
        {
            Identifier = identifier;
            FormalParameterList = formalParameterList;
            BodyStatements = bodyStatements;
        }
    }
}