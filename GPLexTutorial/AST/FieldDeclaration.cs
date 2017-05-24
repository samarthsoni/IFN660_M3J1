using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class FieldDeclaration : MemberDeclaration, IDeclaration
    {
        public IdentifierExpression IdentifierExpression;
        public Type Type;
        public int AttributeNumber;
        public List<VariableDeclaration> VariableDeclarations { get; set; }
        public List<FieldModifier> FieldModifiers { get; set; }
        public LexicalScope LexicalScope { get; set; }
        public FieldDeclaration(Type type, List<Expression> identifierExpressions, List<FieldModifier> FieldModifier)
        {
            VariableDeclarations = new List<VariableDeclaration>();
            FieldModifiers = FieldModifier;
            foreach (Expression identifierExpression in identifierExpressions)
                VariableDeclarations.Add(new VariableDeclaration(type, (IdentifierExpression)identifierExpression));
        }

        public override void ResolveNames(LexicalScope ls)
        {
            ls.SymbolTable.Add(IdentifierExpression.Identifier.Name, this);
            IdentifierExpression.ResolveNames(ls);
        }

        public string GetName()
        {
            return IdentifierExpression.Identifier.Name;
        }

        public Type GetDeclarationType()
        {
            return Type;
        }

        public override void TypeCheck()
        {
            Type.TypeCheck();
        }

        public int GetNumber()
        {
            return AttributeNumber;
        }

        public override void GenCode(ref string output)
        {
            output += Environment.NewLine + ".field";

            foreach (var fieldModifier in FieldModifiers)
            {
                output += $" {fieldModifier.ToString().ToLower()}";
            }

            output += $"int ([{AttributeNumber}] ";
            output += $" {IdentifierExpression.Identifier.Name}";

        }

        public override void GenStoreCode(ref string output)
        {

        }
    }
}