﻿using System;
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

        public override bool Equal(Type other)
        {
            throw new NotImplementedException();
        }

        public override void TypeCheck()
        {
            foreach (var ClassMemberDeclaration in ClassMemberDeclarations)
                ClassMemberDeclaration.TypeCheck();
        }

        public int GetNumber()
        {
            return 0;
        }

        public override void GenCode(ref string output)
        {
            output += Environment.NewLine + ".class";

            foreach(var modifier in ClassModifiers)
            {
                output += $" {modifier.ToString().ToLower()}";
            }
            output +=$" {this.Identifier.Name}"+Environment.NewLine+"{";

            foreach (var ClassMemberDeclaration in ClassMemberDeclarations)
                ClassMemberDeclaration.GenCode(ref output);

            output += Environment.NewLine + "}";

        }

        public override void GenStoreCode(ref string output)
        {
            
        }
    }
}