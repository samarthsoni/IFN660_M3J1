using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodHeader : Node
    {
        public Type Result;
        public Node MethodDeclarator;

        public MethodHeader(Type result,Node methodDeclarator)
        {
            MethodDeclarator = methodDeclarator;
            Result = result;
        }
    }
}
