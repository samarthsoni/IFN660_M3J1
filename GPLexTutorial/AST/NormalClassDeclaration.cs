using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class NormalClassDeclaration : Type,IDeclaration
    {
        public List<ClassModifier> ClassModifiers { get; set; }
        public Identifier Identifier { get; set; }
        public List<MemberDeclaration> ClassMemberDeclarations { get; set; }
        public LexicalScope  LexicalScope { get; set; }
        public NormalClassDeclaration(List<ClassModifier> classModifiers, Identifier identifier, List<MemberDeclaration> classMemberDeclarations)
        {
            ClassModifiers = classModifiers;
            Identifier = identifier;
            ClassMemberDeclarations = classMemberDeclarations;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            ls.SymbolTable.Add(GetName(), this);
            LexicalScope = new LexicalScope(ls);
            foreach (var ClassMemberDeclaration in ClassMemberDeclarations)
                ClassMemberDeclaration.ResolveNames(LexicalScope);
        }

        public string GetName()
        {
            return Identifier.Name;
        }

        public Type GetDeclarationType()
        {
            return this;
        }
    }
}