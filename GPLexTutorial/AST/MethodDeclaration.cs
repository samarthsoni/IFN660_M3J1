using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class MethodDeclaration : MemberDeclaration
    {
        public Node MethodHeader;
        public List<MethodModifier> MethodModifiers { get; set; }
        public Statement MethodBody;
        public MethodDeclaration(List<MethodModifier> methodModifier, Node methodHeader , Statement methodBody)
        {
            MethodHeader = methodHeader;
            MethodModifiers = methodModifier;
            MethodBody = methodBody;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            throw new NotImplementedException();
        }
    }
}