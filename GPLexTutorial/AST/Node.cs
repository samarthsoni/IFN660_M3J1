using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public abstract class Node
    {
        public abstract void ResolveNames(LexicalScope ls);
    }
}
