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
            if (other is NamedType)
            {
                return (other as NamedType).Name.Equals(Name);
            }
            else
            {
                return false;
            }
        }

        public override void GenCode(string output)
        {
            throw new NotImplementedException();
        }

        public override void GenStoreCode(string output)
        {
            throw new NotImplementedException();
        }

        public override void ResolveNames(LexicalScope ls)
        {
            
        }

        public override void TypeCheck()
        {
            
        }
    }
}
