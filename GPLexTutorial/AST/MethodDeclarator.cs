using System.Collections.Generic;
using System.Security.AccessControl;

namespace GPLexTutorial.AST
{
    public class MethodDeclarator
    {
        public Identifier Identifier { get; set; }
        public List<FormalParameter> FormalParameterList { get; set; }
        public MethodBody MethodBody { get; set; }
        public MethodDeclarator(Identifier identifier, List<FormalParameter> formalParameterList, MethodBody methodBody)
        {
            Identifier = identifier;
            FormalParameterList = formalParameterList;
            MethodBody = methodBody;
        }
    }

    public class MethodBody
    {
        public List<BlockStatement> BlockStatements { get; set; }
        public MethodBody(List<BlockStatement> blockStatements)
        {
            BlockStatements = blockStatements;
        }
    }
}