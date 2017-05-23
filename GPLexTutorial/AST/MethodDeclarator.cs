using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodDeclarator : Node
    {
        public Identifier Identifier { get; set; }
        public List<Statement> FormalParameterList { get; set; }

        public MethodDeclarator(Identifier identifier, List<Statement> formalParameterList)
        {
            FormalParameterList = formalParameterList;
            Identifier = identifier;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            foreach (var FormalParameter in FormalParameterList)
                FormalParameter.ResolveNames(ls);
        }

        public override void TypeCheck()
        {
            foreach (var FormalParameter in FormalParameterList)
                FormalParameter.TypeCheck();
        }

        public override void GenCode(ref string output)
        {
            output+=$" {this.Identifier.Name}";
            output += "(";
            foreach(var param in FormalParameterList)
            {
                param.GenCode(ref output);
            }
            output += ")"+Environment.NewLine+"{";
        }

        public override void GenStoreCode(ref string output)
        {
            
        }
    }
}
