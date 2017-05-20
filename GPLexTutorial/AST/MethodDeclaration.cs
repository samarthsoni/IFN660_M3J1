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
           MethodBody.TypeCheck();
        }

        public int GetNumber()
        {
            return 0;
        }

        public override void GenCode(ref string output)
        {
            output += Environment.NewLine + ".method";

            foreach (var modifier in MethodModifiers)
            {
                output += $" {modifier.ToString().ToLower()}";
            }

            MethodHeader.GenCode(ref output);
            
            if (((MethodDeclarator)(MethodHeader.MethodDeclarator)).Identifier.Name.ToLower() == "main")
            {
                output += Environment.NewLine + ".entrypoint";
            }
            MethodBody.GenCode(ref output);
            output += Environment.NewLine +"ret"+Environment.NewLine+ "}";


        }

        public override void GenStoreCode(ref string output)
        {
            
        }
    }
}