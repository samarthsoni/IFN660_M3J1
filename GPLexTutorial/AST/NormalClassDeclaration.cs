using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class NormalClassDeclaration :TypeDeclaration
    {
        public List<ClassModifier> ClassModifiers { get; set; }
        public Identifier Identifier { get; set; }
        public List<ClassMemberDeclaration> ClassMemberDeclarations { get; set; }
    }
}