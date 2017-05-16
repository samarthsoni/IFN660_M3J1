using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class VariableDeclaration : Node, IDeclaration
    {
        public Identifier Identifier;

        public Type Type;

        public int AttributeNumber;

        public VariableDeclaration(Type type, Identifier identifier)
        {
            Type = type;
            Identifier = identifier;
            AttributeNumber = AttributeNumbering.Instance.NextCurrentAttributeNumber();
        }

        public Type GetDeclarationType()
        {
            return Type;
        }

        public string GetName()
        {
            return Identifier.Name; 
        }

        public int GetNumber()
        {
            return AttributeNumber;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            ls.SymbolTable.Add(Identifier.Name, this);
        }

        public override void TypeCheck()
        {
            Type.TypeCheck();
        }
    }
}
