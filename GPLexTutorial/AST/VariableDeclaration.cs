using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class VariableDeclaration : Node, IDeclaration
    {
        public IdentifierExpression IdentifierExpression;

        public Type Type;

        public int AttributeNumber;

        public VariableDeclaration(Type type, IdentifierExpression identifierExpression)
        {
            Type = type;
            IdentifierExpression = identifierExpression;
            AttributeNumber = AttributeNumbering.Instance.NextCurrentAttributeNumber();
        }

        public Type GetDeclarationType()
        {
            return Type;
        }

        public string GetName()
        {
            return IdentifierExpression.Identifier.Name; 
        }

        public int GetNumber()
        {
            return AttributeNumber;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            ls.SymbolTable.Add(IdentifierExpression.Identifier.Name, this);
        }

        public override void TypeCheck()
        {
            Type.TypeCheck();
        }

        public override void GenCode(string output)
        {
            IdentifierExpression.GenCode(output);
        }

        public override void GenStoreCode(string output)
        {
            throw new NotImplementedException();
        }
    }
}
