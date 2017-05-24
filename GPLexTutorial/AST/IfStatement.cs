using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class IfStatement : Statement
    {
        public Expression Condition;
        public Statement ThenStatement, ElseStatement;

        public IfStatement(Expression condition, Statement thenStatement, Statement elseStatement)
        {
            Condition = condition;
            ThenStatement = thenStatement;
            ElseStatement = elseStatement;
        }

        public override void GenCode(ref string output)
        {
            Condition.GenCode(ref output);
            int elseLabel = LastLabel++;
            output += "brfalse L"+ elseLabel;
            ThenStatement.GenCode(ref output);
            output += "L" + elseLabel + ":";
            ElseStatement.GenCode(ref output);
        }

        public override void GenStoreCode(ref string output)
        {

        }

        public override void ResolveNames(LexicalScope ls)
        {
            Condition.ResolveNames(ls);
            ThenStatement.ResolveNames(ls);
            ElseStatement.ResolveNames(ls);
        }

        public override void TypeCheck()
        {
            Condition.TypeCheck();
            if(!Condition.type.Equal(new BoolType()))
            {
                throw new ApplicationException($"Error: If Statement TypeCheck error");
            }
            ThenStatement.TypeCheck();
            ElseStatement.TypeCheck();
        }
    }
}
