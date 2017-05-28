using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    class IdentifierInitializationExpression:Expression
    {
        public IdentifierExpression IdentifierExpression { get; set; }

        public Expression Value { get; set; }
        [JsonIgnore]
        public IDeclaration Declaration { get; set; }

        public IdentifierInitializationExpression(Expression identifierExpression, Expression value)
        {
            IdentifierExpression = (IdentifierExpression)identifierExpression;
            Value = value;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            throw new NotImplementedException();
        }

        public override void TypeCheck()
        {
            throw new NotImplementedException();
        }

        public override void GenCode(ref string output)
        {
            throw new NotImplementedException();
        }

        public override void GenStoreCode(ref string output)
        {
            throw new NotImplementedException();
        }



        //public override void ResolveNames(LexicalScope ls)
        //{
        //    if (ls != null)
        //    {
        //        var result = ls.Resolve(Identifier.Name);
        //        if (result == null)
        //        {
        //            throw new ApplicationException($"Error: Undeclared identifier {Identifier.Name}");
        //        }
        //        else
        //        {
        //            Declaration = result;
        //            type = Declaration.GetDeclarationType();
        //        }

        //    }

        //    //ls.SymbolTable.Add(GetName(), this);
        //}

        //public override void TypeCheck()
        //{
        //}

        //public override void GenCode(ref string output)
        //{
        //    output += Environment.NewLine + $"ldloc.{Declaration.GetNumber()}";
        //}

        //public override void GenStoreCode(ref string output)
        //{
        //    output += Environment.NewLine + $"stloc.{Declaration.GetNumber()}";
        //}
    }
}
