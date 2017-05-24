﻿using System;
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
            LeftHAndSide.GenCode(ref output);
            RightHandSide.GenCode(ref output);
            switch (Operator)
            {
                case '<':
                     output += "clt";
                    break;
                case '>':
                    output += "cgt";
                    break;
                default:
                    throw new ApplicationException($"Error: Unexpected binary expression: {Operator}");
            }
        }

        public override void ResolveNames(LexicalScope ls)
        {
            LeftHAndSide.ResolveNames(ls);
            RightHandSide.ResolveNames(ls);
        }

        public override void TypeCheck()
        {
            LeftHAndSide.TypeCheck();
            RightHandSide.TypeCheck();

            switch (Operator)
            {
                case '<':
                    if(!LeftHAndSide.type.Equal(new IntType())|| !RightHandSide.type.Equal(new IntType()))
                    {
                        throw new ApplicationException($"Error: '<' TypeCheck error");
                    }
                    type = new BoolType();
                    break;
                case '>':
                    if (!LeftHAndSide.type.Equal(new IntType()) || !RightHandSide.type.Equal(new IntType()))
                    {
                        throw new ApplicationException($"Error: '>' TypeCheck error");
                    }
                    type = new BoolType();
                    break;
                default:
                    throw new ApplicationException($"Error: Unexpected binary expression: {Operator}");
            }
        }
    }
}
