using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class WhileStatement : Statement
    {
        public Expression Condition;
        public Statement Statement;

        public WhileStatement(Expression condition, Statement statement)
        {
            Condition = condition;
            Statement = statement;
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
            Condition.ResolveNames(ls);
            Statement.ResolveNames(ls);
        }

        public override void TypeCheck()
        {
            Condition.TypeCheck();
            if(!Condition.type.Equal(new BoolType()))
            {
                throw new ApplicationException($"Error: While Statement TypeCheck error");
            }
            Statement.TypeCheck();
        }
    }
}
