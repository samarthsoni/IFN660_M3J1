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
        public Identifier Identifier;
        public List<Statement> FormalParameterList;

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

        public override void GenCode(string output)
        {
            throw new NotImplementedException();
        }

        public override void GenStoreCode(string output)
        {
            throw new NotImplementedException();
        }
    }
}
