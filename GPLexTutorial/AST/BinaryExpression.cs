using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class BinaryExpression : Expression
    {
        public char Operator;
        public Expression LeftHAndSide, RightHandSide;

        public BinaryExpression(Expression lhs,char op,Expression rhs)
        {
            LeftHAndSide = lhs;
            Operator = op;
            RightHandSide = rhs;
        }

        public override void GenCode(ref string output)
        {
            throw new NotImplementedException();
        }

        public override void GenStoreCode(ref string output)
        {
            throw new NotImplementedException();
        }

        public override void ResolveNames(LexicalScope ls)
        {
            LeftHAndSide.ResolveNames(ls);
            RightHandSide.ResolveNames(ls);
        }

        public override void TypeCheck()
        {
            throw new NotImplementedException();
        }
    }
}
