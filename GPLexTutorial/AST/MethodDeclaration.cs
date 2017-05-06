using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class MethodDeclaration : MemberDeclaration,IDeclaration
    {
        public MethodHeader MethodHeader;
        public List<MethodModifier> MethodModifiers { get; set; }
        public Statement MethodBody;
        public LexicalScope LexicalScope { get; set; }
        public MethodDeclaration(List<MethodModifier> methodModifier, MethodHeader methodHeader , Statement methodBody)
        {
            MethodHeader = methodHeader;
            MethodModifiers = methodModifier;
            MethodBody = methodBody;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            LexicalScope = new LexicalScope(ls);
            MethodHeader.ResolveNames(ls);
            MethodBody.ResolveNames(LexicalScope);
        }

        public string GetName()
        {
            return ((MethodDeclarator)MethodHeader.MethodDeclarator).Identifier.Name;  
        }

        public Type GetDeclarationType()
        {
            return MethodHeader.Result;
        }

        public override void TypeCheck()
        {
           
        }
    }
}