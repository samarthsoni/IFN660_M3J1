using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class NamedType : Type
    {
        public string Name;

        public NamedType(string name)
        {
            Name = name;
        }

        public override bool Equal(Type other)
        {
            throw new NotImplementedException();
        }

        public override void ResolveNames(LexicalScope ls)
        {
            throw new NotImplementedException();
        }

        public override void TypeCheck()
        {
            throw new NotImplementedException();
        }
    }
}
