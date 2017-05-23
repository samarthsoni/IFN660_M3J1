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

        public override void GenCode(ref string output)
        {
            output += $"{this.Name}";
        }

        public override void GenStoreCode(ref string output)
        {
            
        }

        public override void ResolveNames(LexicalScope ls)
        {
            
        }

        public override void TypeCheck()
        {
            
        }
    }
}
