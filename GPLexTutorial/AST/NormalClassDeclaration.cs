using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class NormalClassDeclaration : TypeDeclaration
    {
        public List<ClassModifier> ClassModifiers { get; set; }
        public Identifier Identifier { get; set; }
        public List<MemberDeclaration> ClassMemberDeclarations { get; set; }
        public NormalClassDeclaration(List<ClassModifier> classModifiers, Identifier identifier, List<MemberDeclaration> classMemberDeclarations)
        {
            ClassModifiers = classModifiers;
            Identifier = identifier;
            ClassMemberDeclarations = classMemberDeclarations;
        }
    }
}