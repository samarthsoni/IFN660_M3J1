using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodHeaderExpression : Expression
    {
        public Type Result;
        public Expression MethodDeclarator;

        public MethodHeaderExpression(Type result,Expression methodDeclarator)
        {
            MethodDeclarator = methodDeclarator;
            Result = result;
        }
    }
}
